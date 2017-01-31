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