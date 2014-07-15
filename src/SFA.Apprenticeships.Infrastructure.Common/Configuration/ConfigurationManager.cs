﻿namespace SFA.Apprenticeships.Infrastructure.Common.Configuration
{
    using System;
    using System.Collections.Generic;
    using System.Configuration;
    using System.Globalization;
    using System.IO;
    using CuttingEdge.Conditions;

    public class ConfigurationManager : IConfigurationManager
    {
        public static string ConfigurationFileAppSetting = "ConfigurationPath";

        public System.Configuration.Configuration Configuration { get; private set; }

        public ConfigurationManager(string configFileAppSettingKey = null)
        {
            var configFile = string.IsNullOrEmpty(configFileAppSettingKey)
                ? System.Configuration.ConfigurationManager.AppSettings[ConfigurationFileAppSetting]
                : System.Configuration.ConfigurationManager.AppSettings[configFileAppSettingKey];

            if (!File.Exists(configFile))
            {
                configFile = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, configFile);
            }

            if (!File.Exists(configFile))
            {
                throw new ConfigurationErrorsException(string.Format((string) "Configuration file: {0} does not exist", (object) configFile));
            }

            var configMap = new ExeConfigurationFileMap
            {
                ExeConfigFilename = configFile
            };

            Configuration = System.Configuration.ConfigurationManager.OpenMappedExeConfiguration(configMap, ConfigurationUserLevel.None);
        }

        public string TryGetAppSetting(string key)
        {
            Condition.Requires(key, "key").IsNotNullOrWhiteSpace();

            var result = Configuration.AppSettings.Settings[key];
            if (result != null)
            {
                return result.Value;
            }

            // Create exception for logging.
            //var ex =
            //    new ApplicationException(
            //        string.Format(
            //            CultureInfo.InvariantCulture,
            //            "The value for '{0}' could not be found in the configuration file", key));
            // needs logging here

            return null;
        }

        public string GetAppSetting(string key)
        {
            var setting = TryGetAppSetting(key);
            if (setting == null)
            {
                throw new KeyNotFoundException(
                    string.Format("'{0}' was not found, or multiple values for the same key, in settings configuration file.", key));
            }

            return setting;
        }

        public T GetAppSetting<T>(string key)
        {
            var setting = GetAppSetting(key);
            return (T)Convert.ChangeType(setting, typeof(T));
        }

        public T GetAppSetting<T>(T defaultValue, string key)
        {
            Condition.Requires(key, "key").IsNotNullOrWhiteSpace();

            string result = TryGetAppSetting(key);
            if (result != null)
            {
                return (T)Convert.ChangeType(result, typeof(T), CultureInfo.InvariantCulture);
            }

            return defaultValue;
        }

        public ConfigurationSection GetSection(string sectionName)
        {
            return Configuration.GetSection(sectionName);
        }

        public ConnectionStringSettings GetConnectionString(string key)
        {
            Condition.Requires(key, "key").IsNotNullOrWhiteSpace();

            var result = Configuration.ConnectionStrings.ConnectionStrings[key];
            if (result == null)
            {
                throw new ApplicationException(
                    string.Format(
                        "The connection string '{0}' could not be found in the configuration file",
                        key));
            }

            return result;
        }
    }
}
