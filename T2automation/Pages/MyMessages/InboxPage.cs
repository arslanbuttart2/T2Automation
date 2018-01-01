using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using T2automation.Pages.Comm;

namespace T2automation.Pages.MyMessages
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

        [FindsBy(How = How.XPath, Using = "//*[@id='btnSelectTo']")]
        private IWebElement _toButton;

        [FindsBy(How = How.XPath, Using = "//*[@id='txtSearch2Temp']")]
        private IWebElement _searchNameCode;

        [FindsBy(How = How.XPath, Using = ".//*[@id='searchGrid2Temp']/tbody/tr/td[1]/label")]
        private IList<IWebElement> _selectToCheck;

        [FindsBy(How = How.XPath, Using = ".//*[@id='searchGrid2Temp']/tbody/tr/td[2]")]
        private IList<IWebElement> _selectToName;

        [FindsBy(How = How.XPath, Using = "//*[@id='btnSelectToTemp']")]
        private IWebElement _selectToFrameToBtn;

        [FindsBy(How = How.XPath, Using = "//*[@id='btnSelectCCTemp']")]
        private IWebElement _selectToFrameCCBtn;

        [FindsBy(How = How.XPath, Using = "//*[@id='txtSubject']")]
        private IWebElement _subject;

        [FindsBy(How = How.XPath, Using = ".//*[@id='cke_1_contents']/iframe")]
        private IWebElement _contentBodyIFrame;

        [FindsBy(How = How.XPath, Using = "html/body")]
        private IWebElement _contentBody;

        [FindsBy(How = How.XPath, Using = ".//*[@id='main-parent']/div/div[2]/div[2]/div[4]/div[1]/div[1]/a/label")]
        private IWebElement _sendBtn;

        [FindsBy(How = How.XPath, Using = ".//*[@id='container']/tbody/tr/td/label")]
        private IList<IWebElement> _checkboxList;

        [FindsBy(How = How.XPath, Using = ".//*[@id='container']/tbody/tr/td[3]")]
        private IList<IWebElement> _senderList;

        [FindsBy(How = How.XPath, Using = ".//*[@id='container']/tbody/tr/td[4]")]
        private IList<IWebElement> _subjectList;

        [FindsBy(How = How.XPath, Using = ".//*[@id='container']/tbody/tr/td[5]")]
        private IList<IWebElement> _referenceNoList;

        [FindsBy(How = How.XPath, Using = ".//*[@id='container']/tbody/tr/td[6]")]
        private IList<IWebElement> _receiveDateList;

        [FindsBy(How = How.XPath, Using = ".//*[@id='doc-part']/div[1]/div[2]/ul")]
        private IWebElement _mailTo;

        [FindsBy(How = How.XPath, Using = ".//*[@id='doc-part']/div[2]/div[1]/div[2]/ul/li")]
        private IWebElement _subjectInbox;

        [FindsBy(How = How.XPath, Using = ".//*[@id='contentBody']/div/div[@class = 'contentBodyHtml']")]
        private IWebElement _contentBodyInbox;

        [FindsBy(How = How.Id, Using = "txtPass")]
        private IWebElement _encryptedPassword;

        [FindsBy(How = How.Id, Using = "btnSubmit")]
        private IWebElement _encryptedPasswordOkBtn;

        private IWebElement _notificationContent(IWebDriver driver)
        {
            return driver.FindElement(By.Id("not-content0"));
        }

        private SelectElement _receiverType(IWebDriver driver) {
            return new SelectElement(driver.FindElement(By.Id("slctRecieverTypeTemp")));
        }

        private SelectElement _levelSelect(IWebDriver driver)
        {
            return new SelectElement(driver.FindElement(By.Id("slctLevel0Temp")));
        }

        public string title = "Inbox - Ole5.1";

        public InboxPage(IWebDriver driver) : base(driver) {
            _driver = driver;
            PageFactory.InitElements(_driver, this);
        }

        public string SearchNameCode
        {
            set
            {
                SendKeys(_driver, _searchNameCode, value);
            }
        }

        public string Subject
        {
            set
            {
                SendKeys(_driver, _subject, value);
            }
        }

        public string EncryptedPassword
        {
            set
            {
                SendKeys(_driver, _encryptedPassword, value);
            }
        }

        public bool CheckButtonAvailbility(IWebDriver driver, string buttonName, bool value) {
            IWebElement element = null;

            switch (buttonName) {
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
            Thread.Sleep(2000);
            if (buttonName.Equals("Encrypted internal message"))
            {
                EnterPassword(driver, "P@ssw0rd!@#");
                Thread.Sleep(2000);
            }
            return IsAt(driver, "Create document - Ole5.1");
        }

        public void EnterPassword(IWebDriver driver, string password)
        {
            SendKeys(driver, _passwordInput, password);
            Click(driver, _okBtn);
        }

        public void ClickToButton(IWebDriver driver)
        {
            Click(driver, _toButton);
            Thread.Sleep(2000);
        }

        public void SelectLevel(IWebDriver driver, string level) {
            DropdownSelectByText(driver, _levelSelect(driver), level);
            Thread.Sleep(1000);
        }

        public void SelectReceiverType(IWebDriver driver, string type)
        {
            DropdownSelectByText(driver, _receiverType(driver), type);
            Thread.Sleep(1000);
        }

        public void SelectToUser(IWebDriver driver, string user) {
            for (int index = 0; index < _selectToName.Count; index++) {
                if (GetText(driver, _selectToName.ElementAt(index)).Contains(user)) {
                    Click(driver, _selectToCheck.ElementAt(index));
                    Click(driver, _selectToFrameToBtn);
                    Thread.Sleep(1000);
                    return;
                }
            }
        }

        public void ClickOkBtn(IWebDriver driver) {
            Click(driver, _okBtn);
            Thread.Sleep(1000);
        }

        public void EnterContentBody(IWebDriver driver, string body) {
            driver.SwitchTo().Frame(_contentBodyIFrame);
            SendKeys(driver, _contentBody, body);
            driver.SwitchTo().DefaultContent();
            Thread.Sleep(1000);
        }

        public void SendMail(IWebDriver driver) {
            Click(driver, _sendBtn);
            Thread.Sleep(1000);
        }

        public bool OpenMail(IWebDriver driver, string subject)
        {
            foreach (IWebElement elem in _subjectList)
            {
                if (GetText(driver, elem).Equals(subject))
                {
                    Click(driver, elem);
                    Thread.Sleep(1000);
                    return true;
                }
            }
            return false;
        }

        public bool OpenMail(IWebDriver driver, string subject, string encryptPass)
        {
            foreach (IWebElement elem in _subjectList)
            {
                if (GetText(driver, elem).Equals(subject))
                {
                    Click(driver, elem);
                    Thread.Sleep(1000);
                    EncryptedPassword = encryptPass;
                    Click(driver, _encryptedPasswordOkBtn);
                    Thread.Sleep(5000);
                    return true;
                }
            }
            return false;
        }

        public bool ValidateTo(IWebDriver driver, string to)
        {
            return GetText(driver, _mailTo).Contains(to);
        }

        public bool ValidateSubject(IWebDriver driver, string subject)
        {
            return GetText(driver, _subjectInbox).Equals(subject);
        }

        public bool ValidateContentBody(IWebDriver driver, string contentBody)
        {
            return GetText(driver, _contentBodyInbox).Equals(contentBody);
        }

        public bool ValidateMail(IWebDriver driver, string to, string subject, string body)
        {
            if (OpenMail(driver, subject))
            {
                return (ValidateTo(driver, to) && ValidateSubject(driver, subject) && ValidateContentBody(driver, body));
            }
            return false;
        }

        public bool ValidateMail(IWebDriver driver, string to, string subject, string body, string listSubject, string encryptPass)
        {
            if (OpenMail(driver, listSubject, encryptPass))
            {
                return (ValidateTo(driver, to) && ValidateSubject(driver, subject) && ValidateContentBody(driver, body));
            }
            return false;
        }

        public void WaitTillMailSent(IWebDriver driver)
        {
            try {
                WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(60));
                wait.Until(drv => ElementIsDisplayed(driver, _notificationContent(driver)));
            }
            catch (Exception) {
                Console.WriteLine("Notification on sending email does not appear");
            }
        }
    }
}
