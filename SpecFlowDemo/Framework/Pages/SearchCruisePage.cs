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
        private By ImproveShoppingExperienceButtonNo = By.Id(@"modal-beta-no");
        private By ImproveShoppingExperienceButtonYes = By.Id(@"modal-beta-yes");
        #endregion

        #region Search Options
        private By SailToButton = By.CssSelector(@"li.sail-to");
        private By SailFromButton = By.CssSelector(@"li.sail-from");
        private By SailCalendarButton = By.CssSelector(@"li.sail-calendar");
        private By SailDurationButton = By.CssSelector(@"li.sail-duration");
        private By SearchButton = By.CssSelector(@"li.search-cta");
        #endregion

        #region Search options panels
        private By SearchOptions = By.CssSelector(@".search-form-options");
        private By SailToOptions = By.Id(@"sailTo");
        private By SailFromOptions = By.Id(@"sailFrom");
        private By SailCalendarOptions = By.Id(@"sailCalendar");
        private By SailDurationOptions = By.Id(@"sailDuration");
        #endregion
        
        private By SearchCount = By.CssSelector(@"div.search-count > span:first-child");
        private string xpathSearchOptionButtonTemplate = @"//*/button[contains(text(), '{0}')]";

        public SearchCruisePage(IWebDriver driver) : base(driver, Constants.SearchCruisePageTitle)
        {
            InitPage(this);
        }

        public void ImproveShoppingExperience(bool improveExperience = false)
        {
            if (improveExperience)
            {
                if (Helpers.CheckIfElementExist(Driver, ImproveShoppingExperienceButtonYes))
                    Helpers.ClickOnButton(Driver, ImproveShoppingExperienceButtonYes);
            }
            if (Helpers.CheckIfElementExist(Driver, ImproveShoppingExperienceButtonNo))
                Helpers.ClickOnButton(Driver, ImproveShoppingExperienceButtonNo);
        }

        public void SelectSailTo()
        {
            Helpers.ClickOnButton(Driver, SailToButton);
        }

        public void SelectSailFrom()
        {
            Helpers.ClickOnButton(Driver, SailFromButton);
        }

        public void SelectSailCalendar()
        {
            Helpers.ClickOnButton(Driver, SailCalendarButton);
        }

        public void SelectSailDuration()
        {
            Helpers.ClickOnButton(Driver, SailDurationButton);
        }

        public void Search()
        {
            Helpers.ClickOnButton(Driver, SearchButton);
        }

        public void SelectOption(string option)
        {
            Helpers.WaitUntilElementIsVisible(Driver, SearchOptions);

            var xPathSelector = string.Format(xpathSearchOptionButtonTemplate, option);
            Helpers.WaitUntilElementIsVisible(Driver, Constants.FindBy.XPath, xPathSelector);

            var element = Helpers.GetDynamicElement(Driver, Constants.FindBy.XPath, xPathSelector);
            Assert.IsNotNull(element);

            element.Click();
        }
        
        public void ValidateSearch()
        {
            Helpers.WaitUntilElementIsVisible(Driver, SearchCount);

            var element = Helpers.GetElement(Driver, SearchCount);
            Assert.IsNotNull(element);

            var result = Helpers.GetSearchResults(element.Text);
            Assert.That(result, Is.GreaterThan(0));
        }
    }
}
