﻿SET IDENTITY_INSERT InterfaceErrorGroupType  ON
GO
MERGE INTO InterfaceErrorGroupType AS Target 
USING (VALUES 
  ('1','Data Errors'),
  ('2','Business Errors'),
  ('3','System Errors')
 ) 
AS SOURCE (InterfaceErrorGroupTypeId, GroupDescription)
ON TARGET.InterfaceErrorGroupTypeId = SOURCE.InterfaceErrorGroupTypeId
WHEN MATCHED THEN
	UPDATE SET TARGET.GroupDescription = SOURCE.GroupDescription
WHEN NOT MATCHED BY TARGET THEN
	INSERT (InterfaceErrorGroupTypeId, GroupDescription) 
	Values (SOURCE.InterfaceErrorGroupTypeId,SOURCE.GroupDescription)
WHEN NOT MATCHED BY SOURCE THEN
	DELETE;	

SET IDENTITY_INSERT InterfaceErrorGroupType OFF



		