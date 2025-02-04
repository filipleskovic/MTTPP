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
    public class Test4
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
        public void The4Test()
        {
            driver.Navigate().GoToUrl(baseURL + "chrome://newtab/");
            driver.Navigate().GoToUrl("https://www.ferit.unios.hr/");
            driver.FindElement(By.XPath("//div[@id='pocetna']/div/div/div[2]/div/a/div/h3")).Click();
            driver.FindElement(By.LinkText("starija objava >>")).Click();
            driver.FindElement(By.LinkText("starija objava >>")).Click();
            driver.FindElement(By.LinkText("<< novija objava")).Click();
            driver.FindElement(By.XPath("//img[contains(@src,'https://www.ferit.unios.hr/2021/img/ferit-logo.png')]")).Click();
            driver.FindElement(By.XPath("//div[@id='pocetna']/div/div/div[3]/div/a/div/h3")).Click();
            driver.FindElement(By.LinkText("starija objava >>")).Click();
            driver.FindElement(By.XPath("//img[contains(@src,'https://www.ferit.unios.hr/2021/img/ferit-logo.png')]")).Click();
            driver.FindElement(By.XPath("//img[contains(@src,'https://www.ferit.unios.hr/2021/img/Arrow-down.svg')]")).Click();
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
