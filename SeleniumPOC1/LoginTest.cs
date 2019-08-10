using System;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.IE;
using OpenQA.Selenium.Support.UI;

namespace SeleniumPOC
{
    
    [TestClass]   
    public class LoginTest: TestBase
    {
           
        /// <summary>
        /// Tests a successfull login function
        /// </summary>
        [TestMethod]
        public void SuccessfullLogin()
        {

            //Navigates to login screen
            driver.Navigate().GoToUrl(appURL+"/login");

            //Types in username and password
            driver.FindElement(By.Id("username")).SendKeys("");
            driver.FindElement(By.Id("password")).SendKeys("");
            driver.FindElement(By.XPath("/html/body/app-root//button")).Click();

            //Waits for login
            var wait = new WebDriverWait(driver, new TimeSpan(0, 0, 30));
            wait.Until(wt => wt.FindElement(By.XPath("/html/body/app-root/div/")));

            // Tests if url has changed to account summary
            Assert.IsTrue(driver.Url.Contains(""));
        }

        /// <summary>
        /// Tests an unsuccessfull login function
        /// </summary>
        [TestMethod]
        public void UnSuccessfullLogin()
        {

            //Navigates to login screen
            driver.Navigate().GoToUrl(appURL + "/login");

            //Types in username and password
            driver.FindElement(By.Id("username")).SendKeys("");
            driver.FindElement(By.Id("password")).SendKeys("");
            driver.FindElement(By.XPath("/html/body/app-root/div//button")).Click();

            //Waits for unsuccessfull login messagbox to appear login
            var wait = new WebDriverWait(driver, new TimeSpan(0, 0, 30));
            wait.Until(wt => wt.FindElement(By.XPath("//*[@id='mat-dialog-1']")));

            // Tests if url does not change
            Assert.IsFalse(driver.Url.Contains("Lumin8.Agent"));
        }

        /// <summary>
        /// Method for successfull login. Use it to test for further steps
        /// </summary>
        public void Login()
        {
            driver.Navigate().GoToUrl(appURL + "/login");
            driver.FindElement(By.Id("username")).SendKeys("");
            driver.FindElement(By.Id("password")).SendKeys("");
            driver.FindElement(By.XPath("/html/body/app-root/div/div/div/form/button")).Click();
            var wait = new WebDriverWait(driver, new TimeSpan(0, 0, 30));
            wait.Until(wt => wt.FindElement(By.XPath("/html/body/app-root/div/div/app-nav-menu/div")));
        }

        /// <summary>
        /// Initialises the test environment
        /// </summary>
        [TestInitialize()]
        public void SetupTest()
        {
           
        }

        /// <summary>
        /// Cleans up the test environment and closes the browser
        /// </summary>
        [TestCleanup()]
        public void CleanupTest()
        {
            driver.Quit();
        }
    }
}
