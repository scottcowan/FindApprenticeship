/*
Added to support the existing Data Science ETL process used to produce MI reports
*/
CREATE TABLE [dbo].[campaignitem](
	[campaignid] [uniqueidentifier] NULL,
	[campaignitemid] [uniqueidentifier] NULL,
	[entityid] [uniqueidentifier] NULL,
	[entitytype] [int] NULL,
	[owningbusinessunit] [uniqueidentifier] NULL,
	[owninguser] [uniqueidentifier] NULL
) ON [PRIMARY]