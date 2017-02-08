using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;
using Framework.Utilities;

namespace Framework.Pages
{
    public abstract class BasePage
    {
        protected readonly IWebDriver Driver;
        protected readonly string PageTitle;

        protected BasePage(IWebDriver driver, string pageTitle)
        {
            Driver = driver;
            PageTitle = pageTitle;
        }

        protected void InitPage(object page)
        {
            WaitForLoad();
            PageFactory.InitElements(Driver, page);
        }

        protected void WaitForLoad()
        {
            var wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(Constants.LoadPageTimeOut));
            try
            {
                wait.Until(p => p.Title == PageTitle);
            }
            catch (Exception ex)
            {
                Console.WriteLine("WaitForLoad > Exception ex: {0}", ex.Message);
                throw;
            }
        }

        public void GoTo(string url)
        {
            Driver.Navigate().GoToUrl(url);
        }

    }
}
