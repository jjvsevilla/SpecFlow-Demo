using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace Framework.Utilities
{
    public static class Helpers
    {
        public static string GetFormattedSailTo(string sailTo)
        {
            return sailTo.Replace(" ", "_");
        } 

        public static int GetSearchResults(string SearchCountMessage)
        {
            var entries = SearchCountMessage.Split(' ');
            var result = 0;
            Int32.TryParse(entries[0], out result);
            return result;
        }

        /*
        public static void ClickOnButton(IWebDriver driver, Constants.FindBy findBy, string identifier, By by)
        {
            if (Helpers.CheckIfElementExist(driver, findBy, identifier))
                Helpers.GetElement(driver, by).Click();
        }
        */
        
        #region using enum and string identifier        
        public static IWebElement GetDynamicElement(IWebDriver driver, Constants.FindBy by, string identifier)
        {
            try
            {                
                if (CheckIfElementExist(driver, by, identifier))
                {
                    switch (by)
                    {
                        case Constants.FindBy.ClassName: return driver.FindElement(By.ClassName(identifier));
                        case Constants.FindBy.CssSelector: return driver.FindElement(By.CssSelector(identifier));
                        case Constants.FindBy.Id: return driver.FindElement(By.Id(identifier));
                        case Constants.FindBy.LinkText: return driver.FindElement(By.LinkText(identifier));
                        case Constants.FindBy.Name: return driver.FindElement(By.Name(identifier));
                        case Constants.FindBy.PartialLinkText: return driver.FindElement(By.PartialLinkText(identifier));
                        case Constants.FindBy.TagName: return driver.FindElement(By.TagName(identifier));
                        case Constants.FindBy.XPath: return driver.FindElement(By.XPath(identifier));
                    }
                }
                return null;
            }
            catch (NoSuchElementException ex)
            {
                Console.WriteLine("FindDynamicElement > NoSuchElementException ex: {0}", ex.Message);
                throw;
            }
        }

            /*
        public static void WaitUntilElementIsClickable(IWebDriver driver, Constants.FindBy by, string identifier)
        {
            try
            {
                var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(Constants.AjaxSearchCruiseTimeOut));
                switch (by)
                {
                    case Constants.FindBy.ClassName: wait.Until(ExpectedConditions.ElementToBeClickable(By.ClassName(identifier))); break;
                    case Constants.FindBy.CssSelector: wait.Until(ExpectedConditions.ElementToBeClickable(By.CssSelector(identifier))); break;
                    case Constants.FindBy.Id: wait.Until(ExpectedConditions.ElementToBeClickable(By.Id(identifier))); break;
                    case Constants.FindBy.LinkText: wait.Until(ExpectedConditions.ElementToBeClickable(By.LinkText(identifier))); break;
                    case Constants.FindBy.Name: wait.Until(ExpectedConditions.ElementToBeClickable(By.Name(identifier))); break;
                    case Constants.FindBy.PartialLinkText: wait.Until(ExpectedConditions.ElementToBeClickable(By.PartialLinkText(identifier))); break;
                    case Constants.FindBy.TagName: wait.Until(ExpectedConditions.ElementToBeClickable(By.TagName(identifier))); break;
                    case Constants.FindBy.XPath: wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath(identifier))); break;
                }
            }
            catch (ElementNotVisibleException ex)
            {
                Console.WriteLine("WaitUntilElementIsVisible > ElementNotVisibleException ex: {0}", ex.Message);
                throw;
            }
        }
        */
        
        public static void WaitUntilElementIsVisible(IWebDriver driver, Constants.FindBy by, string identifier)
        {
            try
            {
                var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(Constants.AjaxSearchCruiseTimeOut));
                switch (by)
                {
                    case Constants.FindBy.ClassName: wait.Until(ExpectedConditions.ElementIsVisible(By.ClassName(identifier))); break;
                    case Constants.FindBy.CssSelector: wait.Until(ExpectedConditions.ElementIsVisible(By.CssSelector(identifier))); break;
                    case Constants.FindBy.Id: wait.Until(ExpectedConditions.ElementIsVisible(By.Id(identifier))); break;
                    case Constants.FindBy.LinkText: wait.Until(ExpectedConditions.ElementIsVisible(By.LinkText(identifier))); break;
                    case Constants.FindBy.Name: wait.Until(ExpectedConditions.ElementIsVisible(By.Name(identifier))); break;
                    case Constants.FindBy.PartialLinkText: wait.Until(ExpectedConditions.ElementIsVisible(By.PartialLinkText(identifier))); break;
                    case Constants.FindBy.TagName: wait.Until(ExpectedConditions.ElementIsVisible(By.TagName(identifier))); break;
                    case Constants.FindBy.XPath: wait.Until(ExpectedConditions.ElementIsVisible(By.XPath(identifier))); break;
                }
            }
            catch (ElementNotVisibleException ex)
            {
                Console.WriteLine("WaitUntilElementIsVisible > ElementNotVisibleException ex: {0}", ex.Message);
                throw;
            }
        }

        public static bool CheckIfElementExist(IWebDriver driver, Constants.FindBy by, string identifier)
        {
            try
            {
                switch (by)
                {
                    case Constants.FindBy.ClassName: driver.FindElement(By.ClassName(identifier)); break;
                    case Constants.FindBy.CssSelector: driver.FindElement(By.CssSelector(identifier)); break;
                    case Constants.FindBy.Id: driver.FindElement(By.Id(identifier)); break;
                    case Constants.FindBy.LinkText: driver.FindElement(By.LinkText(identifier)); break;
                    case Constants.FindBy.Name: driver.FindElement(By.Name(identifier)); break;
                    case Constants.FindBy.PartialLinkText: driver.FindElement(By.PartialLinkText(identifier)); break;
                    case Constants.FindBy.TagName: driver.FindElement(By.TagName(identifier)); break;
                    case Constants.FindBy.XPath: driver.FindElement(By.XPath(identifier)); break;
                }
                return true;
            }
            catch (NoSuchElementException ex)
            {
                Console.WriteLine("CheckIfElementExist > NoSuchElementException ex: {0}", ex.Message);
                return false;
            }
        }
        #endregion

        #region using By identifier
        public static bool CheckIfElementExist(IWebDriver driver, By by)
        {
            try
            {
                var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(Constants.WaitForElement));
                wait.Until(ExpectedConditions.ElementExists(by));
                return true;
            }
            catch (NoSuchElementException ex)
            {
                Console.WriteLine("CheckIfElementExist > NoSuchElementException ex: {0}", ex.Message);
                return false;
            }
            catch (Exception ex)
            {
                Console.WriteLine("CheckIfElementExist > Exception ex: {0}", ex.Message);
                return false;
            }
        }

        public static void ClickOnButton(IWebDriver driver, By by)
        {
            if (CheckIfElementExist(driver, by))
                GetElement(driver, by).Click();
        }

        public static IWebElement GetElement(IWebDriver driver, By by)
        {
            try
            {
                return driver.FindElement(by);
            }
            catch (NoSuchElementException ex)
            {
                Console.WriteLine("GetElement > NoSuchElementException ex: {0}", ex.Message);
                throw;
            }
        }

        public static void WaitUntilElementIsClickable(IWebDriver driver, By by)
        {            
            try
            {
                var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(Constants.AjaxSearchCruiseTimeOut));
                wait.Until(ExpectedConditions.ElementToBeClickable(by));
            }
            catch (ElementNotVisibleException ex)
            {
                Console.WriteLine("WaitUntilElementIsVisible > ElementNotVisibleException ex: {0}", ex.Message);
                throw;
            }
        }

        public static void WaitUntilElementIsVisible(IWebDriver driver, By by)
        {           
            try
            {
                var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(Constants.AjaxSearchCruiseTimeOut));
                wait.Until(ExpectedConditions.ElementIsVisible(by));
            }
            catch (ElementNotVisibleException ex)
            {
                Console.WriteLine("WaitUntilElementIsVisible > ElementNotVisibleException ex: {0}", ex.Message);
                throw;
            }
        }
        #endregion

    }
}
