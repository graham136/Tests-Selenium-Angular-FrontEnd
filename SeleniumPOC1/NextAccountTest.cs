using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.IE;
using OpenQA.Selenium.Support.UI;

namespace SeleniumPOC
{
    /// <summary>
    /// Summary description for LogoutTest
    /// </summary>
    [TestClass]
    public class NexAccountTest : LoginTest
    {
        /// <summary>
        /// Tests a successfull logout function
        /// </summary>
        [TestMethod]
        public void NexAccountSuccessfullTest()
        {

            // Does a standard successfull login
            Login();

            // Waits the NextAccount button
            var wait = new WebDriverWait(driver, new TimeSpan(0, 0, 30));
            wait.Until(wt => wt.FindElement(By.XPath("/html/body/app-root/div/div/div/div/button")));
            
            // Clicks on the NextAccount button
            driver.FindElement(By.XPath("/html/body/app-root/div//button")).Click();

            // Waits for the account summary popup to appear
            wait = new WebDriverWait(driver, new TimeSpan(0, 0, 30));
            wait.Until(wt => wt.FindElement(By.XPath("/html/body/app-root/div/div/div")));
            
            Assert.IsTrue(driver.Url.Contains(""));

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

        /// <summary>
        /// Method to for successfull nextaccount
        /// </summary>
        public void NextAccount()
        {
            driver.FindElement(By.XPath("/html/body/app-root/div/div/div/button")).Click();
        }


    }
}
