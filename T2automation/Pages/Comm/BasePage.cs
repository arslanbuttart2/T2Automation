using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace T2automation.Pages.Comm
{
    class BasePage
    {
        public static TimeSpan WAIT_FOR_SECONDS = TimeSpan.FromSeconds(30);

        public static bool ElementIsDisplayed(IWebDriver driver, IWebElement element) {
            WebDriverWait wait = new WebDriverWait(driver, WAIT_FOR_SECONDS);
            try
            {
                return element.Displayed;
            }
            catch (Exception) {
                return false;
            }
        }

        public void WaitForElement(IWebDriver driver, IWebElement element)
        {
            WebDriverWait wait = new WebDriverWait(driver, WAIT_FOR_SECONDS);
            wait.Until(drv => ElementIsDisplayed(driver, element));
        }

        public void Click(IWebDriver driver, IWebElement element) {
            WaitForElement(driver, element);
            ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].scrollIntoView(true);", element);
            element.Click();
        }

        public void Submit(IWebDriver driver, IWebElement element)
        {
            WaitForElement(driver, element);
            ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].scrollIntoView(true);", element);
            element.Submit();
        }

        public void SendKeys(IWebDriver driver, IWebElement element, string value)
        {
            WaitForElement(driver, element);
            ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].scrollIntoView(true);", element);
            element.Clear();
            element.SendKeys(value);
        }

        public string GetText(IWebDriver driver, IWebElement element) {
            WaitForElement(driver, element);
            ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].scrollIntoView(true);", element);
            return element.Text;

        }
    }
}
