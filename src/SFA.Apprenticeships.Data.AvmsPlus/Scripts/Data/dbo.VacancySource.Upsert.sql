SET IDENTITY_INSERT [dbo].[VacancySource] ON
GO

MERGE INTO [dbo].[VacancySource] AS Target 
USING (VALUES 
  (0, 'UNK', 'UNK', 'Unknown'),
  (1, 'AV', 'AV', 'AVMS'),
  (2, 'LPI', 'LAPI', 'Legacy API'),
  (3, 'RAA', 'RAA', 'RAA'),
  (4, 'API', 'API', 'API')
) 
AS Source (VacancySourceId, CodeName, ShortName, FullName) 
ON Target.VacancySourceId = Source.VacancySourceId 
-- update matched rows 
WHEN MATCHED THEN 
UPDATE SET CodeName = Source.CodeName, ShortName = Source.ShortName, FullName = Source.FullName
-- insert new rows 
WHEN NOT MATCHED BY TARGET THEN 
INSERT (VacancySourceId, CodeName, ShortName, FullName) 
VALUES (VacancySourceId, CodeName, ShortName, FullName) 
-- delete rows that are in the target but not the source 
WHEN NOT MATCHED BY SOURCE THEN 
DELETE;

SET IDENTITY_INSERT [dbo].[VacancySource] OFF
GO
