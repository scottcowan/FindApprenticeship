Feature: RA578
	In order to fully populate a vacancy
	As an API user
	I want to be able to retrieve County, Local Authority and Region information

@RA578
Scenario: Get all Counties
	Given I request all counties
	Then The response status is: OK
	And I see all county information

Scenario: Get County by id
	Given I request the county with id: 4
	Then The response status is: OK
	And I see the information for the county with id: 4


Scenario: Get County by code
	Given I request the county with code: DER
	Then The response status is: OK
	And I see the information for the county with code: DER
