using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium.Support.UI;

namespace SeleniumExtensions {
  public static class RemoteWebDriverExtensions {

    public static RemoteWebDriver WaitForElementToShow(this RemoteWebDriver browser, By selector, int seconds = 2) {
      new WebDriverWait(browser, TimeSpan.FromSeconds(seconds)).Until(ExpectedConditions.ElementIsVisible(selector));
      return browser;
    }

  }
}