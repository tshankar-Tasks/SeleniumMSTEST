using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;

namespace BDD_SeleniumSpecflow.PageObjects
{
    [TestClass]
    public class SliderMenu
    {
        #region WebElement

        [FindsBy(How = How.Id, Using = "inventory_sidebar_link")]
        public IWebElement AllItems { get; set; }

        [FindsBy(How = How.Id, Using = "about_sidebar_link")]
        public IWebElement About { get; set; }

        [FindsBy(How = How.Id, Using = "logout_sidebar_link")]
        public IWebElement Logout { get; set; }

        [FindsBy(How = How.Id, Using = "reset_sidebar_link")]
        public IWebElement Reset { get; set; }
        #endregion

        #region Helper
        IWebDriver WebDriver = SauceDemo.WebDriver;

        public SliderMenu()
        {
            PageFactory.InitElements(WebDriver, this);
        }

        public static void WaitforPageLoad(IWebDriver webDriver)
        {
            WebDriverWait wait = new WebDriverWait(webDriver, TimeSpan.FromSeconds(60));
            wait.Until(x => x.FindElement(By.Id("inventory_sidebar_link")));
        }

        public void LogoutApp()
        {
            WaitforPageLoad(WebDriver);
            Logout.Click();
        }
        #endregion

    }
}
