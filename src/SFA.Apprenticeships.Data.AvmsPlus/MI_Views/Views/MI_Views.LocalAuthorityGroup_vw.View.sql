CREATE VIEW [MI_Views].[LocalAuthorityGroup_vw]
AS
     SELECT LocalAuthorityGroupID,
            CodeName,
            ShortName,
            FullName,
            LocalAuthorityGroupTypeID,
            LocalAuthorityGroupPurposeID,
            ParentLocalAuthorityGroupID
     FROM dbo.LocalAuthorityGroup;