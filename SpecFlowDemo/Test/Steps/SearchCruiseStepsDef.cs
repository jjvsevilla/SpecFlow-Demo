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
            //_searchCruise.SelectSailFrom();
            //_searchCruise.SelectSailCalendar();
            //_searchCruise.SelectSailDuration();
            //_searchCruise.SelectSailTo();
        }

        [When(@"I select sail to ""(.*)""")]
        public void WhenISelectSailTo(string destiny)
        {
            _searchCruise.SelectSailToOption(destiny);
        }

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
