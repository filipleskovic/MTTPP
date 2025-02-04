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
    public class Test5
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
    public void The5Test()
    {
        driver.Navigate().GoToUrl(baseURL + "chrome://newtab/");
        driver.Navigate().GoToUrl("https://www.ferit.unios.hr/");
        driver.FindElement(By.LinkText("Raspored")).Click();
        driver.FindElement(By.LinkText("1.g. PI")).Click();
        driver.FindElement(By.LinkText("⇦")).Click();
        driver.FindElement(By.LinkText("⇦")).Click();
        driver.FindElement(By.LinkText("Sveučilišni prijediplomski studij Računarstvo -> 1. godina PI")).Click();
        driver.FindElement(By.LinkText("3.g.")).Click();
        driver.FindElement(By.LinkText("⇨")).Click();
        driver.FindElement(By.LinkText("⇨")).Click();
        driver.FindElement(By.Id("kalendar-nastave")).Click();
        driver.FindElement(By.XPath("//a[@id='kalendar-nastave']/img")).Click();
        driver.FindElement(By.XPath("//div[@id='header-kategorija']/div/h2")).Click();
        driver.FindElement(By.XPath("//div[@id='header-kategorija']/div/div/a[4]")).Click();
        driver.FindElement(By.XPath("//img[contains(@src,'https://www.ferit.unios.hr/2021//img/tekstovi/58/1620653018_stup-logo13.png')]")).Click();
        // ERROR: Caught exception [ERROR: Unsupported command [selectWindow | win_ser_1 | ]]
        driver.Navigate().GoToUrl("https://stup.ferit.hr/");
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
