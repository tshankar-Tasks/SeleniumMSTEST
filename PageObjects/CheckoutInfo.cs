using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;
using BDD_SeleniumSpecflow.PageObjects;
using System;


namespace BDD_SeleniumSpecflow.PageObjects
{

    public class CheckoutInfo
    {

        #region WebElement
        [FindsBy(How = How.Id, Using = "first-name")]
        public IWebElement FirstName { get; set; }

        [FindsBy(How = How.Id, Using = "last-name")]
        public IWebElement LastName { get; set; }

        [FindsBy(How = How.Id, Using = "postal-code")]
        public IWebElement PostalCode { get; set; }

        [FindsBy(How = How.ClassName, Using = "cart_cancel_link")]
        public IWebElement Cancel { get; set; }

        [FindsBy(How = How.ClassName, Using = "btn_primary")]
        public IWebElement Continue { get; set; }

        #endregion PageObject


        #region Helper
        IWebDriver WebDriver = SauceDemo.WebDriver;

        public CheckoutInfo()
        {
            PageFactory.InitElements(WebDriver, this);
        }

        public static void WaitforPageLoad(IWebDriver webDriver)
        {
            WebDriverWait wait = new WebDriverWait(webDriver, TimeSpan.FromSeconds(60));
            wait.Until(x => x.FindElement(By.Id("first-name")));
        }

        public void AddInfo()
        {
            WaitforPageLoad(WebDriver);
            FirstName.SendKeys("TestFirstName");
            LastName.SendKeys("TestLastName");
            PostalCode.SendKeys("9000");
            Continue.Click();
        }

        #endregion
    }
}
