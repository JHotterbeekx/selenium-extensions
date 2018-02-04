using System.IO;
using FluentAssertions;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace SeleniumExtensions.Tests {
  [TestFixture]
  public class SearchContextExtensionsTests {

    private ChromeDriver _Driver;

    [OneTimeSetUp]
    public void OneTimeSetup() {
      _Driver = new ChromeDriver();
      var workingDirectory = Path.GetDirectoryName(typeof(WebElementExtensionsTests).Assembly.Location);
      _Driver.Navigate().GoToUrl($"file:///{workingDirectory}/TestPages/SearchContextExtensionsTests.html");
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
    public void FindElementIfExists_ShouldReturnElement_WhenElementExists() {
      _Driver.FindElementById("root").FindElementIfExists(By.Id("testElementFindElementIfExists")).Should().NotBeNull();
    }

    [Test]
    public void FindElementIfExists_ShouldReturnNull_WhenElementExists() {
      _Driver.FindElementById("root").FindElementIfExists(By.Id("NonExistingElement")).Should().BeNull();
    }
  }
}