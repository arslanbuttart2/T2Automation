using System;
using NUnit.Framework;
using TechTalk.SpecFlow;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.Threading;
using AutoItX3Lib;
using System.Configuration;
using T2automation.Init;
using T2automation.Pages;
using T2automation.Pages.SystemManagement.SystemManagement;
using T2automation.Util;
using T2automation.Pages.MyMessages;
using T2automation.Pages.Comm;

namespace T2automation.Steps.My_Messages
{
    [Binding]
    public class SendMessagesStepDef
    {
        DriverFactory driverFactory = new DriverFactory("BaseURL");
        private IWebDriver driver;
        private InboxPage inboxPage;
        private OutboxPage outboxPage;
        private UserManagerPage userManagerPage;
        private ReadFromConfig readFromConfig;
        private PermissionsPage permissionsPage;
        private LoginPage loginPage;
        private Pages.MyMessages.InboxPage myMessageInboxPage;
        private Pages.DeptMessages.InboxPage deptMessageInboxPage;


        [When(@"user sends an internal message to ""(.*)"" ""(.*)"" ""(.*)"" ""(.*)"" ""(.*)""")]
        public void WhenUserSendsAnInternalMessageTo(string level, string receiverType, string to, string subject, string content)
        {
            driver = driverFactory.GetDriver();
            inboxPage = new InboxPage(driver);
            inboxPage.NavigateToMyMessageInbox(driver);
            inboxPage.CheckButtonClickable(driver, "Internal Document");
            inboxPage.ClickToButton(driver);
            inboxPage.SelectLevel(driver, level);
            inboxPage.SelectReceiverType(driver, receiverType);
            inboxPage.SearchNameCode = to;
            inboxPage.SelectToUser(driver, to);
            inboxPage.ClickOkBtn(driver);
            inboxPage.Subject = subject;
            inboxPage.EnterContentBody(driver, content);
            inboxPage.SendMail(driver);
            inboxPage.WaitTillMailSent(driver);
        }

        [Then(@"mail should appear in the out box ""(.*)"" ""(.*)"" ""(.*)""")]
        public void ThenMailShouldAppearInTheOutBox(string to, string subject, string content)
        {
            outboxPage = new OutboxPage(driver);
            outboxPage.NavigateToMyMessageOutbox(driver);
            Assert.IsTrue(outboxPage.ValidateMail(driver, to, subject, content));
        }

        [Then(@"mail should appear in the inbox ""(.*)"" ""(.*)"" ""(.*)""")]
        public void ThenMailShouldAppearInTheInbox(string to, string subject, string content)
        {
            inboxPage = new InboxPage(driver);
            inboxPage.NavigateToMyMessageInbox(driver);
            Assert.IsTrue(inboxPage.ValidateMail(driver, to, subject, content));
        }

        [When(@"user sends an encrypted message to ""(.*)"" ""(.*)"" ""(.*)"" ""(.*)"" ""(.*)"" ""(.*)""")]
        public void WhenUserSendsAnEncryptedMessageTo(string level, string receiverType, string to, string subject, string content, string encryptPassword)
        {
            driver = driverFactory.GetDriver();
            inboxPage = new InboxPage(driver);
            inboxPage.NavigateToMyMessageInbox(driver);
            inboxPage.CheckButtonClickable(driver, "Encrypted internal message");
            inboxPage.ClickToButton(driver);
            inboxPage.SelectLevel(driver, level);
            inboxPage.SelectReceiverType(driver, receiverType);
            inboxPage.SearchNameCode = to;
            inboxPage.SelectToUser(driver, to);
            inboxPage.ClickOkBtn(driver);
            inboxPage.Subject = subject;
            inboxPage.EnterContentBody(driver, content);
            inboxPage.SendMail(driver);
            inboxPage.WaitTillMailSent(driver);
        }

        [Then(@"encrypted mail should appear in the out box ""(.*)"" ""(.*)"" ""(.*)"" ""(.*)"" ""(.*)""")]
        public void ThenEncryptedMailShouldAppearInTheOutBox(string to, string subject, string content, string listSubject, string encryptedPass)
        {
            outboxPage = new OutboxPage(driver);
            outboxPage.NavigateToMyMessageOutbox(driver);
            readFromConfig = new ReadFromConfig();
            Assert.IsTrue(outboxPage.ValidateMail(driver, to, subject, content, listSubject, readFromConfig.GetValue(encryptedPass)));
        }

        [Then(@"encrypted mail should appear in the inbox ""(.*)"" ""(.*)"" ""(.*)"" ""(.*)"" ""(.*)""")]
        public void ThenEncryptedMailShouldAppearInTheInbox(string to, string subject, string content, string listSubject, string encryptedPass)
        {
            inboxPage = new InboxPage(driver);
            inboxPage.NavigateToMyMessageInbox(driver);
            readFromConfig = new ReadFromConfig();
            Assert.IsTrue(inboxPage.ValidateMail(driver, to, subject, content, listSubject, readFromConfig.GetValue(encryptedPass)));
        }

        [When(@"user sends an incoming message to ""(.*)"" ""(.*)"" ""(.*)"" ""(.*)"" ""(.*)""")]
        public void WhenUserSendsAnIncomingMessageTo(string level, string receiverType, string to, string subject, string content)
        {
            driver = driverFactory.GetDriver();
            inboxPage = new InboxPage(driver);
            inboxPage.NavigateToMyMessageInbox(driver);
            inboxPage.CheckButtonClickable(driver, "Incoming Document");
            inboxPage.ClickToButton(driver);
            inboxPage.SelectLevel(driver, level);
            inboxPage.SelectReceiverType(driver, receiverType);
            inboxPage.SearchNameCode = to;
            inboxPage.SelectToUser(driver, to);
            inboxPage.ClickOkBtn(driver);
            inboxPage.Subject = subject;
            inboxPage.EnterContentBody(driver, content);
            inboxPage.SendMail(driver);
            inboxPage.WaitTillMailSent(driver);
        }
    }
}
