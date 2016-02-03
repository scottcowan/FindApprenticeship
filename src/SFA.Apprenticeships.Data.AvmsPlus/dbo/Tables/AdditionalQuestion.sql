﻿CREATE TABLE [dbo].[AdditionalQuestion] (
    [AdditionalQuestionId] INT             IDENTITY (1, 1) NOT FOR REPLICATION NOT NULL,
    [VacancyId]            INT             NOT NULL,
    [QuestionId]           SMALLINT        NOT NULL,
    [Question]             NVARCHAR (4000) NOT NULL,
    CONSTRAINT [PK_AdditionalQuestion] PRIMARY KEY CLUSTERED ([AdditionalQuestionId] ASC) WITH (FILLFACTOR = 90) ON [PRIMARY],
    CONSTRAINT [FK_AdditionalQuestion_Vacancy] FOREIGN KEY ([VacancyId]) REFERENCES [dbo].[Vacancy] ([VacancyId]),
    CONSTRAINT [uq_idx_additionalQuestion] UNIQUE NONCLUSTERED ([VacancyId] ASC, [QuestionId] ASC) WITH (FILLFACTOR = 90) ON [Index]
);

