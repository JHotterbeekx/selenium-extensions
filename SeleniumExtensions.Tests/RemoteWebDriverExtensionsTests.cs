using System;
using System.Diagnostics;
using System.IO;
using FluentAssertions;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;

namespace SeleniumExtensions.Tests {
  [TestFixture]
  public class RemoteWebDriverExtensionsTests {
    private ChromeDriver _Driver;

    [OneTimeSetUp]
    public void OneTimeSetup() {
      _Driver = new ChromeDriver();
      var workingDirectory = Path.GetDirectoryName(typeof(WebElementExtensionsTests).Assembly.Location);
      _Driver.Navigate().GoToUrl($"file:///{workingDirectory}/TestPages/RemoteWebDriverExtensionsTests.html");
    }

    [OneTimeTearDown]
    public void OneTimeTearDown() {
      _Driver.Close();
      _Driver.Dispose();
    }

    [SetUp]
    public void Setup() {
      _Driver.Navigate().Refresh();
    }

    [Test]
    public void WaitForElementToShow_ShouldWaitForElementToShow_WhenElementShowsWithDelay() {
      _Driver.FindElementById("waitForElementToShowDelayTrigger").Click();
      _Driver.WaitForElementToShow(By.Id("waitForElementToShowDelay"), 2);
    }

    [Test]
    public void WaitForElementToShow_ShouldThrow_WhenElementTakesTooLongToShow() {
      _Driver.FindElementById("waitForElementToShowTooLongDelayTrigger").Click();
      Action action = () => _Driver.WaitForElementToShow(By.Id("waitForElementToShowTooLongDelay"), 2);
      action.ShouldThrow<WebDriverTimeoutException>();
    }

    [Test]
    public void WaitForElementToShow_ShouldNotWait_WhenElementInstantlyShows() {
      var stopwatch = new Stopwatch();
      stopwatch.Start();
      _Driver.FindElementById("waitForElementToShowNoDelayTrigger").Click();
      _Driver.WaitForElementToShow(By.Id("waitForElementToShowNoDelay"));
      stopwatch.Stop();
      stopwatch.ElapsedMilliseconds.Should().BeLessOrEqualTo(200);
    }
  }
}