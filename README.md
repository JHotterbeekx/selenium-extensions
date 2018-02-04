# selenium-extensions
This package contains various extension methods for the Selenium.Webdriver NuGet package to make interacting with the browser easier and more natural.

# Installation

Add the NuGet package 'Selenium.Extensions' to your solution and you are ready to go.

# Extensions
There are extensions at different kind of levels available to use.

## RemoteWebDriver
These extensions give extra functionality to the driver.

### WaitForElementToShow
This method waits for an element to be visible on your page. You can specify the timeout yourself, which defaults to 2 seconds.

```cs
_Driver.WaitForElementToShow(By.Id("waitForElementToShowDelay"), 5);
```

### WaitForElementToDisappear
This method waits for an element to be gone from your page. You can specify the timeout yourself, which defaults to 2 seconds.

```cs
_Driver.WaitForElementToDisappear(By.Id("waitForElementToDisappearDelay"), 5);
```

## SearchContext
These extensions give extra functionality to classes that implement ISearchContext.

### FindElementIfExists
This method tries to locate the element. If the element is not found, instead of throwing an exception the value NULL is returned.

```cs
_Driver.FindElementIfExists(By.Id("elementToFind"));
```

## WebElement
These extensions give extra functionality to the WebElement object.

### InnerHtml
This method returns the HTML that is inside the specified element as string.

```cs
_Driver.FindElementIfExists(By.Id("elementToFind")).InnerHtml();
```

### OuterHtml
This method returns the full HTML of the element, including its own tag.

```cs
_Driver.FindElementIfExists(By.Id("elementToFind")).OuterHtml();
```

### Class
This method returns classes of the element, as one string.

```cs
_Driver.FindElementIfExists(By.Id("elementToFind")).Class();
```

### HasClass
This method returns true if the specified class exists on the element, or false when it doesn't.

```cs
_Driver.FindElementIfExists(By.Id("elementToFind")).HasClass("class2");
```