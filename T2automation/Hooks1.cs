using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using T2automation.Init;
using T2automation.Pages.Comm;
using TechTalk.SpecFlow;

namespace T2automation
{
    [Binding]
    public sealed class Hooks1
    {
        /*
        [AfterScenario]
        public static void SignOut()
        {
            DriverFactory driverFactory = new DriverFactory("BaseUrl");
            IWebDriver driver = driverFactory.GetDriver();
            Header header = new Header(driver);
            header.Signout(driver);
        }*/

        [AfterTestRun]
        public static void AfterTestRun()
        {
            DriverFactory driverFactory = new DriverFactory("BaseUrl");
            driverFactory.DisposeDriver();
        }
    }
}
