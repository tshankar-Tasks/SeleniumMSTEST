using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;

namespace BDD_SeleniumSpecflow.PageObjects
{
    public class ProductDescPage
    {

        #region WebElement

        [FindsBy(How = How.ClassName, Using = "btn_primary")]
        public IWebElement AddToCart { get; set; }

        [FindsBy(How = How.ClassName, Using = "inventory_details_back_button")]
        public IWebElement Back { get; set; }

        #endregion


        #region Helper
        IWebDriver WebDriver = SauceDemo.WebDriver;

        public ProductDescPage()
        {
            PageFactory.InitElements(WebDriver, this);
        }

        public static void WaitforPageLoad(IWebDriver webDriver)
        {
            WebDriverWait wait = new WebDriverWait(webDriver, TimeSpan.FromSeconds(60));
            wait.Until(x => x.FindElement(By.ClassName("btn_primary")));
        }

        public void AddItemsToCart(List<string> ItemName)
        {
            ProductPage.WaitforPageLoad(WebDriver);

            var AllCartElement = WebDriver.FindElements(By.ClassName("inventory_item_name"));

            foreach (IWebElement item in AllCartElement)
            {
                foreach (string name in ItemName)
                    if (item.Text == name)
                    {
                        item.Click();
                        WaitforPageLoad(WebDriver);
                        AddToCart.Click();
                        Back.Click();
                        break;
                    }
            }
        }

        #endregion
    }
}
