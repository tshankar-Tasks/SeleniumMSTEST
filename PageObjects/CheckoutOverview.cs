using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;
using BDD_SeleniumSpecflow.PageObjects;
using System;


namespace BDD_SeleniumSpecflow.PageObjects
{
   
    public class CheckoutOverview
    {
        #region WebElement

        //class : cart_item_label

        [FindsBy(How = How.ClassName, Using = "cart_button")]
        public IWebElement Finish { get; set; }

        [FindsBy(How = How.ClassName, Using = "cart_cancel_link")]
        public IWebElement Cancel { get; set; }

        [FindsBy(How = How.ClassName, Using = "summary_total_label")]
        public IWebElement Total { get; set; }


        #endregion WebElement

        #region Helper
        IWebDriver WebDriver = SauceDemo.WebDriver;

        public CheckoutOverview()
        {
            PageFactory.InitElements(WebDriver, this);
        }

        public static void WaitforPageLoad(IWebDriver webDriver)
        {
            WebDriverWait wait = new WebDriverWait(webDriver, TimeSpan.FromSeconds(60));
            wait.Until(x => x.FindElement(By.ClassName("summary_total_label")));
        }

        public void ValidateTotal(int CountItem)
        {
            decimal totalPrice = 0;
            WaitforPageLoad(WebDriver);
            var AllPriceList = WebDriver.FindElements(By.ClassName("inventory_item_price"));
            if (AllPriceList.Count == CountItem)
            {
                foreach (IWebElement x in AllPriceList)
                {
                    totalPrice = totalPrice + Convert.ToDecimal(x.Text.Replace("$",""));
                }

                if (totalPrice == Convert.ToDecimal(WebDriver.FindElement(By.ClassName("summary_subtotal_label")).Text.Replace("Item total: $", "")))
                   Assert.IsTrue(true,"Total Value is same ");
            }
            else
                Assert.Fail("More than added Items");
        }

        public void FinishTransaction()
        {
            Finish.Click();
        }
        #endregion
    }
}
