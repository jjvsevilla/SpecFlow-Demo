using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;
using OpenQA.Selenium;
using BoDi;
using Framework.Utilities;

namespace Test.Hooks
{
    [Binding]
    public class Scenario
    {
        private readonly IObjectContainer _objectContainer;

        public Scenario(IObjectContainer objectContainer)
        {
            _objectContainer = objectContainer;
        }

        [BeforeScenario]
        public void Before()
        {
            var driverHelper = new DriverHelper();
            var driver = driverHelper.InitDriver();

            _objectContainer.RegisterInstanceAs<IWebDriver>(driver);
        }

        [AfterScenario]
        public void After()
        {
            var driver = _objectContainer.Resolve<IWebDriver>();
            driver.Close();
        }


    }
}
