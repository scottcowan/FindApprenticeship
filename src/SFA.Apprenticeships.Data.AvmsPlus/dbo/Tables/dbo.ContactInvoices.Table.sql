/*
Added to support the existing Data Science ETL process used to produce MI reports
*/
CREATE TABLE [dbo].[ContactInvoices](
	[contactid] [uniqueidentifier] NULL,
	[contactinvoiceid] [uniqueidentifier] NULL,
	[invoiceid] [uniqueidentifier] NULL
) ON [PRIMARY]
