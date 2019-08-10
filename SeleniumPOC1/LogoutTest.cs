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
    public class LogoutTest : LoginTest
    {
        /// <summary>
        /// Tests a successfull logout function
        /// </summary>
        [TestMethod]
        public void LogoutSuccessfullTest()
        {

            // Does a standard successfull login
            Login();

            // Clicks on the logout button
            driver.FindElement(By.XPath("/html/body/app-root/div/div/div//button")).Click();

            // Waits for the logout message popup to appear
            var wait = new WebDriverWait(driver, new TimeSpan(0, 0, 30));
            wait.Until(wt => wt.FindElement(By.XPath("//*[@id='mat-dialog-2']/message-box/div[3]/button[2]")));

            // Clicks the ok button on logout popup
            driver.FindElement(By.XPath("//*[@id='mat-dialog-2']/message-box/div[3]/button[2]")).Click();
            
            // Waits for the login screen to load
            wait = new WebDriverWait(driver, new TimeSpan(0, 0, 30));
            wait.Until(wt => wt.FindElement(By.XPath("/html/body/app-root/div/form/button")));
            Assert.IsTrue(driver.Url.Contains("login"));

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
        /// Method for successfull logout
        /// </summary>
        public void Logout()
        {
            driver.FindElement(By.XPath("/html/body/app-root/div/div/div/div/button")).Click();
        }


    }
}
