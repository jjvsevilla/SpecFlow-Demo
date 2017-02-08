Feature: SearchingCruises
	In order to get some good deals
	As a vacationer
	I want to search some cruises
	
@search
Scenario: Searching cruises to Alaska
	Given I have entered Carnival search page
	When I click on SAIL TO
		And I select sail to "Alaska"
	Then the result should display some cruises

@ignore
@search
Scenario Outline: Searching cruises
	Given I have entered Carnival search page
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
