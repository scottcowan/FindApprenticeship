Feature: Vacancy summary search
	In order to list vacancies on recruit and manage
	As a an API user
	I want to retrieve vacancies based on my search criteria

@RA611
Scenario: Request a full list of vacancies
	Given There are 250 vacancy summaries in the database
	When I authorize my request with a Provider API key
	And I request page 1 of the vacancy summaries with page size: 50
	Then The response status is: OK

@RA611
Scenario: Text search the vacancies
	Given There are 250 vacancy summaries in the database
	When I authorize my request with a Provider API key
	And I filter the results with the query 'Test'
	And I search all fields
	And I request page 1 of the vacancy summaries with page size: 50
	Then The response status is: OK

@RA611
Scenario: Text search the vacancies using the vacancy title field
	Given There are 250 vacancy summaries in the database
	When I authorize my request with a Provider API key
	And I filter the results with the query 'Test'
	And I only search the VacancyTitle field
	And I request page 1 of the vacancy summaries with page size: 50
	Then The response status is: OK

@RA611
Scenario: Filter the vacancies based on type
	Given There are 250 vacancy summaries in the database
	When I authorize my request with a Provider API key
	And I filter the results to the Apprenticeship vacancy type
	And I request page 1 of the vacancy summaries with page size: 50
	Then The response status is: OK

@RA611
Scenario: Filter the vacancies based on status
	Given There are 250 vacancy summaries in the database
	When I authorize my request with a Provider API key
	And I filter the results to Submitted status
	And I request page 1 of the vacancy summaries with page size: 50
	Then The response status is: OK

@RA611
Scenario: Filter the vacancies using all available options
	Given There are 250 vacancy summaries in the database
	When I authorize my request with a Provider API key
	And I filter the results with the query 'Test'
	And I search all fields
	And I filter the results to Submitted status
	And I filter the results to the Apprenticeship vacancy type
	And I request page 1 of the vacancy summaries with page size: 50
	Then The response status is: OK