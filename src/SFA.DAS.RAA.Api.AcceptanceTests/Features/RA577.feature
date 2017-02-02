Feature: RA577
Inorder to get create vacancies with standards and frameworks
As a consumer
I should be able to see the list of latest standards and frameworks

@RA577 @GetFrameworks
Scenario: Requesting for the latest frameworks
Given On requesting for all frameworks
Then The response status is: OK
And I see all the latest frameworks

@RA577 @GetStandards
Scenario: Requesting all standards
Given On requesting for all standards
Then The response status is: OK
And I see all the latest standards

@RA577 @GetFrameworkByIdReturnNotFound
Scenario: I request for a framework with a id 2 which has the status Ceased
When I request for a framework with id 2
Then The response status is: NotFound with response message: The requested framework has not been found.
And I do not see the framework details for the id: 2

@RA577 @GetFrameworkByIdReturnSuccess
Scenario: I request for a framework with a id 264 
When I request for a framework with id 264
Then The response status is: Ok 
And I see the framework details for id 264 


