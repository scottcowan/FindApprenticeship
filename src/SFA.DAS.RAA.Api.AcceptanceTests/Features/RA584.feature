Feature: RA584
	In order to list vacancies on an external site
	As a an API user
	I want to retrieve all live vacancies

@RA584
Scenario: Get first page of live vacancy summaries
	When I request page 1 of the list of 13 live vacancy summaries with page size: 5
	Then The response status is: OK
	And I see 5 vacancy summaries on page 1 from a total of 13 and 3 total pages