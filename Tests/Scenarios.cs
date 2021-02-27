using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.IE;
using OpenQA.Selenium.Chrome;
using System.Configuration;
using OpenQA.Selenium.Support.PageObjects;
using BDD_SeleniumSpecflow.PageObjects;
using BDD_SeleniumSpecflow.DataLibrary;

namespace BDD_SeleniumSpecflow.Tests
{
    [TestClass]
    public class Scenarios : SauceDemo
    {

        [TestMethod]
        public void ErroLogin()
        {
            LoginPage.ValidateInvalidLogin();
        }

        [TestMethod]
        public void CartWorkFlow()
        {
            LoginPage.Login();
            ProductDescPage.AddItemsToCart(Params.products);
            ProductPage.NavigatetoCart();
            Cart.VerifyCart(Params.products);
            CheckoutInfo.AddInfo();
            CheckoutOverview.ValidateTotal(2);
            CheckoutOverview.FinishTransaction();
            Finish.ValidateTransactionComplete();
            ProductPage.NavigatetoMenu();
            SliderMenu.LogoutApp();
        }
    }
}
