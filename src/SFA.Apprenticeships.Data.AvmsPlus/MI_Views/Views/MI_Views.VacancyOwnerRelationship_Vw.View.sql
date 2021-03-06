CREATE VIEW [MI_Views].[VacancyOwnerRelationship_Vw]
AS
     SELECT VacancyOwnerRelationshipId,
            EmployerId,
            ProviderSiteID,
            ContractHolderIsEmployer,
            ManagerIsEmployer,
            StatusTypeId,
            Notes,
            EmployerDescription,
            EmployerWebsite,
            EmployerLogoAttachmentId,
            NationWideAllowed
     FROM dbo.VacancyOwnerRelationship;