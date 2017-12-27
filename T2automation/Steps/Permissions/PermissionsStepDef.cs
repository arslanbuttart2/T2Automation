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

namespace T2automation
{

    [Binding]
    public class PermissionsStepDef
    {
        DriverFactory driverFactory = new DriverFactory("BaseURL");
        private IWebDriver driver;
        private LoginPage loginPage;
        private UserManagerPage userManagerPage;
        private ReadFromConfig readFromConfig;
        private PermissionsPage permissionsPage;
        private InboxPage inboxPage;

        [Given("^Admin logged in \"(.*)\" \"(.*)\"$"), When("^Admin logged in \"(.*)\" \"(.*)\"$"), Then("^Admin logged in \"(.*)\" \"(.*)\"$")]
        public void AdminLoggedIn(string username, string password) {
            driver = driverFactory.GetDriver();
            loginPage = new LoginPage(driver);
            readFromConfig = new ReadFromConfig();
            Thread.Sleep(1000);
            loginPage.CheckLogin(driver);
            loginPage.SelectEnglish(driver);
            loginPage.UserName = readFromConfig.GetUserName(username);
            loginPage.Password = readFromConfig.GetPassword(password);
            loginPage.ClickLoginButton(driver);
            Thread.Sleep(3000);
        }

        [Given("^Admin set system message permissions for user \"(.*)\" \"(.*)\" \"(.*)\"$"), When("^Admin set system message permissions for user \"(.*)\" \"(.*)\" \"(.*)\"$"), Then("^Admin set system message permissions for user \"(.*)\" \"(.*)\" \"(.*)\"$")]
        public void AdminSetSystemMessagePermissionsForUser(string permissionName, bool value, string user) {
            userManagerPage = new UserManagerPage(driver);
            userManagerPage.NavigateToUserManager(driver);
            Assert.IsTrue(userManagerPage.IsAt(driver, userManagerPage.title));

            permissionsPage = userManagerPage.OpenPermissions(driver, user);
            permissionsPage.IncludeSystemMessagePermissions(driver, permissionName, value);
        }

        [Given("^User logs in \"(.*)\" \"(.*)\"$"), When("^User logs in \"(.*)\" \"(.*)\"$"), Then("^User logs in \"(.*)\" \"(.*)\"$")]
        public void UserLogsIn(string username, string password) {
            loginPage.CheckLogin(driver);
            loginPage.SelectEnglish(driver);
            loginPage.UserName = readFromConfig.GetUserName(username);
            loginPage.Password = readFromConfig.GetPassword(password);
            loginPage.ClickLoginButton(driver);
            Thread.Sleep(5000);
        }

        [Then(@"""(.*)"" visibility should be on My Messages inbox ""(.*)""")]
        public void ThenVisibilityShouldBeOnMyMessagesInbox(string buttonName, bool value)
        {
            inboxPage = new InboxPage(driver);
            inboxPage.NavigateToInbox(driver);
            Assert.IsTrue(inboxPage.IsAt(driver, inboxPage.title));
            Assert.IsTrue(inboxPage.CheckButtonAvailbility(driver, buttonName, value));
            if (value)
            {
                Assert.IsTrue(inboxPage.CheckButtonClickable(driver, buttonName));
            }
        }

        [When(@"Admin set department message permissions for user ""(.*)"" ""(.*)"" ""(.*)"" ""(.*)""")]
        public void WhenAdminSetDepartmentMessagePermissionsForUser(string permissionName, bool value, string user, string dept)
        {
            userManagerPage = new UserManagerPage(driver);
            userManagerPage.NavigateToUserManager(driver);
            Assert.IsTrue(userManagerPage.IsAt(driver, userManagerPage.title));

            permissionsPage = userManagerPage.OpenPermissions(driver, user);
            permissionsPage.IncludeDeptMessagePermissions(driver, readFromConfig.GetDeptName(dept), permissionName, value);
        }

        [Then(@"""(.*)"" visibility should be ""(.*)"" on Department Messages inbox")]
        public void ThenVisibilityShouldBeOnDepartmentMessagesInbox(string p0, string p1)
        {
            ScenarioContext.Current.Pending();
        }

    }
}