﻿CREATE PROCEDURE [dbo].[uspCandidatePreferencesDelete] 
	@candidatePreferenceId int
AS  
BEGIN  
 -- SET NOCOUNT ON added to prevent extra result sets from  
 -- interfering with SELECT statements.  
 SET NOCOUNT ON;  
  
    -- Insert statements for procedure here  
	Delete from CandidatePreferences  
	Where	CandidatePreferenceId = @candidatePreferenceId

END