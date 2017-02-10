using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;
using OpenQA.Selenium;
using Framework.Pages;

namespace Test.Steps
{
    [Binding]
    public class SearchCruiseStepsDef : TechTalk.SpecFlow.Steps
    {

        private readonly SearchCruisePage _searchCruise;

        public SearchCruiseStepsDef(IWebDriver driver)
        {
            _searchCruise = new SearchCruisePage(driver);
        }

        [Given(@"I have entered Carnival search page")]
        public void GivenIHaveEnteredCarnivalSearchPage()
        {
            _searchCruise.ImproveShoppingExperience();
        }

        [When(@"I click on SAIL TO")]
        public void WhenIClickOnSAILTO()
        {
            _searchCruise.SelectSailTo();
        }

        [When(@"I click on SAIL FROM")]
        public void WhenIClickOnSAILFROM()
        {
            _searchCruise.SelectSailFrom();
        }

        [When(@"I click on DATES")]
        public void WhenIClickOnDATES()
        {
            _searchCruise.SelectSailDuration();
        }

        [When(@"I click on DURATION")]
        public void WhenIClickOnDURATION()
        {
            _searchCruise.SelectSailDuration();
        }
        
        [When(@"I select sail from ""(.*)""")]
        [When(@"I select sail to ""(.*)""")]
        [When(@"I select duration ""(.*)"" days")]
        public void WhenISelectSailFrom(string option)
        {
            _searchCruise.SelectOption(option);
        }
        /*
        [When(@"I select sail to ""(.*)""")]
        public void WhenISelectSailTo(string option)
        {
            _searchCruise.SelectOption(option);
        }
        */
        [When(@"I select as date ""(.*)""")]
        public void WhenISelectAsDate(string p0)
        {
            ScenarioContext.Current.Pending();
        }
        /*
        [When(@"I select duration ""(.*)"" days")]
        public void WhenISelectDurationDays(string option)
        {
            _searchCruise.SelectOption(option);
        }
        */
        [When(@"I press SEARCH CRUISES")]
        public void WhenIPressSEARCHCRUISES()
        {
            _searchCruise.Search();
        }

        [Then(@"the result should display some cruises")]
        public void ThenTheResultShouldDisplaySomeCruises()
        {
            _searchCruise.ValidateSearch();
        }

    }
}
