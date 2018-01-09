using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using T2automation.Pages.Comm;
using T2automation.Util;
using T2automation.Init;
using AutoItX3Lib;

namespace T2automation.Pages.MyMessages
{
    class InboxPage : LeftMenu
    {
        private readonly IWebDriver _driver;
        private ReadFromConfig readFromConfig;

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
        private IList<IWebElement> _cancelBtn;

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

        [FindsBy(How = How.Id, Using = "btnDepartmentTo")]
        private IWebElement _externalDeptToBtn;

        [FindsBy(How = How.Id, Using = "txtSearchTo3")]
        private IWebElement _searchDeptName;

        [FindsBy(How = How.Id, Using = "txtSearchExtDepToCode")]
        private IWebElement _searchDeptCodeName;

        [FindsBy(How = How.Id, Using = "docContentDiv")]
        private IWebElement _contentTab;

        [FindsBy(How = How.Id, Using = "tabAttache")]
        private IWebElement _attachmentTab;

        [FindsBy(How = How.XPath, Using = ".//*[@id='att-head-menu']/div[1]/a/label")]
        private IWebElement _attacheBtn;

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

        private SelectElement _deptType(IWebDriver driver)
        {
            return new SelectElement(driver.FindElement(By.Id("slcTypeToSearch")));
        }

        private SelectElement _deliveryType()
        {
            return new SelectElement(_driver.FindElement(By.Id("slctDeliveryType")));
        }

        private IList<IWebElement> _deptRadioBtn(IWebDriver driver)
        {
            return driver.FindElements(By.XPath(".//*[@id='externalDepartmentToGrid']/tbody/tr/td[1]/input"));
        }

        private IList<IWebElement> _deptNames(IWebDriver driver)
        {
            return driver.FindElements(By.XPath(".//*[@id='externalDepartmentToGrid']/tbody/tr/td[2]"));
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

            while (!IsAt(driver, "Create document - Ole5.1")) {
                Console.WriteLine("Loading Page....");
                Thread.Sleep(1000);
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
            Thread.Sleep(1000);
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
            Thread.Sleep(1000);
            for (int index = 0; index < _selectToName.Count; index++) {
                if (GetText(driver, _selectToName.ElementAt(index)).Contains(user)) {
                    Click(driver, _selectToCheck.ElementAt(index));
                    Click(driver, _selectToFrameToBtn);
                    Thread.Sleep(1000);
                    return;
                }
            }
        }

        public void ClickOkBtn() {
            Click(_driver, _okBtn);
            Thread.Sleep(1000);
        }

        public void EnterContentBody(string body) {
            _driver.SwitchTo().Frame(_contentBodyIFrame);
            SendKeys(_driver, _contentBody, body);
            _driver.SwitchTo().DefaultContent();
            Thread.Sleep(1000);
        }

        public void SendMail(string subject, string contentBody, bool checkPopup = false, int multipleAttachementNo = 1, string multipleAttachmentType = "") {
            ComposeMail(subject, contentBody);
            if (!multipleAttachmentType.Equals(""))
            {
                if (multipleAttachmentType.Contains(","))
                {
                    string[] types = multipleAttachmentType.Split(',');
                    foreach (string type in types)
                    {
                        AddAttachments(type);
                    }
                }
                else
                {
                    for (int i = 0; i < multipleAttachementNo; i++)
                    {
                        AddAttachments(multipleAttachmentType);
                    }
                }
            }
            Click(_driver, _sendBtn);
            Thread.Sleep(2000);
            if (checkPopup) {
                foreach (IWebElement cancelBtn in _cancelBtn) {
                    if (cancelBtn.Displayed) {
                        Click(_driver, cancelBtn);
                        break;
                    }
                }
            }
            WaitTillMailSent();
        }

        public bool OpenMail(IWebDriver driver, string subject, string encryptPass = "")
        {
            foreach (IWebElement elem in _subjectList)
            {
                if (GetText(driver, elem).Equals(subject))
                {
                    Click(driver, elem);
                    Thread.Sleep(1000);
                    if (!encryptPass.Equals("")) {
                        EncryptedPassword = encryptPass;
                        Click(driver, _encryptedPasswordOkBtn);
                        Thread.Sleep(5000);
                    }
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

        public void WaitTillMailSent()
        {
            try {
                WebDriverWait wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(60));
                wait.Until(drv => ElementIsDisplayed(_driver, _notificationContent(_driver)));
            }
            catch (Exception) {
                Console.WriteLine("Notification on sending email does not appear");
            }
        }

        public int SearchDept(string deptName = "", string deptCode = "", string type = "") {
            if (!deptName.Equals(""))
            {
                SendKeys(_driver, _searchDeptName, deptName);
            }
            if (!deptCode.Equals(""))
            {
                SendKeys(_driver, _searchDeptCodeName, deptName);
            }
            if (!type.Equals(""))
            {
                DropdownSelectByText(_driver, _deptType(_driver), type);
            }
            Thread.Sleep(5000);
            var deptNames = _deptNames(_driver);
            for (int index = 0; index < deptNames.Count; index++) {
                if (GetText(_driver, deptNames.ElementAt(index)).Equals(deptName)) {
                    return index;
                }
            }
            return -1;
        }

        public bool SelectExternalDeptTo(string deptName = "", string deptCode = "", string type = "") {
            Thread.Sleep(5000);
            Click(_driver, _externalDeptToBtn);
            int index = SearchDept(deptName, deptCode, type);
            if (index != -1) {
                Thread.Sleep(5000);
                Click(_driver, _deptRadioBtn(_driver).ElementAt(index));
                Thread.Sleep(2000);
                Click(_driver, _okBtn);
                Thread.Sleep(2000);
                return true;
            }
            Click(_driver, _okBtn);
            return false;
        }

        public void ComposeMail(string subject, string contentBody, string multipleAttachementNo = "No", string multipleAttachmentType = "png") {
            Subject = subject;
            EnterContentBody(contentBody);
        }

        public void SetProperties(string deliveryType = "")
        {
            DropdownSelectByText(_driver, _deliveryType(), deliveryType);
        }

        public void SendOutgoingMessage(string subject, string contentBody, string deliveryType = "", string deptName = "", string deptCode = "", string type = "") {
            NavigateToMyMessageInbox(_driver);
            CheckButtonClickable(_driver, "Outgoing Document");
            SelectExternalDeptTo(deptName, deptCode, type);
            SetProperties(deliveryType);
            Click(_driver, _contentTab);
            SendMail(subject, contentBody, checkPopup: true);
        }

        public void AddAttachments(string multipleAttachmentType) {
            Click(_driver, _attachmentTab);
            Click(_driver, _attacheBtn);
            AutoItX3 autoIt = new AutoItX3();
            autoIt.WinActivate("Open");
            readFromConfig = new ReadFromConfig();
            var filePath = readFromConfig.GetValue("AttachementFolder") + multipleAttachmentType;
            autoIt.Send(filePath);
            autoIt.Send("{ENTER}");
        }
    }
}
