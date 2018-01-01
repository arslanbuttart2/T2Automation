using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using T2automation.Pages.Comm;

namespace T2automation.Pages.DeptMessages
{
    class InboxPage : LeftMenu
    {
        private readonly IWebDriver _driver;

        [FindsBy(How = How.XPath, Using = ".//*[@id='head-menu']/div/a/label[text() = ' Internal Document']")]
        private IWebElement _internalDocument;

        [FindsBy(How = How.XPath, Using = ".//*[@id='head-menu']/div/a/label[text() = ' Encrypted internal message']")]
        private IWebElement _encryptInernalMessage;

        [FindsBy(How = How.XPath, Using = ".//*[@id='head-menu']/div/a/label[text() = ' Incoming Document']")]
        private IWebElement _incomingDocument;

        [FindsBy(How = How.XPath, Using = ".//*[@id='head-menu']/div/a/label[text() = ' Outgoing Document']")]
        private IWebElement _outgoingDocument;

        [FindsBy(How = How.XPath, Using = ".//div[@class = 'ajs-content']/input")]
        private IWebElement _passwordInput;

        [FindsBy(How = How.XPath, Using = ".//Button[text() = 'Ok']")]
        private IWebElement _okBtn;

        [FindsBy(How = How.XPath, Using = ".//Button[text() = 'Cancel']")]
        private IWebElement _cancelBtn;

        public string title = "Inbox - Ole5.1";

        public InboxPage(IWebDriver driver) : base(driver)
        {
            _driver = driver;
            PageFactory.InitElements(_driver, this);
        }

        public bool CheckButtonAvailbility(IWebDriver driver, string buttonName, bool value)
        {
            IWebElement element = null;

            switch (buttonName)
            {
                case "Internal Document":
                    element = _internalDocument;
                    break;
                case "Encrypted internal message":
                    element = _encryptInernalMessage;
                    break;
                case "Incoming Document":
                    element = _incomingDocument;
                    break;
                case "Outgoing Document":
                    element = _outgoingDocument;
                    break;
            }

            return ElementIsDisplayed(driver, element) == value;
        }

        public bool CheckButtonClickable(IWebDriver driver, string buttonName)
        {
            IWebElement element = null;

            switch (buttonName)
            {
                case "Internal Document":
                    element = _internalDocument;
                    break;
                case "Encrypted internal message":
                    element = _encryptInernalMessage;
                    break;
                case "Incoming Document":
                    element = _incomingDocument;
                    break;
                case "Outgoing Document":
                    element = _outgoingDocument;
                    break;
            }

            Click(driver, element);
            if (buttonName.Equals("Encrypted internal message"))
            {
                EnterPassword(driver, "P@ssw0rd!@#");
            }
            return IsAt(driver, "Create document - Ole5.1");
        }

        public void EnterPassword(IWebDriver driver, string password)
        {
            SendKeys(driver, _passwordInput, password);
            Click(driver, _okBtn);
        }
    }
}
