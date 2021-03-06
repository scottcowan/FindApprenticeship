﻿CREATE PROCEDURE dbo.uspGetOriginalContractOwnerForSites
    @providerSiteIds NVARCHAR(400) = ''
AS  
BEGIN 
 
    SET NOCOUNT ON  
  
    BEGIN TRY  
    
		DECLARE @tpIds TABLE  
		(  
			TPId   NVARCHAR(20)  
		)  
		DECLARE @position   INT  
		DECLARE @piece      NVARCHAR(20)  
		DECLARE @workingIds NVARCHAR(400)  
	  
		-- Need to tack a delimiter onto the end of the input string if one doesn?t exist  
		SET @workingIds = @providerSiteIds  
		IF RIGHT(RTRIM(@workingIds),1) <> ','  
			SET @workingIds = @workingIds  + ','  
	   
		SET @position =  PATINDEX('%,%' , @workingIds)  
		WHILE @position <> 0  
		BEGIN  
			SET @piece = LEFT(@workingIds, @position - 1)  
	   
		-- You have a piece of data, so insert it, print it, do whatever you want to with it.  
			INSERT INTO @tpIds VALUES ( @piece )  
	  
			SET @workingIds = STUFF(@workingIds, 1, @position, '')  
			SET @position =  PATINDEX('%,%' , @workingIds)  
		END  

		SELECT  
				DISTINCT  p.ProviderId, p.TradingName 
		FROM	
				Provider p
				INNER JOIN Vacancy v ON p.ProviderId = v.OriginalContractOwnerId
				INNER JOIN ProviderSiteRelationship psr ON psr.ProviderId = p.ProviderId
				INNER JOIN ProviderSite ps ON ps.ProviderSiteId = psr.ProviderSiteId
		WHERE
				( ps.ProviderSiteID IN ( SELECT TPId FROM @tpIds ) OR @providerSiteIds = '' ) 	
				
    END TRY  
	BEGIN CATCH  
		EXEC RethrowError;  
	END CATCH  
  
    SET NOCOUNT OFF  
END