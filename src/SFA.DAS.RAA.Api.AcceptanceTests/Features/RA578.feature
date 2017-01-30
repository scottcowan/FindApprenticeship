Feature: RA578
	In order to fully populate a vacancy
	As an API user
	I want to be able to retrieve County, Local Authority and Region information

@RA578
Scenario: Get all Counties
	Given I request all counties
	Then The response status is: OK
	And I see all county information
