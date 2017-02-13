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
Scenario:Get framework by id that has the status ceased
Given I request the framework whose status is ceased: 264
Then The response status is: NotFound
And I do not see the information for the framework with id: 264

@RA577 @GetFrameworkByIdReturnUnknown
Scenario:Get framework by id that does not exists
Given I request the framework with id: 999
Then The response status is: NotFound
And I do not see the information for the framework with id: 999

@RA577 @GetFrameworkByIdReturnSuccess
Scenario: Get Framework by id that does exist and is active
Given I request the framework with id: 2
Then The response status is: OK
And I see the information for the framework with id: 2

@RA577 @GetStandardByIdReturnSuccess
Scenario: Get Standard by id that exists and is active
Given I request the standard with id: 2
Then The response status is: OK
And I see the information for the standard with id: 2

@RA577 @GetStandardByIdReturnNotFound
Scenario: Get Standard by id that does not exists
Given I request the standard with id: 999
Then The response status is: NotFound
And I see do not see the information for the framework with id: 999

@RA577 @GetStandardByIdReturnCeased
Scenario: Get Standard by id that is ceased
Given I request the standard whose status is ceased: 180
Then The response status is: NotFound
And I see do not see the information for the framework with id: 180
