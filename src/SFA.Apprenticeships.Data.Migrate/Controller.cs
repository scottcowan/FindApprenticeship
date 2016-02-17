﻿namespace SFA.Apprenticeships.Data.Migrate
{
    using SFA.Infrastructure.Interfaces;
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;

    public class Controller
    {
        private ILogService _log;
        private IMigrateConfiguration _migrateConfig;
        private Func<ITableDetails, IMutateTarget> _createMutateTarget;
        private IEnumerable<ITableSpec> _tables;

        public ISyncRespository _syncRepository;

        public Controller(IMigrateConfiguration migrateConfig, ILogService log, ISyncRespository syncRepository, Func<ITableDetails, IMutateTarget> createMutateTarget, IEnumerable<ITableSpec> tables)
        {
            _migrateConfig = migrateConfig;
            _log = log;
            _syncRepository = syncRepository;
            _createMutateTarget = createMutateTarget;
            _tables = tables;
        }

        public void DoAll()
        {
            _log.Info("DoAll Started");

            while (true)
            {
                try
                {
                    DoUpdatesForAll();
                }
                catch (FatalException)
                {
                    throw;
                }
                catch (FullScanRequiredException)
                {
                    _log.Warn("Change tracking unavailable. Doing full scan");

                    try
                    {
                        DoFullScanForAll();
                    }
                    catch (FatalException)
                    {
                        throw;
                    }
                    catch (Exception ex)
                    {
                        _log.Error("Error occurred. Sleeping before trying again", ex);
                    }
                }
                catch (Exception ex)
                {
                    _log.Error("Error occurred. Sleeping before trying again", ex);
                }

                Thread.Sleep(10000);
            }

            _log.Info("DoAll Finished");
        }

        public void Reset()
        {
            ApplyToTablesUnthreadedReverseDependency(table => _syncRepository.DeleteAll(table));
            _syncRepository.Reset();
        }

        public void DoUpdatesForAll()
        {
            _log.Info("============ DoUpdatesForAll");
            using (var context = _syncRepository.StartChangesOnlySnapshotSync())
            {
                if (context.AreAnyChanges())
                    ApplyToTablesUnthreaded(tableSpec => DoUpdatesForTable(tableSpec, context));
                else
                    _log.Info("No changes");
                context.Success();
            }
        }

        public void DoFullScanForAll()
        {
            _log.Info("============ DoFullScanForAll");
            var context = _syncRepository.StartFullTransactionlessSync();
            ApplyToTables(tableSpec => DoInitial(tableSpec, context));
            context.Success();
        }

        public void ApplyToTables(Action<ITableSpec> action)
        {
            var tables = _tables.Select(tableSpec =>
                new KeyValuePair<ITableSpec, Task>(tableSpec, new Task(() => { try { action(tableSpec); } catch (Exception ex) { if (!(ex is FatalException)) _log.Error(ex); throw; } }))
                ).ToDictionary(i => i.Key, i => i.Value);

            while (true)
            {
                _log.Info($"---------- Scanning for tables to process");

                foreach (var table in tables)
                {
                    if (table.Value.IsFaulted && table.Value.Exception.GetBaseException() is FatalException)
                    {
                        throw table.Value.Exception.GetBaseException();
                    }
                    if (table.Value.Status != TaskStatus.Created)
                    {
                        _log.Debug($"Already started {table.Key.Name} - status is {table.Value.Status}");
                    }
                    else if (table.Key.DependsOn.Where(dependency => !tables[dependency].IsCompleted).Any())
                    {
                        _log.Debug($"Deferring {table.Key.Name} as dependent on " + string.Join(", ", table.Key.DependsOn.Where(dependency => !tables[dependency].IsCompleted).Select(t => t.Name)));
                    }
                    else
                    {
                        _log.Info($"Starting processing of {table.Key.Name}");
                        table.Value.Start();
                    }
                }

                var tasksRemaining = tables.Select(table => table.Value).Where(task => !task.IsCompleted).ToArray();
                if (!tasksRemaining.Any())
                    break;
                Task.WaitAny(tasksRemaining);
            }

            // Rethrow first of any (non-fatal) exception that may have occurred
            foreach (var table in tables)
            {
                if (table.Value.IsFaulted)
                    throw table.Value.Exception;
            }

        }

        public void ApplyToTablesUnthreaded(Action<ITableSpec> action)
        {
            _log.Info($"---------- Scanning for tables to process");

            foreach (var table in _tables)
            {
                _log.Info($"Processing {table.Name}");
                action(table);
            }
        }

        public void ApplyToTablesUnthreadedReverseDependency(Action<ITableSpec> action)
        {
            var tables = _tables.Select(tableSpec =>
                new KeyValuePair<ITableSpec, bool>(tableSpec, false) // Table -> completed
                ).ToDictionary(i => i.Key, i => i.Value);

            while (true)
            {
                _log.Info($"---------- Scanning for tables to process");

                foreach (var table in tables)
                {
                    if (table.Value)
                    {
                        _log.Debug($"Already finished {table.Key.Name}");
                    }
                    else
                    {
                        var outstandingDependencies = tables.Where(t => t.Key.DependsOn.Any(t2 => t2 == table.Key) && !t.Value).Select(t => t.Key.Name);

                        if (outstandingDependencies.Any())
                        {
                            _log.Debug($"Deferring {table.Key.Name} as dependent on {string.Join(", ", outstandingDependencies)}");
                        }
                        else
                        {
                            _log.Info($"Processing {table.Key.Name}");
                            action(table.Key);
                            tables[table.Key] = true;
                            break;
                        }
                    }
                }

                if (!tables.Any(table => !table.Value))
                    break;
            }
        }


        public void DoDummy(ITableDetails table)
        {
            Thread.Sleep(4000);
        }

        public void DoUpdatesForTable(ITableSpec table, ISnapshotSyncContext syncContext)
        {
            const int maxRecordsInBatch = 2000; // SQL parameter limit is 2100, so this is pretty much fixed.

            using (var mutateTarget = _createMutateTarget(table))
            {
                var changes = syncContext.GetChangesForTable(table);

                using (var changesEnumerator = changes.GetEnumerator())
                {
                    while (true)
                    {
                        var changesOfInterest = new Dictionary<long, Operation>();
                        for (int i = 0; i < maxRecordsInBatch && changesEnumerator.MoveNext(); i++)
                        {
                            var change = changesEnumerator.Current;
                            switch (change.Operation)
                            {
                                case Operation.Delete:
                                    _log.Warn($"Ignored delete of record {change.Id} from {table.Name}");
                                    break;
                                case Operation.Insert:
                                case Operation.Update:
                                    changesOfInterest.Add(change.Id, change.Operation);
                                    break;
                                default:
                                    throw new Exception($"Unknown change {change.Operation}");
                            }
                        }

                        if (!changesOfInterest.Any())
                            break;

                        var sourceRecords = syncContext.GetSourceRecordsAsync(table, changesOfInterest.Keys);
                        var targetRecords = syncContext.GetTargetRecords(table, changesOfInterest.Keys);

                        DoSlidingComparision(table, sourceRecords.Result, targetRecords, changesOfInterest, mutateTarget);
                    }
                }
            }
        }


        public void DoInitial(ITableSpec table, ITransactionlessSyncContext syncContext)
        {
            int batchSize = (int)(_migrateConfig.RecordBatchSize * table.BatchSizeMultiplier);
            using (var mutateTarget = _createMutateTarget(table))
            {
                long maxId = syncContext.GetMaxId(table);

                long startId = 0;

                while (startId < maxId)
                {
                    long endId = startId + batchSize - 1;
                    _log.Info($"Processing {startId} to {endId} on {table.Name} ({startId / Math.Max(maxId / 100, 1)}% done)");

                    var sourceRecords = syncContext.GetSourceRecordsAsync(table, startId, endId);
                    var targetRecords = syncContext.GetTargetRecords(table, startId, endId);

                    DoSlidingComparision(table, sourceRecords.Result, targetRecords, null, mutateTarget);

                    startId = endId + 1;
                }
            }
        }

        private long GetPrimaryKeyId(dynamic record, ITableSpec table)
        {
            var sourceId = ((IDictionary<string, object>)record)[table.PrimaryKey];
            if (sourceId == null)
                throw new FatalException($"Unknown column (may be case sensitive) or null value for {table.PrimaryKey} on {table.Name}");
            if (sourceId is long)
                return (long)sourceId;
            else if (sourceId is int)
                return (long)(int)sourceId;
            else
                throw new FatalException($"Unknown type {sourceId.GetType()}");

        }

        /*
        private Keys GetPrimaryKeyValues(dynamic record, ITableSpec table)
        {
            foreach (var key in table.PrimaryKeys)
            {
                var sourceId = ((IDictionary<string, object>)record)[key];
                if (sourceId == null)
                    throw new FatalException($"Unknown column (may be case sensitive) or null value for {table.PrimaryKeys.First()} on {table.Name}");
                if (sourceId is long)
                    return (long)sourceId;
                else if (sourceId is int)
                    return (long)(int)sourceId;
                else
                    throw new FatalException($"Unknown type {sourceId.GetType()}");
            }

        }
        */

        public void DoSlidingComparision(ITableSpec table, IEnumerable<dynamic> sourceRecords, IEnumerable<dynamic> targetRecords, IDictionary<long, Operation> operationById, IMutateTarget mutateTarget)
        {
            using (var targetRecordEnumerator = targetRecords.GetEnumerator())
            {
                var targetRecord = targetRecordEnumerator.MoveNext() ? targetRecordEnumerator.Current : null;

                foreach (var sourceRecord in sourceRecords)
                {
                    long sourceId = GetPrimaryKeyId(sourceRecord, table);

                    while (true)
                    {
                        long targetId = (targetRecord != null) ? GetPrimaryKeyId(targetRecord, table) : long.MaxValue;

                        if (targetId < sourceId)
                        {
                            // Record is missing from source. Keep advancing target until back in sync.
                            targetRecord = targetRecordEnumerator.MoveNext() ? targetRecordEnumerator.Current : null;
                            continue;
                        }
                        else if (targetId == sourceId)
                        {
                            // TODO: Detect whether different!
                            // Record in both source and target
                            DoChange(mutateTarget, table, sourceRecord, targetRecord);
                            targetRecord = targetRecordEnumerator.MoveNext() ? targetRecordEnumerator.Current : null;
                            break;
                        }
                        else if (targetId > sourceId)
                        {
                            // Record is missing from target. Keep inserting from source and advancing it until back in sync.
                            DoChange(mutateTarget, table, sourceRecord, null);
                            break;
                        }
                        else
                        {
                            throw new Exception("Impossible");
                        }
                    }
                }
            }
        }


        public void DoChange(IMutateTarget mutateTarget, ITableSpec table, dynamic sourceRecord, dynamic targetRecord)
        {
            if (table.Transform(targetRecord, sourceRecord))
            {
                if (targetRecord == null)
                {
                    mutateTarget.Insert(sourceRecord);
                }
                else
                {
                    var sourceRecordDict = (IDictionary<string, object>)sourceRecord;
                    var targetRecordDict = (IDictionary<string, object>)targetRecord;

                    bool changed = false;
                    foreach (var sourceCol in sourceRecordDict)
                    {
                        var targetColValue = targetRecordDict[sourceCol.Key];

                        bool equal;
                        if (sourceCol.Value == null || targetColValue == null)
                            equal = (sourceCol.Value == null && targetColValue == null);
                        else if (sourceCol.Value.GetType() == typeof(byte[]))
                        {
                            var s = (byte[])sourceCol.Value;
                            var t = (byte[])targetColValue;
                            equal = s.SequenceEqual(t);
                        }
                        else
                            equal = sourceCol.Value.Equals(targetColValue);

                        if (!equal)
                        {
                            _log.Info($"At least {sourceCol.Key} varies - updating");
                            changed = true;
                            break;
                        }
                    }

                    if (changed)
                        mutateTarget.Update(sourceRecord);
                    else
                        mutateTarget.NoChange(sourceRecord);
                }
            }
        }

        public class Keys : IComparable<Keys>
        {
            private long[] _key;

            public Keys(long[] values)
            {
                _key = new long[values.Length];
                Array.Copy(values, _key, values.Length);
            }

            public int CompareTo(Keys other)
            {
                if (_key.Length != other._key.Length)
                    throw new ArgumentException("Lengths differ");

                int result = 0;
                for (int i = 0; i < _key.Length && result == 0; i++)
                {
                    result = this._key[i].CompareTo(other._key[i]);
                }

                return result;
            }
        }
    }
}
