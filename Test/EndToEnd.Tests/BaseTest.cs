using System;
using EndToEnd.Tests.Infrastructure;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace EndToEnd.Tests
{
  public abstract class BaseTest
  {
    private readonly TimeSpan DefaultTimeout = TimeSpan.FromSeconds(1);

    public BaseTest(IWebDriver aWebDriver, ServerFixture aServerFixture)
    {
      WebDriver = aWebDriver;
      ServerFixture = aServerFixture;
    }

    private ServerFixture ServerFixture { get; }
    private IWebDriver WebDriver { get; }

    protected void Navigate(string aRelativeUrl, bool aReload = true)
    {
      var absoluteUrl = new Uri(ServerFixture.RootUri, aRelativeUrl);

      if (!aReload && string.Equals(WebDriver.Url, absoluteUrl.AbsoluteUri, StringComparison.Ordinal))
      {
        return;
      }

      WebDriver.Navigate().GoToUrl("about:blank");
      WebDriver.Navigate().GoToUrl(absoluteUrl);
    }

    protected void WaitUntilLoaded()
    {
      var webDriverWait = new WebDriverWait(WebDriver, TimeSpan.FromSeconds(30));

      bool loaded = webDriverWait.Until(aCondition =>
        {
          try
          {
            IWebElement noLayoutElement = WebDriver.FindElement(By.Id("NoLayout"));
            IWebElement anthemGoldLayoutElement = WebDriver.FindElement(By.Id("AnthemGoldLayout"));
            return noLayoutElement.Displayed || anthemGoldLayoutElement.Displayed;
          }
          catch (StaleElementReferenceException)
          {
            return false;
          }
          catch (NoSuchElementException)
          {
            return false;
          }
        }
      );
    }
  }
}