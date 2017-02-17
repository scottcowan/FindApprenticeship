Feature: RA644
	In order to create a Vacancy
	As a recruiter
	I want to be able to link a new employer from a given list

@mytag
Scenario: Requesting an employer by edsurn
	When I authorize my request with a Provider API key
	Given On requesting for an employer by edsurn: 130180483
	Then The response status is: OK
	And I see the employer: 130180483
