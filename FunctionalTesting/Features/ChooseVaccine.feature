Feature: ChooseVaccine

A short summary of the feature

@Calculation
Scenario: Vaccine For Female
	Given I am on home page
	When I submit the form
	Then I see "The Age field is required."
	And I see "The Gender field is required."

	When I set my age to 25
	And I choose "Female" as my gender
	And I submit the form
	Then I see "AstraZeneca is the most suitable vaccine for you."
