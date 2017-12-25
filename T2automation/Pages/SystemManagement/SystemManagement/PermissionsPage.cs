using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using T2automation.Pages.Comm;

namespace T2automation.Pages.SystemManagement.SystemManagement
{
    class PermissionsPage : LeftMenu
    {
        protected readonly IWebDriver _driver;

        [FindsBy(How = How.XPath, Using = ".//*[@id='main-tabs']/div[1]/a")]
        private IWebElement _userPermissionOnSystem;

        [FindsBy(How = How.XPath, Using = ".//*[@id='main-tabs']/div[2]/a")]
        private IWebElement _userPermissionOnDept;

        [FindsBy(How = How.XPath, Using = ".//*[@id='main-tabs']/div[3]/a")]
        private IWebElement _sendingPermissions;

        [FindsBy(How = How.Id, Using = "btnIncludeException")]
        private IWebElement _includeList;

        [FindsBy(How = How.Id, Using = "btnExcludeException")]
        private IWebElement _excludeList;

        [FindsBy(How = How.Id, Using = "btnViewResult")]
        private IWebElement _viewSystemPermissionResult;

        [FindsBy(How = How.Id, Using = "txtUserRoleSearch")]
        private IWebElement _search;

        [FindsBy(How = How.Id, Using = "AddbuttondivUserRoleGrid")]
        private IWebElement _addNewBtn;

        [FindsBy(How = How.Id, Using = "buttondivUserRoleGrid")]
        private IWebElement _deleteBtn;

        [FindsBy(How = How.Id, Using = "btnUopViewResult")]
        private IWebElement _viewDeptPermissionResult;

        private string title = "Permissions - Ole5.1";

        public PermissionsPage(IWebDriver driver) : base(driver) {
            _driver = driver;
            PageFactory.InitElements(_driver, this);
        }

        public bool IsAt(IWebDriver driver)
        {
            return driver.Title.Contains(title);
        }

        public void SetMessagePermissions(IWebDriver driver)
        {
        }
    }
}
