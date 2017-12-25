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

        [Given("^Admin set permissions for user \"(.*)\" \"(.*)\" \"(.*)\"$"), When("^Admin set permissions for user \"(.*)\" \"(.*)\" \"(.*)\"$"), Then("^Admin set permissions for user \"(.*)\" \"(.*)\" \"(.*)\"$")]
        public void AdminSetPermissionsForUser(string permissionName, bool value, string user) {
            userManagerPage = new UserManagerPage(driver);
            userManagerPage.NavigateToUserManager(driver);
            Assert.IsTrue(userManagerPage.IsAt(driver, userManagerPage.title));
            userManagerPage.Search(driver, user);
            Thread.Sleep(1000);
            permissionsPage = userManagerPage.OpenPermissions(driver, user);
            permissionsPage.SetMessagePermissions(driver, permissionName, value);
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

        [Then(@"""(.*)"" visibility should be ""(.*)""")]
        public void ThenVisibilityShouldBe(string buttonName, bool value)
        {
            inboxPage = new InboxPage(driver);
            inboxPage.NavigateToInbox(driver);
            Assert.IsTrue(inboxPage.IsAt(driver, inboxPage.title));
            Assert.IsTrue(inboxPage.CheckButtonAvailbility(driver, buttonName, value));
        }

    }
}