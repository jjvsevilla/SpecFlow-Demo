Feature: SearchingCruises
	In order to get some good deals
	As a vacationer
	I want to search some cruises
	
Background: The user goes to Carnival search page
	Given I have entered Carnival search page

@done
@search by sail to
Scenario: Searching cruises to Alaska
	When I click on SAIL TO
		And I select sail to "Alaska"
	Then the result should display some cruises

@done
@search by sail from
Scenario: Searching cruises from Miami
	When I click on SAIL FROM
		And I select sail from "Miami"
	Then the result should display some cruises

@ignore
@wip
@search by dates
Scenario: Searching cruises by dates
	When I click on DATES
		And I select as date "2017, Feb"
	Then the result should display some cruises

@done
@search by duration
Scenario: Searching cruises by duration
	When I click on DURATION
		And I select duration "6 - 9" days
	Then the result should display some cruises

@ignore
@search
Scenario Outline: Searching cruises
	When I click on SAIL TO
		And I select sail to "<to>"
	Then the result should display some cruises
	
Examples:
    | to					 | from | dates | duration |
    | Alaska				 | x    | x     | x        |
    | The Bahamas			 | x    | x     | x        |
    | Bermuda				 | x    | x     | x        |
    | Canada & New England	 | x    | x     | x        |
    | Caribbean				 | x    | x     | x        |
    | Europe				 | x    | x     | x        |
    | Hawaii				 | x    | x     | x        |
    | Mexico				 | x    | x     | x        |
    | Panama Canal			 | x    | x     | x		   |
    | Transatlantic			 | x    | x     | x        |	
