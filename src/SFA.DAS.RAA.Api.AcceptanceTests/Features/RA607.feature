﻿Feature: RA607
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
Scenario: Create a vacancy at the employer's location
	When I authorize my request with a Provider API key
	And I request to create a SpecificLocation vacancy for vacancy owner relationship with id: 42 and 3 positions
	Then The response status is: OK
	And I see that the vacancy's status is Draft
	And I see the SpecificLocation vacancy for vacancy owner relationship with id: 42 and 3 positions

@RA607
Scenario: Create a vacancy with none of the mandatory fields
	When I authorize my request with a Provider API key
	And I request to create a Unknown vacancy for vacancy owner relationship with id: 0 and 0 positions
	Then The response status is: BadRequest
	And The validation errors contain:
		| Property                   | Error                                               |
		| VacancyLocationType        | You must specify the provider site's EDSURN.        |
		| VacancyOwnerRelationshipId | Please supply a description for the employer.       |
		| NumberOfPositions          | Please supply a valid website url for the employer. |
	And I do not see the Unknown vacancy for vacancy owner relationship with id: 0 and 0 positions
