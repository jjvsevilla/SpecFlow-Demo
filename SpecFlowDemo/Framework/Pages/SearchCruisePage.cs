using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;
using Framework.Utilities;
using NUnit.Framework;

namespace Framework.Pages
{
    public class SearchCruisePage : BasePage
    {
        #region Optional flow
        private const string IdForImproveShoppingExperienceButtonNo = @"modal-beta-no";
        [FindsBy(How = How.Id, Using = IdForImproveShoppingExperienceButtonNo)]
        private IWebElement ImproveShoppingExperienceButtonNo;

        private const string IdForImproveShoppingExperienceButtonYes = @"modal-beta-yes";
        [FindsBy(How = How.Id, Using = IdForImproveShoppingExperienceButtonYes)]
        private IWebElement ImproveShoppingExperienceButtonYes;
        #endregion

        #region Filters
        private const string CssSelectorForSailTo = @"li.sail-to";
        private By SailToButton = By.CssSelector(CssSelectorForSailTo);
        //[FindsBy(How = How.CssSelector, Using = CssSelectorForSailTo)]
        //private IWebElement SailToButton;

        private const string CssSelectorForSailFrom = @"li.sail-from";
        private By SailFromButton = By.CssSelector(CssSelectorForSailFrom);
        //[FindsBy(How = How.CssSelector, Using = CssSelectorForSailFrom)]
        //private IWebElement SailFromButton;

        private const string CssSelectorForSailCalendar = @"li.sail-calendar";
        private By SailCalendarButton = By.CssSelector(CssSelectorForSailCalendar);
        //[FindsBy(How = How.CssSelector, Using = CssSelectorForSailCalendar)]
        //private IWebElement SailCalendarButton;

        private const string CssSelectorForSailDuration = @"li.sail-duration";
        private By SailDurationButton = By.CssSelector(CssSelectorForSailDuration);
        //[FindsBy(How = How.CssSelector, Using = CssSelectorForSailDuration)]
        //private IWebElement SailDurationButton;

        private const string CssSelectorForSearch = @"li.search-cta";
        private By SearchButton = By.CssSelector(CssSelectorForSearch);
        //[FindsBy(How = How.CssSelector, Using = CssSelectorForSearch)]
        //private IWebElement SearchButton;

        #endregion

        #region Filter panels
        private const string CssSelectorForSearchOptions = @".search-form-options";
        private IWebElement SearchOptions;

        private const string IdSailToOptions = @"sailTo";
        private By SailToOptions = By.Id(IdSailToOptions);
        //[FindsBy(How = How.Id, Using = IdSailToOptions)]
        //private IWebElement SailToOptions;

        private const string IdSailFromOptions = @"sailFrom";
        private By SailFromOptions = By.Id(IdSailFromOptions);
        //[FindsBy(How = How.Id, Using = IdSailFromOptions)]
        //private IWebElement SailFromOptions;

        private const string IdSailCalendarOptions = @"sailCalendar";
        private By SailCalendarOptions = By.Id(IdSailCalendarOptions);
        //[FindsBy(How = How.Id, Using = IdSailCalendarOptions)]
        //private IWebElement SailCalendarOptions;

        private const string IdSailDurationOptions = @"sailDuration";
        private By SailDurationOptions = By.Id(IdSailDurationOptions);
        //[FindsBy(How = How.Id, Using = IdSailDurationOptions)]
        //private IWebElement SailDurationOptions;
        #endregion

        private const string CssSelectorForSearchCount = @"div.search-count > span:first-child";
        private IWebElement SearchCount;

        private string xpathButtonTemplate = @"//*/button[contains(text(), '{0}')]";

        public SearchCruisePage(IWebDriver driver) : base(driver, Constants.SearchCruisePageTitle)
        {
            InitPage(this);
        }

        public void ImproveShoppingExperience(bool improveExperience = false)
        {
            if (improveExperience)
            {
                if (Helpers.CheckIfElementExist(Driver, Constants.FindBy.Id, IdForImproveShoppingExperienceButtonYes))
                    ImproveShoppingExperienceButtonYes.Click();
            }
            if (Helpers.CheckIfElementExist(Driver, Constants.FindBy.Id, IdForImproveShoppingExperienceButtonNo))
                ImproveShoppingExperienceButtonNo.Click();
        }

        public void SelectSailTo()
        {
            Helpers.ClickOnButton(Driver, Constants.FindBy.CssSelector, CssSelectorForSailTo, SailToButton);
        }

        public void SelectSailFrom()
        {
            Helpers.ClickOnButton(Driver, Constants.FindBy.CssSelector, CssSelectorForSailFrom, SailFromButton);
        }

        public void SelectSailCalendar()
        {
            Helpers.ClickOnButton(Driver, Constants.FindBy.CssSelector, CssSelectorForSailCalendar, SailCalendarButton);
        }

        public void SelectSailDuration()
        {
            Helpers.ClickOnButton(Driver, Constants.FindBy.CssSelector, CssSelectorForSailDuration, SailDurationButton);
        }

        public void Search()
        {
            Helpers.ClickOnButton(Driver, Constants.FindBy.CssSelector, CssSelectorForSearch, SearchButton);
        }

        public void SelectSailToOption(string option)
        {
            Helpers.WaitUntilElementIsVisible(Driver, Constants.FindBy.Id, IdSailToOptions);

            var xPathSelector = string.Format(xpathButtonTemplate, option);
            Helpers.WaitUntilElementIsVisible(Driver, Constants.FindBy.XPath, xPathSelector);

            var sailToOption = Helpers.GetDynamicElement(Driver, Constants.FindBy.XPath, xPathSelector);
            Assert.IsNotNull(sailToOption);

            sailToOption.Click();
        }


        public void ValidateSearch()
        {
            Helpers.WaitUntilElementIsVisible(Driver, Constants.FindBy.CssSelector, CssSelectorForSearchCount);

            SearchCount = Helpers.GetDynamicElement(Driver, Constants.FindBy.CssSelector, CssSelectorForSearchCount);
            Assert.IsNotNull(SearchCount);

            var result = Helpers.GetSearchResults(SearchCount.Text);
            Assert.That(result, Is.GreaterThan(0));
        }
    }
}
