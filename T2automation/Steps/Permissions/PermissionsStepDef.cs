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

        [Given("^Admin logged in \"(.*)\" \"(.*)\"$"), When("^Admin logged in \"(.*)\" \"(.*)\"$"), Then("^Admin logged in \"(.*)\" \"(.*)\"$")]
        public void AdminLoggedIn(string username, string password) {
            driver = driverFactory.GetDriver();
            loginPage = new LoginPage(driver);
            readFromConfig = new ReadFromConfig();
            loginPage.SelectEnglish(driver);
            loginPage.UserName = readFromConfig.GetUserName(username);
            loginPage.Password = readFromConfig.GetPassword(password);
            loginPage.ClickLoginButton(driver);
        }

        [Given("^Admin set permissions for user \"(.*)\" \"(.*)\" \"(.*)\"$"), When("^Admin set permissions for user \"(.*)\" \"(.*)\" \"(.*)\"$"), Then("^Admin set permissions for user \"(.*)\" \"(.*)\" \"(.*)\"$")]
        public void AdminSetPermissionsForUser(string permissionName, string value, string user) {
            userManagerPage = new UserManagerPage(driver);
            userManagerPage.NavigateTo(driver);
            Assert.IsTrue(userManagerPage.IsAt(driver));
            userManagerPage.Search(driver, user);
            userManagerPage.OpenPermissions(driver, user);

        }

        [Given("^User logs in \"(.*)\" \"(.*)\"$"), When("^User logs in \"(.*)\" \"(.*)\"$"), Then("^User logs in \"(.*)\" \"(.*)\"$")]
        public void UserLogsIn(string username, string password) {
            
        }

        [Given("^Visibilty of Internal Message button should be according to permissions  \"(.*)\"$"), When("^Visibilty of Internal Message button should be according to permissions  \"(.*)\"$"), Then("^Visibilty of Internal Message button should be according to permissions  \"(.*)\"$")]
        public void VisibiltyOfInternalMessageButtonShouldBeAccordingToPermissions(string permissionvalue) {
            
        }
    }
}