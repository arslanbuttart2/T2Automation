using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using T2automation.Pages.SystemManagement.SystemManagement;

namespace T2automation.Pages.Comm
{
    class LeftMenu : BasePage
    {
        private readonly IWebDriver _driver;

        [FindsBy(How = How.XPath, Using = ".//*[@id='sNav']/div[2]/a/label")]
        private IWebElement _home;

        [FindsBy(How = How.XPath, Using = ".//*[@id='sNav']/div[3]/a/label")]
        private IWebElement _systemManagementMain;

        [FindsBy(How = How.XPath, Using = ".//*[@id='sNav']/div[3]/div[1]/a/label")]
        private IWebElement _systemManagement;

        [FindsBy(How = How.XPath, Using = ".//*[@id='sNav']/div[3]/div[1]/div[1]/a/label")]
        private IWebElement _userManager;

        [FindsBy(How = How.XPath, Using = ".//*[@id='sNav']/div[3]/div[1]/div[2]/a/label")]
        private IWebElement _roles;

        [FindsBy(How = How.XPath, Using = ".//*[@id='sNav']/div[3]/div[1]/div[3]/a/label")]
        private IWebElement _departmentSharedRoles;

        [FindsBy(How = How.XPath, Using = ".//*[@id='sNav']/div[3]/div[1]/div[4]/a/label")]
        private IWebElement _hierarchyManagement;

        [FindsBy(How = How.XPath, Using = ".//*[@id='sNav']/div[3]/div[1]/div[5]/a/label")]
        private IWebElement _notificationManagment;

        [FindsBy(How = How.XPath, Using = ".//*[@id='sNav']/div[3]/div[1]/div[6]/a/label")]
        private IWebElement _loginUsers;

        [FindsBy(How = How.XPath, Using = ".//*[@id='sNav']/div[3]/div[1]/div[7]/a/label")]
        private IWebElement _regulatoryReporting;

        [FindsBy(How = How.XPath, Using = ".//*[@id='sNav']/div[3]/div[1]/div[8]/a/label")]
        private IWebElement _systemLog;

        [FindsBy(How = How.XPath, Using = ".//*[@id='sNav']/div[3]/div[1]/div[9]/a/label")]
        private IWebElement _loginEvents;

        [FindsBy(How = How.XPath, Using = ".//*[@id='sNav']/div[3]/div[1]/div[10]/a/label")]
        private IWebElement _announcementGroup;

        [FindsBy(How = How.XPath, Using = ".//*[@id='sNav']/div[3]/div[2]/a/label")]
        private IWebElement _lookUps;

        [FindsBy(How = How.XPath, Using = ".//*[@id='sNav']/div[4]/a/label")]
        private IWebElement _messages;

        [FindsBy(How = How.XPath, Using = ".//*[@id='sNav']/div[4]/div[1]/a/label")]
        private IWebElement _messageReports;

        [FindsBy(How = How.XPath, Using = ".//*[@id='sNav']/div[4]/div[2]/a/label")]
        private IWebElement _forbidReceive;

        [FindsBy(How = How.XPath, Using = ".//*[@id='sNav']/div[4]/div[3]/a/label")]
        private IWebElement _deliveryStatementReports;

        [FindsBy(How = How.XPath, Using = ".//*[@id='sNav']/div[4]/div[4]/a/label")]
        private IWebElement _documentTemplate;

        [FindsBy(How = How.XPath, Using = ".//*[@id='myDocumentsDiv']/a/label")]
        private IWebElement _myMessages;

        [FindsBy(How = How.XPath, Using = ".//*[@id='folder-0']/a/label")]
        private IWebElement _inbox;

        [FindsBy(How = How.XPath, Using = ".//*[@id='folder-5']/a/label")]
        private IWebElement _outbox;

        [FindsBy(How = How.XPath, Using = ".//*[@id='folder-2']/a/label")]
        private IWebElement _drafts;

        [FindsBy(How = How.XPath, Using = ".//*[@id='folder-3']/a/label")]
        private IWebElement _archived;

        [FindsBy(How = How.XPath, Using = ".//*[@id='folder-4']/a/label")]
        private IWebElement _deleted;

        [FindsBy(How = How.XPath, Using = ".//*[@id='myDocumentsDiv']/div[6]/a/label")]
        private IWebElement _notifications;

        [FindsBy(How = How.XPath, Using = ".//*[@id='myDocumentsDiv']/div[7]/a/label")]
        private IWebElement _myMessageReports;

        [FindsBy(How = How.XPath, Using = ".//*[@id='organizationDocumentsDiv']/a/label")]
        private IWebElement _departmentMessages;

        [FindsBy(How = How.XPath, Using = ".//*[@id='sNav']/div[7]/a/label")]
        private IWebElement _search;

        [FindsBy(How = How.XPath, Using = ".//*[@id='sNav']/div[7]/div[1]/a/label")]
        private IWebElement _advancedSearch;

        [FindsBy(How = How.XPath, Using = ".//*[@id='sNav']/div[7]/div[2]/a/label")]
        private IWebElement _inquiry;

        [FindsBy(How = How.XPath, Using = ".//*[@id='sNav']/div[8]/a/label")]
        private IWebElement _tools;

        [FindsBy(How = How.XPath, Using = ".//*[@id='sNav']/div[8]/div/a/label")]
        private IWebElement _worldTimes;

        [FindsBy(How = How.XPath, Using = ".//*[@id='sNav']/div[9]/a/label")]
        private IWebElement _management;

        [FindsBy(How = How.XPath, Using = ".//*[@id='sNav']/div[9]/div[1]/a/label")]
        private IWebElement _configuration;

        [FindsBy(How = How.XPath, Using = ".//*[@id='sNav']/div[9]/div[2]/a/label")]
        private IWebElement _news;

        [FindsBy(How = How.XPath, Using = ".//*[@id='sNav']/div[9]/div[3]/a/label")]
        private IWebElement _changeMasterHash;

        [FindsBy(How = How.XPath, Using = ".//*[@id='sNav']/div[10]/a/label")]
        private IWebElement _userSettings;

        [FindsBy(How = How.XPath, Using = ".//*[@id='sNav']/div[10]/div[1]/a/label")]
        private IWebElement _autoForwarding;

        [FindsBy(How = How.XPath, Using = ".//*[@id='sNav']/div[10]/div[2]/a/label")]
        private IWebElement _userGroups;

        [FindsBy(How = How.XPath, Using = ".//*[@id='sNav']/div[10]/div[3]/a/label")]
        private IWebElement _templates;

        [FindsBy(How = How.XPath, Using = ".//*[@id='sNav']/div[11]/a/label")]
        private IWebElement _signOut;

        [FindsBy(How = How.XPath, Using = ".//button[text() = 'Yes']")]
        private IWebElement _yesBtn;

        [FindsBy(How = How.XPath, Using = ".//button[text() = 'No']")]
        private IWebElement _noBtn;

        public LeftMenu(IWebDriver driver)
        {
            _driver = driver;
            PageFactory.InitElements(_driver, this);
        }

        public void Signout(IWebDriver driver)
        {
            Click(driver, _signOut);
            Click(driver, _yesBtn);
        }

        public void NavigateToUserManager(IWebDriver driver)
        {
            Click(driver, _systemManagementMain);
            Click(driver, _systemManagement);
            Click(driver, _userManager);
        }

        public void NavigateToInbox(IWebDriver driver)
        {
            Click(driver, _myMessages);
            Click(driver, _inbox);
        }
    }
}
