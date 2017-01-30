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

@RA578 @GetAllLocalAuthorities
Scenario: Get all LocalAuthorities
	Given I request all local authorities
	Then The response status is: OK
	And I see all local authority information

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

@RA578 @GetAllRegions
Scenario: Get all Regions
	Given I request all regions
	Then The response status is: OK
	And I see all region information

@RA578 @GetRegionById
Scenario: Get Region by id
	Given I request the region with id: 1007
	Then The response status is: OK
	And I see the information for the region with id: 1007

@RA578 @GetRegionById
Scenario: Get Region by id that doesn't exist
	Given I request the region with id: 9999
	Then The response status is: NotFound
	And I do not see the information for the region with id: 9999

@RA578 @GetRegionByCode
Scenario: Get Region by code
	Given I request the region with code: WM
	Then The response status is: OK
	And I see the information for the region with code: WM

@RA578 @GetRegionByCode
Scenario: Get Region by code that doesn't exist
	Given I request the region with code: XX
	Then The response status is: NotFound
	And I do not see the information for the region with code: XX
