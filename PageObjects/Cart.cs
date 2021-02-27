using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;
using BDD_SeleniumSpecflow.PageObjects;
using System;
using System.Collections.Generic;

namespace BDD_SeleniumSpecflow.PageObjects
{

    public class Cart : SauceDemo
    {

        #region WebElement

        [FindsBy(How = How.ClassName, Using = "checkout_button")]
        public IWebElement Checkout { get; set; }

        [FindsBy(How = How.ClassName, Using = "btn_secondary")]
        public IWebElement ContinueShopping { get; set; }

        #endregion

        #region Helper
        IWebDriver WebDriver = SauceDemo.WebDriver;

        public Cart()
        {
            PageFactory.InitElements(WebDriver, this);
        }

        public static void WaitforPageLoad(IWebDriver webDriver)
        {
            WebDriverWait wait = new WebDriverWait(webDriver, TimeSpan.FromSeconds(60));
            wait.Until(x => x.FindElement(By.ClassName("checkout_button")));
        }

        public void VerifyCart(List<string> ItemAdded)
        {
            WaitforPageLoad(WebDriver);
            VerifyCartItem(ItemAdded);
            Checkout.Click();
        }

        public void VerifyCartItem(List<string> ItemAdded)
        {
            var totalCartItems = WebDriver.FindElements(By.ClassName("cart_item"));
            if (totalCartItems.Count > 0)
            {
                if (totalCartItems.Count == ItemAdded.Count)
                    Assert.IsTrue(true);
                else
                    Assert.IsFalse(false);
                
                var allItemName = WebDriver.FindElements(By.ClassName("inventory_item_name"));
                foreach (string item in ItemAdded)
                    foreach (IWebElement x in allItemName)
                    {
                        if(x.Text == item)
                        {
                            Assert.IsTrue(true);
                            break;
                        }
                    }
            }
        }

        #endregion

    }
}
