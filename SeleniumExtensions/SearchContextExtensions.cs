using OpenQA.Selenium;

namespace SeleniumExtensions {
  public static class SearchContextExtensions {

    public static ISearchContext FindElementIfExists(this ISearchContext searchContext, By selector) {
      try { return searchContext.FindElement(selector); }
      catch (NoSuchElementException) { return null; }
    }

  }
}