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

        [FindsBy(How = How.XPath, Using = ".//*[@id='divPermTree']/ul/li/span/a[text() = 'System Settings']/../span[1]")]
        private IWebElement _expandSystemSettings;

        [FindsBy(How = How.XPath, Using = ".//*[@id='divPermTree']/ul/li/span/a[text() = 'System Management']/../span[1]")]
        private IWebElement _expandSystemManagement;

        [FindsBy(How = How.XPath, Using = ".//*[@id='divPermTree']/ul/li/span/a[text() = 'Message Permission']/../span[1]")]
        private IWebElement _expandMessagePermission;

        [FindsBy(How = How.XPath, Using = ".//*[@id='divPermTree']/ul/li[3]/ul/li/span")]
        private IList<IWebElement> _messagePermissionsClass;

        [FindsBy(How = How.XPath, Using = ".//*[@id='divPermTree']/ul/li[3]/ul/li/span/a")]
        private IList<IWebElement> _messagePermissions;

        [FindsBy(How = How.XPath, Using = ".//*[@id='divPermTree']/ul/li[3]/ul/li/span/span[2]")]
        private IList<IWebElement> _selectMessagePermissions;

        [FindsBy(How = How.XPath, Using = ".//button[text() = 'Ok']")]
        private IWebElement _okBtn;

        [FindsBy(How = How.XPath, Using = ".//button[text() = 'Cancel']")]
        private IWebElement _cancelBtn;

        [FindsBy(How = How.XPath, Using = "html/body/div/div/div/div/button[3]")]
        private IWebElement _crossBtn;

        [FindsBy(How = How.XPath, Using = ".//button[text() = 'Yes']")]
        private IWebElement _yesBtn;

        [FindsBy(How = How.XPath, Using = ".//button[text() = 'No']")]
        private IWebElement _noBtn;

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

        public string title = "Permissions - Ole5.1";

        public PermissionsPage(IWebDriver driver) : base(driver)
        {
            _driver = driver;
            PageFactory.InitElements(_driver, this);
        }

        public void SetMessagePermissions(IWebDriver driver, string permissionName, bool value)
        {
            Click(driver, _includeList);
            Click(driver, _expandMessagePermission);
            for (int index = 0; index < _messagePermissions.Count - 1; index++) {
                if (GetText(driver, _messagePermissions.ElementAt(index)).Contains(permissionName)) {
                    if (GetAttribute(driver, _messagePermissionsClass.ElementAt(index), "class").Contains("selected") != value) {
                        Click(driver, _selectMessagePermissions.ElementAt(index));
                        Click(driver, _okBtn);
                        Click(driver, _yesBtn);
                        return;
                    }
                    Click(driver, _cancelBtn);
                    return;
                }
            }
        }
    }
}
