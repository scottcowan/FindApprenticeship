/*
Added to support the existing Data Science ETL process used to produce MI reports
*/
CREATE TABLE [dbo].[ServiceContractContacts](
	[contactid] [uniqueidentifier] NULL,
	[contractid] [uniqueidentifier] NULL,
	[servicecontractcontactid] [uniqueidentifier] NULL,
	[servicelevel] [int] NULL
) ON [PRIMARY]