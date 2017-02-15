Feature: RA584
	In order to list vacancies on an external site
	As a an API user
	I want to retrieve all live vacancies

@RA584
Scenario: Get second page of public live vacancy summaries
	When I request page 2 of the list of 13 public live vacancy summaries with page size: 5
	Then The response status is: OK
	And I see 5 public vacancy summaries on page 2 from a total of 13 and 3 total pages

@RA584
Scenario: Get public live vacancy
	When I request the public vacancy details for the vacancy with reference number: 1
	Then The response status is: OK
	And I see the public vacancy details for the vacancy with reference number: 1

@RA584
Scenario: Get public closed vacancy
	When I request the public vacancy details for the vacancy with id: 2
	Then The response status is: NotFound
	And I do not see the public vacancy details for the vacancy with id: 2

@RA584
Scenario: Get public not found vacancy
	When I request the public vacancy details for the vacancy with GUID: 3
	Then The response status is: NotFound
	And I do not see the public vacancy details for the vacancy with GUID: 3