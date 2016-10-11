/*
Added to support the existing Data Science ETL process used to produce MI reports
*/
CREATE TABLE [dbo].[AnnualFiscalCalendar](
	[annual] [money] NULL,
	[annual_base] [money] NULL,
	[businessunitid] [uniqueidentifier] NULL,
	[businessunitiddsc] [int] NULL,
	[businessunitidname] [nvarchar](160) NULL,
	[createdby] [uniqueidentifier] NULL,
	[createdbydsc] [int] NULL,
	[createdbyname] [nvarchar](160) NULL,
	[createdbyyominame] [nvarchar](160) NULL,
	[createdon] [datetime] NULL,
	[createdonutc] [datetime] NULL,
	[effectiveon] [datetime] NULL,
	[effectiveonutc] [datetime] NULL,
	[exchangerate] [numeric](23, 10) NULL,
	[fiscalperiodtype] [int] NULL,
	[modifiedby] [uniqueidentifier] NULL,
	[modifiedbydsc] [int] NULL,
	[modifiedbyname] [nvarchar](160) NULL,
	[modifiedbyyominame] [nvarchar](160) NULL,
	[modifiedon] [datetime] NULL,
	[modifiedonutc] [datetime] NULL,
	[salespersonid] [uniqueidentifier] NULL,
	[salespersoniddsc] [int] NULL,
	[salespersonidname] [nvarchar](160) NULL,
	[salespersonidyominame] [nvarchar](160) NULL,
	[timezoneruleversionnumber] [int] NULL,
	[transactioncurrencyid] [uniqueidentifier] NULL,
	[transactioncurrencyiddsc] [int] NULL,
	[transactioncurrencyidname] [nvarchar](100) NULL,
	[userfiscalcalendarid] [uniqueidentifier] NULL,
	[utcconversiontimezonecode] [int] NULL,
	[crm_moneyformatstring] [nvarchar](255) NULL
) ON [PRIMARY]