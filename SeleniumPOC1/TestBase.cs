using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.IE;
using OpenQA.Selenium.Support.UI;

namespace SeleniumPOC
{
    public class TestBase
    {
        public IWebDriver driver;
        public string appURL;
        public string browser;

        /// <summary>
        /// Constructor load browser
        /// </summary>
        public TestBase()
        {
            appURL = "";
            string browser = "Chrome";

            switch (browser)
            {
                case "Chrome":
                    driver = new ChromeDriver();
                    break;
                case "Firefox":
                    driver = new FirefoxDriver();
                    break;
                case "IE":
                    driver = new InternetExplorerDriver();
                    break;
                default:
                    driver = new ChromeDriver();
                    break;
            }

            driver.Navigate().GoToUrl(appURL);
            driver.Manage().Window.Maximize();
        }
        
    }
}
