Feature: RA607
	In order to begin the process of creating a vacancy via the API
	As a provider or employer
	I want to be able to link an employer to a provider site and specify the vacancies location

@RA607
Scenario: Link an employer to a provider site without authorization
	When I request to link employer identified with EDSURN: 123456789 to provider site identified with EDSURN: 987654321 with description: Employer description and website: test.com
	Then The response status is: Unauthorized
	And I do not see the employer link for the employer identified with EDSURN: 123456789 and the provider site identified with EDSURN: 987654321

@RA607
Scenario: Link an employer to a provider site no description and bad url
	When I authorize my request with a Provider API key
	And I request to link employer identified with EDSURN: 123456789 to provider site identified with EDSURN: 0 with description: null and website: test
	Then The response status is: BadRequest
	And The validation errors contain:
		| Property            | Error                                               |
		| ProviderSiteEdsUrn  | You must specify the provider site's EDSURN.        |
		| EmployerDescription | Please supply a description for the employer.       |
		| EmployerWebsiteUrl  | Please supply a valid website url for the employer. |
	And I do not see the employer link for the employer identified with EDSURN: 123456789 and the provider site identified with EDSURN: 0

@RA607
Scenario: Link an employer to a provider site
	When I authorize my request with a Provider API key
	And I request to link employer identified with EDSURN: 123456789 to provider site identified with EDSURN: 987654321 with description: <p>Employer description</p> and website: test.com
	Then The response status is: OK
	And I see the employer link for the employer identified with EDSURN: 123456789 and the provider site identified with EDSURN: 987654321 with description: <p>Employer description</p> and website: test.com

@RA607
Scenario: Provider Create a vacancy at the employer's location
	Given I am creating a vacancy
	When I authorize my request with a Provider API key
	And I specify a location type of SpecificLocation
	And I specify vacancy owner relationship with id: 42
	And I specify the vacancy has 3 positions
	And I POST the vacancy to the API
	Then The response status is: OK
	And I see that the vacancy's status is Draft
	And I see created vacancy matches the posted vacancy

@RA607
Scenario: Create a vacancy with none of the mandatory fields
	Given I am creating a vacancy
	When I authorize my request with a Provider API key
	And I specify a location type of Unknown
	And I specify vacancy owner relationship with id: 0
	And I specify the vacancy has 0 positions
	And I POST the vacancy to the API
	Then The response status is: BadRequest
	And The validation errors contain:
		| Property                   | Error                                                                                                                                   |
		| VacancyOwnerRelationshipId | Please supply a valid vacancy owner relationship id. This must exist and be associated with a provider site your API key has access to. |
	And I do not see created vacancy

@RA607
Scenario: QA Create a vacancy at the employer's location
	Given I am creating a vacancy
	When I authorize my request with an Agency API key
	And I specify a location type of SpecificLocation
	And I specify vacancy owner relationship with id: 42
	And I specify the vacancy has 3 positions
	And I POST the vacancy to the API
	Then The response status is: OK
	And I see that the vacancy's status is Live
	And I see created vacancy matches the posted vacancy
