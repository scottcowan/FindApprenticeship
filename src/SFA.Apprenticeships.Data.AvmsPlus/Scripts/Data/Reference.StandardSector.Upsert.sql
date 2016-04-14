﻿MERGE INTO [Reference].[StandardSector] AS Target 
USING (VALUES 
  (1, N'Actuarial', 1), 
  (2, N'Aerospace', 17), 
  (3, N'Automotive', 17), 
  (4, N'Automotive retail', 13), 
  (5, N'Butchery', 13), 
  (6, N'Conveyancing and probate', 1), 
  (7, N'Defence', 17),
  (8, N'Dental health', 20),
  (9, N'Digital Industries', 15),
  (10, N'Electrotechnical', 17),
  (11, N'Energy & Utilities', 17),
  (12, N'Financial Services', 1),
  (13, N'Food and Drink', 17),
  (14, N'Horticulture', 1),
  (15, N'Insurance', 1),
  (16, N'Law', 1),
  (17, N'Leadership & Management', 1),
  (18, N'Life and Industrial Sciences', 17),
  (19, N'Maritime', 17),
  (20, N'Newspaper and Broadcast Media', 3),
  (21, N'Nuclear', 17),
  (22, N'Property services', 7),
  (23, N'Public Service', 20),
  (24, N'Rail Design', 17),
  (25, N'Refrigeration Air Conditioning and Heat Pump (RACHP)', 17),
  (26, N'Surveying', 7),
  (27, N'Housing', 20),
  (28, N'Non-destructive Testing', 17),
  (29, N'Energy Management', 13)
) 
AS Source (StandardSectorId, FullName, ApprenticeshipOccupationId) 
ON Target.StandardSectorId = Source.StandardSectorId 
-- update matched rows 
WHEN MATCHED THEN 
UPDATE SET FullName = Source.FullName, ApprenticeshipOccupationId = Source.ApprenticeshipOccupationId
-- insert new rows 
WHEN NOT MATCHED BY TARGET THEN 
INSERT (StandardSectorId, FullName, ApprenticeshipOccupationId) 
VALUES (StandardSectorId, FullName, ApprenticeshipOccupationId) 
-- delete rows that are in the target but not the source 
WHEN NOT MATCHED BY SOURCE THEN 
DELETE;