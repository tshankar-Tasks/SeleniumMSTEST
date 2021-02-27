using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;

namespace BDD_SeleniumSpecflow.PageObjects
{
    [TestClass]
    public class ProductPage
    {
        #region WebElement

        [FindsBy(How = How.ClassName, Using = "product_sort_container")]
        public IWebElement SelectSortType { get; set; }

        [FindsBy(How = How.Id, Using = "shopping_cart_container")]
        public IWebElement Cart { get; set; }

        [FindsBy(How = How.Id, Using = "react-burger-menu-btn")]
        public IWebElement Menu { get; set; }
        #endregion


        #region Helper
        IWebDriver WebDriver = SauceDemo.WebDriver;

        public ProductPage()
        {
            PageFactory.InitElements(WebDriver, this);
        }

        public static void WaitforPageLoad(IWebDriver webDriver)
        {
            WebDriverWait wait = new WebDriverWait(webDriver, TimeSpan.FromSeconds(60));
            wait.Until(x => x.FindElement(By.Id("shopping_cart_container")));
        }

        public void NavigatetoCart()
        {
            WaitforPageLoad(WebDriver);
            Cart.Click();
        }

        public void NavigatetoMenu()
        {
            WaitforPageLoad(WebDriver);
            Menu.Click();
        }

        #endregion
    }
}
