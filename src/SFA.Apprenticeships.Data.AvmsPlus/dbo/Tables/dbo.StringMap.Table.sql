/*
Added to support the existing Data Science ETL process used to produce MI reports
*/
CREATE TABLE [dbo].[StringMap](
	[FilteredViewName] [nvarchar](64) NULL,
	[AttributeName] [nvarchar](100) NULL,
	[AttributeValue] [int] NULL,
	[Value] [nvarchar](255) NULL,
	[DisplayOrder] [int] NULL
) ON [PRIMARY]