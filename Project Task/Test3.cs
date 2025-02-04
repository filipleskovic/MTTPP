using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;

namespace SeleniumTests
{
    [TestFixture]
    public class Test3
    {
        private IWebDriver driver;
        private StringBuilder verificationErrors;
        private string baseURL;
        private bool acceptNextAlert = true;

        [SetUp]
        public void SetupTest()
        {
            driver = new FirefoxDriver();
            baseURL = "https://www.google.com/";
            verificationErrors = new StringBuilder();
        }

        [TearDown]
        public void TeardownTest()
        {
            try
            {
                driver.Quit();
                driver.Dispose();
            }
            catch (Exception)
            {
                // Ignore errors if unable to close the browser
            }
            Assert.AreEqual("", verificationErrors.ToString());
        }

        [Test]
        public void The3Test()
        {
            driver.Navigate().GoToUrl(baseURL + "chrome://newtab/");
            driver.Navigate().GoToUrl("https://www.ferit.unios.hr/");
            driver.FindElement(By.XPath("//img[contains(@src,'https://www.ferit.unios.hr/2021/img/youtube-6.svg')]")).Click();
            driver.Navigate().GoToUrl("https://www.youtube.com/user/TvUnios");
            // ERROR: Caught exception [ERROR: Unsupported command [selectWindow | win_ser_1 | ]]
            // ERROR: Caught exception [ERROR: Unsupported command [selectWindow | win_ser_local | ]]
            driver.Navigate().GoToUrl("https://www.ferit.unios.hr/");
            driver.FindElement(By.XPath("//img[contains(@src,'https://www.ferit.unios.hr/2021/img/instagram-11.svg')]")).Click();
            driver.Navigate().GoToUrl("https://www.instagram.com/ferit.osijek/");
            // ERROR: Caught exception [ERROR: Unsupported command [selectWindow | win_ser_2 | ]]
            // ERROR: Caught exception [ERROR: Unsupported command [selectWindow | win_ser_local | ]]
            driver.Navigate().GoToUrl("https://www.ferit.unios.hr/");
            driver.FindElement(By.XPath("//img[contains(@src,'https://www.ferit.unios.hr/2021/img/facebook-svgrepo-com.svg')]")).Click();
            // ERROR: Caught exception [ERROR: Unsupported command [selectWindow | win_ser_3 | ]]
            driver.Navigate().GoToUrl("https://www.facebook.com/FERIT.Osijek");
            // ERROR: Caught exception [ERROR: Unsupported command [selectWindow | win_ser_local | ]]
            driver.Navigate().GoToUrl("https://www.ferit.unios.hr/");
            driver.FindElement(By.LinkText("English")).Click();
            driver.FindElement(By.LinkText("Croatian")).Click();
        }
        private bool IsElementPresent(By by)
        {
            try
            {
                driver.FindElement(by);
                return true;
            }
            catch (NoSuchElementException)
            {
                return false;
            }
        }

        private bool IsAlertPresent()
        {
            try
            {
                driver.SwitchTo().Alert();
                return true;
            }
            catch (NoAlertPresentException)
            {
                return false;
            }
        }

        private string CloseAlertAndGetItsText()
        {
            try
            {
                IAlert alert = driver.SwitchTo().Alert();
                string alertText = alert.Text;
                if (acceptNextAlert)
                {
                    alert.Accept();
                }
                else
                {
                    alert.Dismiss();
                }
                return alertText;
            }
            finally
            {
                acceptNextAlert = true;
            }
        }
    }
}
