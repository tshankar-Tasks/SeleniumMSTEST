using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;

namespace BDD_SeleniumSpecflow.PageObjects
{
    [TestClass]
    public class Finish
    {
        #region WebElement

        [FindsBy(How = How.ClassName, Using = "complete-header")]
        public IWebElement ThanksNote { get; set; }

        [FindsBy(How = How.ClassName, Using = "complete-text")]
        public IWebElement DispatchText { get; set; }

        #endregion WebElement


        #region Helper
        IWebDriver WebDriver = SauceDemo.WebDriver;

        public Finish()
        {
            PageFactory.InitElements(WebDriver, this);
        }

        public static void WaitforPageLoad(IWebDriver webDriver)
        {
            WebDriverWait wait = new WebDriverWait(webDriver, TimeSpan.FromSeconds(60));
            wait.Until(x => x.FindElement(By.ClassName("complete-header")));
        }

        public void ValidateTransactionComplete()
        {
            WaitforPageLoad(WebDriver);
            Assert.AreEqual("THANK YOU FOR YOUR ORDER", ThanksNote.Text.Trim());
        }
        #endregion
    }
}
