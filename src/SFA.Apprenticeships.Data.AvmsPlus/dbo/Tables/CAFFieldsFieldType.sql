﻿CREATE TABLE [dbo].[CAFFieldsFieldType] (
    [CAFFieldsFieldTypeId] SMALLINT       IDENTITY (-1, -1) NOT FOR REPLICATION NOT NULL,
    [CodeName]             NVARCHAR (3)   NOT NULL,
    [ShortName]            NVARCHAR (100) NOT NULL,
    [FullName]             NVARCHAR (200) NOT NULL,
    CONSTRAINT [PK_CAFFieldsFieldType] PRIMARY KEY CLUSTERED ([CAFFieldsFieldTypeId] ASC),
    CONSTRAINT [uq_idx_CAFFieldsFieldType] UNIQUE NONCLUSTERED ([FullName] ASC)
);

