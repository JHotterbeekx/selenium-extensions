using System.Linq;
using OpenQA.Selenium;

namespace SeleniumExtensions {
  public static class WebElementExtensions {

    public static string InnerHtml(this IWebElement element) {
      return element.GetAttribute("innerHTML");
    }

    public static string OuterHtml(this IWebElement element) {
      return element.GetAttribute("outerHTML");
    }

    public static string InnerText(this IWebElement element) {
      return element.GetAttribute("innerText");
    }

    public static string Class(this IWebElement element) {
      return element.GetAttribute("class");
    }

    public static bool HasClass(this IWebElement element, string className) {
      return element.GetAttribute("class")?.Split(' ').Contains(className) ?? false;
    }

  }
}