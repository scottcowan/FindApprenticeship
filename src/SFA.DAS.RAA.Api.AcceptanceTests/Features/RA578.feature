Feature: RA578
	In order to fully populate a vacancy
	As an API user
	I want to be able to retrieve County, Local Authority and Region information

@RA578 @GetAllCounties
Scenario: Get all Counties
	Given I request all counties
	Then The response status is: OK
	And I see all county information

@RA578 @GetCountyById
Scenario: Get County by id
	Given I request the county with id: 4
	Then The response status is: OK
	And I see the information for the county with id: 4

@RA578 @GetCountyById
Scenario: Get County by id that doesn't exist
	Given I request the county with id: 999
	Then The response status is: NotFound
	And I do not see the information for the county with id: 999

@RA578 @GetCountyByCode
Scenario: Get County by code
	Given I request the county with code: DER
	Then The response status is: OK
	And I see the information for the county with code: DER

@RA578 @GetCountyByCode
Scenario: Get County by code that doesn't exist
	Given I request the county with code: XXX
	Then The response status is: NotFound
	And I do not see the information for the county with code: XXX

@RA578 @GetLocalAuthorityById
Scenario: Get LocalAuthority by id
	Given I request the local authority with id: 160
	Then The response status is: OK
	And I see the information for the local authority with id: 160

@RA578 @GetLocalAuthorityById
Scenario: Get LocalAuthority by id that doesn't exist
	Given I request the local authority with id: 999
	Then The response status is: NotFound
	And I do not see the information for the local authority with id: 999

@RA578 @GetLocalAuthorityByCode
Scenario: Get LocalAuthority by code
	Given I request the local authority with code: 41UD
	Then The response status is: OK
	And I see the information for the local authority with code: 41UD

@RA578 @GetLocalAuthorityByCode
Scenario: Get LocalAuthority by code that doesn't exist
	Given I request the local authority with code: XXXX
	Then The response status is: NotFound
	And I do not see the information for the local authority with code: XXXX
