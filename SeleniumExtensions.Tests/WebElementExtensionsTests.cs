using System.IO;
using FluentAssertions;
using NUnit.Framework;
using OpenQA.Selenium.Chrome;

namespace SeleniumExtensions.Tests {
  [TestFixture]
  public class WebElementExtensionsTests {

    private ChromeDriver _Driver;

    [OneTimeSetUp]
    public void OneTimeSetup() {
      _Driver = new ChromeDriver();
      var workingDirectory = Path.GetDirectoryName(typeof(WebElementExtensionsTests).Assembly.Location);
      _Driver.Navigate().GoToUrl($"file:///{workingDirectory}/TestPages/WebElementExtensionsTests.html");
    }

    [SetUp]
    public void Setup() {
      _Driver.Navigate().Refresh();
    }

    [Test]
    public void InnerHtml_ShouldReturnCorrectValue() {
      _Driver.FindElementById("testElementInnerHtml").InnerHtml().Should().Be("<a href=\"https://www.google.com\">Google</a> <i>Search</i>");
    }

    [Test]
    public void OuterHtml_ShouldReturnCorrectValue() {
      _Driver.FindElementById("testElementOuterHtml").OuterHtml().Should().Be("<span id=\"testElementOuterHtml\"><i>Text</i></span>");
    }

    [Test]
    public void Class_ShouldReturnCorrectValue() {
      _Driver.FindElementById("testElementClass").Class().Should().Be("class1 class2 class3");
    }

    [Test]
    public void Class_ShouldReturnTrue_WhenClassExistsInElement() {
      _Driver.FindElementById("testElementClass").HasClass("class2").Should().BeTrue();
    }

    [Test]
    public void Class_ShouldReturnFalse_WhenClassDoesNotExistInElement() {
      _Driver.FindElementById("testElementClass").HasClass("class4").Should().BeFalse();
    }

    [Test]
    public void Class_ShouldReturnFalse_WhenStringOnlyMatchesPartOfAClassName() {
      _Driver.FindElementById("testElementClass").HasClass("class").Should().BeFalse();
    }

    [OneTimeTearDown]
    public void OneTimeTearDown() {
      _Driver.Close();
      _Driver.Dispose();
    }

  }
}