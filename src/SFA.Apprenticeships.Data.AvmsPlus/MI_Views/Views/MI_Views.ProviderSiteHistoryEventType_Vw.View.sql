CREATE VIEW [MI_Views].[ProviderSiteHistoryEventType_Vw]
AS
     SELECT ProviderSiteHistoryEventTypeId,
            CodeName,
            ShortName,
            FullName
     FROM dbo.ProviderSiteHistoryEventType;