/*
Added to support the existing Data Science ETL process used to produce MI reports
*/
CREATE TABLE [dbo].[OpportunityCompetitors](
	[competitorid] [uniqueidentifier] NULL,
	[opportunitycompetitorid] [uniqueidentifier] NULL,
	[opportunityid] [uniqueidentifier] NULL
) ON [PRIMARY]