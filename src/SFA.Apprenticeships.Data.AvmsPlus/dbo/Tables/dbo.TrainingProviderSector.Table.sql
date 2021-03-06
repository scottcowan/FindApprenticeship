/*
Added to support the existing Data Science ETL process used to produce MI reports
*/
CREATE TABLE [dbo].[TrainingProviderSector](
	[TrainingProviderSectorId] [int] IDENTITY(1,1) NOT FOR REPLICATION NOT NULL,
	[TrainingProviderId] [int] NOT NULL,
	[SectorId] [int] NOT NULL,
	[PassRate] [smallint] NOT NULL
) ON [PRIMARY]