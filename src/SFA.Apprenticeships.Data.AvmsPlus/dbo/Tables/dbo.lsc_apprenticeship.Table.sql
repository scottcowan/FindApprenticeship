/*
Added to support the existing Data Science ETL process used to produce MI reports
*/
CREATE TABLE [dbo].[lsc_apprenticeship](
	[createdby] [uniqueidentifier] NULL,
	[createdbydsc] [int] NULL,
	[createdbyname] [nvarchar](160) NULL,
	[createdon] [datetime] NULL,
	[createdonutc] [datetime] NULL,
	[importsequencenumber] [int] NULL,
	[lsc_apprenticeshipid] [uniqueidentifier] NULL,
	[lsc_apprenticeshiplevel] [int] NULL,
	[lsc_apprenticeshiplevelname] [nvarchar](255) NULL,
	[lsc_available] [bit] NULL,
	[lsc_availablename] [nvarchar](255) NULL,
	[lsc_date_closed] [datetime] NULL,
	[lsc_date_closedutc] [datetime] NULL,
	[lsc_date_converted] [datetime] NULL,
	[lsc_date_convertedutc] [datetime] NULL,
	[lsc_description] [nvarchar](100) NULL,
	[lsc_jobtitle] [nvarchar](100) NULL,
	[lsc_leadid] [uniqueidentifier] NULL,
	[lsc_leadiddsc] [int] NULL,
	[lsc_leadidname] [nvarchar](160) NULL,
	[lsc_leadidyominame] [nvarchar](450) NULL,
	[lsc_name] [nvarchar](100) NULL,
	[lsc_otherstatus] [nvarchar](1000) NULL,
	[lsc_pathway_id] [uniqueidentifier] NULL,
	[lsc_pathway_iddsc] [int] NULL,
	[lsc_pathway_idname] [nvarchar](200) NULL,
	[lsc_regionid] [uniqueidentifier] NULL,
	[lsc_regioniddsc] [int] NULL,
	[lsc_regionidname] [nvarchar](200) NULL,
	[lsc_sector] [int] NULL,
	[lsc_sectorframework] [int] NULL,
	[lsc_sectorframeworkname] [nvarchar](255) NULL,
	[lsc_sectorname] [nvarchar](255) NULL,
	[lsc_sectortier1] [int] NULL,
	[lsc_sectortier1name] [nvarchar](255) NULL,
	[lsc_specifyunknownsector] [nvarchar](4000) NULL,
	[lsc_volumeofapprentices] [int] NULL,
	[modifiedby] [uniqueidentifier] NULL,
	[modifiedbydsc] [int] NULL,
	[modifiedbyname] [nvarchar](160) NULL,
	[modifiedon] [datetime] NULL,
	[modifiedonutc] [datetime] NULL,
	[overriddencreatedon] [datetime] NULL,
	[overriddencreatedonutc] [datetime] NULL,
	[ownerid] [uniqueidentifier] NULL,
	[owneriddsc] [int] NULL,
	[owneridname] [nvarchar](160) NULL,
	[owneridtype] [int] NULL,
	[owningbusinessunit] [uniqueidentifier] NULL,
	[owninguser] [uniqueidentifier] NULL,
	[statecode] [int] NULL,
	[statecodename] [nvarchar](255) NULL,
	[statuscode] [int] NULL,
	[statuscodename] [nvarchar](255) NULL,
	[timezoneruleversionnumber] [int] NULL,
	[utcconversiontimezonecode] [int] NULL
) ON [PRIMARY]