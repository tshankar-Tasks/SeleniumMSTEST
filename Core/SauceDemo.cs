using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.IE;
using OpenQA.Selenium.Chrome;
using System.Configuration;
using BDD_SeleniumSpecflow.PageObjects;


namespace BDD_SeleniumSpecflow
{

    public class SauceDemo 
    {
        public static IWebDriver WebDriver = Start();
        public static InternetExplorerOptions InternetExplorerOptions;
        public static ChromeOptions ChromeOptions;

        //Initialise the PageObjects
        public static LoginPage LoginPage = new LoginPage();
        public static Cart Cart = new Cart();
        public static CheckoutInfo CheckoutInfo = new CheckoutInfo();
        public static CheckoutOverview CheckoutOverview = new CheckoutOverview();
        public static Finish Finish = new Finish();
        public static ProductPage ProductPage = new ProductPage();
        public static SliderMenu SliderMenu = new SliderMenu();
        public static ProductDescPage ProductDescPage = new ProductDescPage();
        

        public enum BrowserName
        {
            IE = 0,
            Chrome = 1,
            Edge = 2,
            Firefox = 3
        }
        public static BrowserName GetBrowserName()
        {
            string ConfigName;
            ConfigName = ConfigurationManager.AppSettings["BrowserName"];
            switch (ConfigName)
            {
                case "Edge":
                    return BrowserName.Edge;
                case "Chrome":
                    return BrowserName.Chrome;
                default:
                    return BrowserName.IE;
            }

        }
        public static IWebDriver Start(bool cleanSession = true)
        {
           //KillBrowserInstance();

            switch (GetBrowserName())
            {
                case BrowserName.IE:
                    InternetExplorerOptions = WebDriverOptions.GetIEOptions(cleanSession);
                    WebDriver = new InternetExplorerDriver(InternetExplorerOptions);
                    break;
                case BrowserName.Chrome:
                    ChromeOptions = WebDriverOptions.GetChromeOptions();
                    WebDriver = new ChromeDriver(ChromeOptions);
                    break;
                //case BrowserName.Edge:
                //    LaunchBrowser<EdgeDriver>();
                //    break;
                //case BrowserName.Firefox:
                //    LaunchBrowser<FirefoxDriver>();
                //    break;
            }

            WebDriver.Manage().Window.Maximize();
            WebDriver.Navigate().GoToUrl(ConfigurationManager.AppSettings["EnvironmentURL"]);
            return WebDriver;
        }

        public static void Quit()
        {
            if (WebDriver != null)
            {
                WebDriver.Quit();
            }
        }

        public static void Close()
        {
            if (WebDriver != null)
            {
                WebDriver.Close();
            }
        }

        public class WebDriverOptions
        {
            public static InternetExplorerOptions GetIEOptions(bool cleanSession, bool requireWindowFocus = false)
            {
                return new InternetExplorerOptions()
                {
                    EnsureCleanSession = cleanSession,
                    UnhandledPromptBehavior = UnhandledPromptBehavior.Ignore,
                    // UnexpectedAlertBehavior = InternetExplorerUnexpectedAlertBehavior.Ignore,
                    IntroduceInstabilityByIgnoringProtectedModeSettings = true,
                    IgnoreZoomLevel = true,
                    RequireWindowFocus = requireWindowFocus,
                    //EnableNativeEvents=false,
                };
            }

            public static ChromeOptions GetChromeOptions()
            {
                var opt = new ChromeOptions();

                opt.AddArguments("chrome.switches", "--disable-extensions");
                opt.AddArguments("chrome.switches", "--enable-precache");
                //opt.AddAdditionalCapability(CapabilityType.UnexpectedAlertBehavior, "ignore");
                return opt;
            }


            //public static FirefoxOptions GetFirefoxOptions(bool cleanSession)
            //{
            //    return new FirefoxOptions()
            //    {
            //    };
            //}

            //public static EdgeOptions GetEdgeOptions()
            //{
            //    var opt = new EdgeOptions();
            //    //opt.AddAdditionalCapability(CapabilityType.UnexpectedAlertBehavior, "ignore");
            //    return opt;
            //}


        }

    }
}
