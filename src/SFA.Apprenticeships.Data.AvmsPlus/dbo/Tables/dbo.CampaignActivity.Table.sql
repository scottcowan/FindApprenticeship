/*
Added to support the existing Data Science ETL process used to produce MI reports
*/
CREATE TABLE [dbo].[CampaignActivity](
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
	[activityid] [uniqueidentifier] NULL,
	[actualcost] [money] NULL,
	[actualcost_base] [money] NULL,
	[actualdurationminutes] [int] NULL,
	[actualend] [datetime] NULL,
	[actualendutc] [datetime] NULL,
	[actualstart] [datetime] NULL,
	[actualstartutc] [datetime] NULL,
	[budgetedcost] [money] NULL,
	[budgetedcost_base] [money] NULL,
	[category] [nvarchar](250) NULL,
	[channeltypecode] [int] NULL,
	[channeltypecodename] [nvarchar](255) NULL,
	[checkfordonotsendmmonlistmembersname] [nvarchar](255) NULL,
	[donotsendonoptout] [bit] NULL,
	[exchangerate] [numeric](23, 10) NULL,
	[excludeifcontactedinxdays] [int] NULL,
	[ignoreinactivelistmembers] [bit] NULL,
	[ignoreinactivelistmembersname] [nvarchar](255) NULL,
	[isbilled] [bit] NULL,
	[isbilledname] [nvarchar](255) NULL,
	[isworkflowcreated] [bit] NULL,
	[isworkflowcreatedname] [nvarchar](255) NULL,
	[ownerid] [uniqueidentifier] NULL,
	[owneriddsc] [int] NULL,
	[owneridname] [nvarchar](160) NULL,
	[owneridtype] [int] NULL,
	[owneridyominame] [nvarchar](160) NULL,
	[owningbusinessunit] [uniqueidentifier] NULL,
	[owninguser] [uniqueidentifier] NULL,
	[prioritycode] [int] NULL,
	[prioritycodename] [nvarchar](255) NULL,
	[regardingobjectid] [uniqueidentifier] NULL,
	[regardingobjectiddsc] [int] NULL,
	[regardingobjectidname] [nvarchar](400) NULL,
	[regardingobjectidyominame] [nvarchar](400) NULL,
	[regardingobjecttypecode] [int] NULL,
	[scheduleddurationminutes] [int] NULL,
	[scheduledend] [datetime] NULL,
	[scheduledendutc] [datetime] NULL,
	[scheduledstart] [datetime] NULL,
	[scheduledstartutc] [datetime] NULL,
	[serviceid] [uniqueidentifier] NULL,
	[statecode] [int] NULL,
	[statecodename] [nvarchar](255) NULL,
	[statuscode] [int] NULL,
	[statuscodename] [nvarchar](255) NULL,
	[subcategory] [nvarchar](250) NULL,
	[subject] [nvarchar](200) NULL,
	[timezoneruleversionnumber] [int] NULL,
	[transactioncurrencyid] [uniqueidentifier] NULL,
	[transactioncurrencyiddsc] [int] NULL,
	[transactioncurrencyidname] [nvarchar](100) NULL,
	[typecode] [int] NULL,
	[typecodename] [nvarchar](255) NULL,
	[utcconversiontimezonecode] [int] NULL,
	[crm_moneyformatstring] [nvarchar](255) NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]