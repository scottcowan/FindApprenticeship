/*
Added to support the existing Data Science ETL process used to produce MI reports
*/
CREATE TABLE [dbo].[ListMember](
	[createdby] [uniqueidentifier] NULL,
	[createdbydsc] [int] NULL,
	[createdbyname] [nvarchar](160) NULL,
	[createdbyyominame] [nvarchar](160) NULL,
	[createdon] [datetime] NULL,
	[createdonutc] [datetime] NULL,
	[modifiedby] [uniqueidentifier] NULL,
	[modifiedbydsc] [int] NULL,
	[modifiedbyname] [nvarchar](160) NULL,
	[modifiedbyyominame] [nvarchar](160) NULL,
	[modifiedon] [datetime] NULL,
	[modifiedonutc] [datetime] NULL,
	[entityid] [uniqueidentifier] NULL,
	[entitytype] [int] NULL,
	[listid] [uniqueidentifier] NULL,
	[listmemberid] [uniqueidentifier] NULL,
	[owningbusinessunit] [uniqueidentifier] NULL,
	[owninguser] [uniqueidentifier] NULL
) ON [PRIMARY]