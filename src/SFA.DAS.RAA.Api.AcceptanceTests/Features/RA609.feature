Feature: RA609
	In order to add more detail to a vacancy
	As an API user
	I want to be able to populate all the text fields in a vacancy

@RA609
Scenario: Basic vacancy details text
	Given I am creating a vacancy
	When I authorize my request with a Provider API key
	And I specify a location type of SpecificLocation
	And I specify vacancy owner relationship with id: 42
	And I specify the vacancy has 3 positions
	And I POST the vacancy to the API
	Then The response status is: OK
	And I see that the vacancy's status is Draft
	And I see created vacancy matches the posted vacancy