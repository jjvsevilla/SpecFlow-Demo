using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.Configuration;

namespace Framework.Utilities
{
    public class DriverHelper
    {
        public IWebDriver InitDriver()
        {
            var driver = GetChromeDriver();
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl(GetBaseUrl());
            return driver;
        }

        private string GetBaseUrl()
        {
            return ConfigurationManager.AppSettings["ProjectUrl"];
        }

        private IWebDriver GetChromeDriver()
        {
            var projectPath = AppDomain.CurrentDomain.BaseDirectory;
            projectPath = projectPath.Replace(Constants.TestPath, Constants.FrameworkPath);
            var driverPath = Path.Combine(projectPath, Constants.ChromeDriver);

            var options = new ChromeOptions();
            options.AddArgument("test-type");
            options.AddArgument("start-maximized");
            options.AddArgument("--disable-extensions");
            var driver = new ChromeDriver(projectPath, options);
            return driver;
        }
    }
}
