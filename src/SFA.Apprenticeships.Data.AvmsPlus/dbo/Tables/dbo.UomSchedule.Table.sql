/*
Added to support the existing Data Science ETL process used to produce MI reports
*/
CREATE TABLE [dbo].[UomSchedule](
	[createdby] [uniqueidentifier] NULL,
	[createdbydsc] [int] NULL,
	[createdbyname] [nvarchar](160) NULL,
	[createdbyyominame] [nvarchar](160) NULL,
	[createdon] [datetime] NULL,
	[createdonutc] [datetime] NULL,
	[description] [ntext] NULL,
	[importsequencenumber] [int] NULL,
	[modifiedby] [uniqueidentifier] NULL,
	[modifiedbydsc] [int] NULL,
	[modifiedbyname] [nvarchar](160) NULL,
	[modifiedbyyominame] [nvarchar](160) NULL,
	[modifiedon] [datetime] NULL,
	[modifiedonutc] [datetime] NULL,
	[overriddencreatedon] [datetime] NULL,
	[overriddencreatedonutc] [datetime] NULL,
	[baseuomname] [nvarchar](100) NULL,
	[name] [nvarchar](200) NULL,
	[organizationid] [uniqueidentifier] NULL,
	[organizationiddsc] [int] NULL,
	[organizationidname] [nvarchar](160) NULL,
	[uomscheduleid] [uniqueidentifier] NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]