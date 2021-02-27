using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;
using System;
using System.Configuration;
using System.Threading;

namespace BDD_SeleniumSpecflow.PageObjects
{
    
    public class LoginPage : SauceDemo
    {
        #region WebElement

        [FindsBy(How = How.Id, Using = "user-name")]
        public IWebElement UserName { get; set; }

        [FindsBy(How = How.Id, Using = "password")]
        public IWebElement Password { get; set; }

        [FindsBy(How = How.Id, Using = "login-button")]
        public IWebElement Submit { get; set; }

        [FindsBy(How = How.ClassName, Using = "error-button")]
        public IWebElement ErrorButton { get; set; }

        #endregion

        #region HelperMethod
        IWebDriver WebDriver = SauceDemo.WebDriver ;

        public LoginPage()
        {
            PageFactory.InitElements(WebDriver, this);
        }

        public void WaitforPageLoad()
        {
           WebDriverWait wait = new WebDriverWait (WebDriver, TimeSpan.FromSeconds(60));
            wait.Until(x=> x.FindElement(By.Id("login-button")));
        }

        
        public void Login()
        {
            WaitforPageLoad();
            Thread.Sleep(1000);
            UserName.SendKeys("standard_user");
            Password.SendKeys("secret_sauce");
            Submit.Submit();
            ProductPage.WaitforPageLoad(WebDriver);
        }

        public void ValidateInvalidLogin()
        {
            WaitforPageLoad();
            Thread.Sleep(1000);
            UserName.SendKeys("standard_user1");
            Password.SendKeys("secret_sauce");
            Submit.Submit();
            //ProductPage.WaitforPageLoad(WebDriver);
            var errorButtons = WebDriver.FindElements(By.ClassName("error-button"));
            Assert.AreEqual(errorButtons.Count,1);

        }
        #endregion
    }
}
