Feature: PriivacyPolicy

A short summary of the feature

Scenario: Privacy Policy Page
	Given I am on home page
	When I click on "Privacy"
	Then I see "Use this page to detail your site's privacy policy"

	When I click on "Home"
	Then I see "Vaccine Eligibility Calculator"