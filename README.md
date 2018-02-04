## selenium-extensions
This package contains various extension methods for the Selenium.Webdriver NuGet package to make interacting with the browser easier and more natural.

## Installation

Add the NuGet package 'Selenium.Extensions' to your solution and you are ready to go.

## Extensions
There are extensions at different kind of levels available to use.

## RemoteWebDriver
These extensions give extra functionality to the driver.

# WaitForElementToShow
This method waits for an element to be visible on your page. You can specify the timeout yourself, which defaults to 2 seconds.

```cs
_Driver.WaitForElementToShow(By.Id("waitForElementToShowDelay"), 5); // The element should be visible within 5 seconds
```

# WaitForElementToDisappear
This method waits for an element to be gone from your page. You can specify the timeout yourself, which defaults to 2 seconds.

```cs
_Driver.WaitForElementToDisappear(By.Id("waitForElementToDisappearDelay"), 5); // The element should be gone within 5 seconds
```