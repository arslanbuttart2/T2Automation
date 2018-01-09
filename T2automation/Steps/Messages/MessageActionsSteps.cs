using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using T2automation.Init;
using T2automation.Pages;
using T2automation.Pages.MyMessages;
using T2automation.Pages.SystemManagement.SystemManagement;
using T2automation.Util;
using TechTalk.SpecFlow;

namespace T2automation.Steps.Messages
{
    [Binding]
    class MessageActionsSteps
    {
        DriverFactory driverFactory = new DriverFactory("BaseURL");
        private IWebDriver driver;
        private OutboxPage outboxPage;
        private UserManagerPage userManagerPage;
        private ReadFromConfig readFromConfig;
        private PermissionsPage permissionsPage;
        private LoginPage loginPage;
        private Pages.MyMessages.InboxPage myMessageInboxPage;
        private Pages.DeptMessages.InboxPage deptMessageInboxPage;

        [When(@"user sends an internal message with attachment to ""(.*)"" ""(.*)"" ""(.*)"" ""(.*)"" ""(.*)"" ""(.*)"" ""(.*)""")]
        public void WhenUserSendsAnInternalMessageWithAttachmentTo(string level, string receiverType, string to, string subject, string content, int multipleAttachementNo, string multipleAttachmentType)
        {
            driver = driverFactory.GetDriver();
            myMessageInboxPage = new InboxPage(driver);
            myMessageInboxPage.NavigateToMyMessageInbox(driver);
            myMessageInboxPage.CheckButtonClickable(driver, "Internal Document");
            myMessageInboxPage.ClickToButton(driver);
            myMessageInboxPage.SelectLevel(driver, level);
            myMessageInboxPage.SelectReceiverType(driver, receiverType);
            myMessageInboxPage.SearchNameCode = to;
            myMessageInboxPage.SelectToUser(driver, to);
            myMessageInboxPage.ClickOkBtn();
            myMessageInboxPage.SendMail(subject, content, multipleAttachementNo: multipleAttachementNo, multipleAttachmentType: multipleAttachmentType);
        }

        [When(@"user sends an departmental internal message with attachment to ""(.*)"" ""(.*)"" ""(.*)"" ""(.*)"" ""(.*)"" ""(.*)"" ""(.*)"" ""(.*)""")]
        public void WhenUserSendsAnDepartmentalInternalMessageWithAttachmentTo(string level, string receiverType, string to, string subject, string content, int multipleAttachementNo, string multipleAttachmentType, string dept)
        {
            driver = driverFactory.GetDriver();
            myMessageInboxPage = new InboxPage(driver);
            deptMessageInboxPage = new Pages.DeptMessages.InboxPage(driver);
            deptMessageInboxPage.NavigateToQADeptInbox(driver);
            deptMessageInboxPage.CheckButtonClickable(driver, "Internal Document");
            myMessageInboxPage.ClickToButton(driver);
            myMessageInboxPage.SelectLevel(driver, level);
            myMessageInboxPage.SelectReceiverType(driver, receiverType);
            myMessageInboxPage.SearchNameCode = to;
            myMessageInboxPage.SelectToUser(driver, to);
            myMessageInboxPage.ClickOkBtn();
            myMessageInboxPage.SendMail(subject, content, multipleAttachementNo:multipleAttachementNo, multipleAttachmentType: multipleAttachmentType);
        }

        [Then(@"mail should appear in department message out box ""(.*)"" ""(.*)"" ""(.*)"" ""(.*)"" ""(.*)"" ""(.*)""")]
        public void ThenMailShouldAppearInDepartmentMessageOutBox(string to, string subject, string content, int attachmentNo, string attachmentType, string dept)
        {
            driver = driverFactory.GetDriver();
            outboxPage = new OutboxPage(driver);
            outboxPage.NavigateToQADeptOutbox(driver);
            Assert.IsTrue(outboxPage.ValidateMail(driver, to, subject, content, attachmentNo: attachmentNo, attachment: attachmentType));
        }
    }
}
