Feature: Choose Best Vaccine

A short summary of the feature

Scenario: Choose Vaccine For Young Female
	Given I am 15-year old female
	Then my vaccine is "Johnson & Johnson"


Scenario: Choose Vaccine For Male
	Given I am 65-year old male
	Then my vaccine is "AstraZeneca"

Scenario: Choose Vaccine for person who did not specify their gender
	Given I am 50-year old
	Then my vaccine can be either "AstraZeneca" or "Pfizer"
	And the information does not mention gender