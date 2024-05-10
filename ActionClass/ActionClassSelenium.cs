using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Remote;

namespace ActionClass;

public class ActionClassSelenium
{
    private static IWebDriver driver;
    public static string gridURL = "@hub.lambdatest.com/wd/hub";
    private static readonly string LT_USERNAME = Environment.GetEnvironmentVariable("LT_USERNAME");
    private static readonly string LT_ACCESS_KEY = Environment.GetEnvironmentVariable("LT_ACCESS_KEY");

    [SetUp]
    public void Setup()
    {
        ChromeOptions capabilities = new ChromeOptions();
        capabilities.BrowserVersion = "latest";
        Dictionary<string, object> ltOptions = new Dictionary<string, object>();
        ltOptions.Add("username", LT_USERNAME);
        ltOptions.Add("accessKey", LT_ACCESS_KEY);
        ltOptions.Add("platformName", "Windows 10");
        ltOptions.Add("build", "SeleniumCSharpActionClass");
        ltOptions.Add("project", "SeleniumCSharpActionClass");
        ltOptions.Add("w3c", true);
        ltOptions.Add("plugin", "c#-nunit");
        capabilities.AddAdditionalOption("LT:Options", ltOptions);
        driver = new RemoteWebDriver(new Uri($"https://{LT_USERNAME}:{LT_ACCESS_KEY}{gridURL}"), capabilities);
    }


    public void SetStatus(bool passed)
    {
        if (driver is not null)
        {
            if (passed)
                ((IJavaScriptExecutor)driver).ExecuteScript("lambda-status=passed");
            else
                ((IJavaScriptExecutor)driver).ExecuteScript("lambda-status=failed");
        }
    }

    [Test]
    public void Click()
    {
        try
        {
            driver.Navigate().GoToUrl("https://www.lambdatest.com/selenium-playground/checkbox-demo");
            var element = driver.FindElement(By.Id("isAgeSelected"));
            new Actions(driver)
                .Click(element)
                .Perform();
            SetStatus(true);
        }
        catch (Exception)
        {
            SetStatus(false);
            throw;
        }
    }

    [Test]
    public void DoubleClick()
    {
        try
        {
            driver.Navigate().GoToUrl("https://www.lambdatest.com/selenium-playground/checkbox-demo");
            var element = driver.FindElement(By.Id("isAgeSelected"));
            new Actions(driver)
                .DoubleClick(element)
                .Perform();
            SetStatus(true);
        }
        catch (Exception)
        {
            SetStatus(false);
            throw;
        }
    }

    [Test]
    public void ContextClick()
    {
        try
        {
            driver.Navigate().GoToUrl("https://www.lambdatest.com/selenium-playground/context-menu");
            var element = driver.FindElement(By.Id("hot-spot"));
            new Actions(driver)
                .ContextClick(element)
                .Perform();
            SetStatus(true);
        }
        catch (Exception)
        {
            SetStatus(false);
            throw;
        }
    }

    [Test]
    public void ClickAndHold()
    {
        try
        {
            driver.Navigate().GoToUrl("https://www.lambdatest.com/selenium-playground/drag-drop-range-sliders-demo");
            var slider = driver.FindElement(By.XPath("//*[@id='slider1']/div/input"));
            Actions action = new Actions(driver);
            action.ClickAndHold(slider).
                MoveByOffset((-(int)slider.Size.Width / 2), 0).
                MoveByOffset((int)(slider.Size.Width * 0.34), 0).
                Release().
                Perform();
            SetStatus(true);
        }
        catch (Exception)
        {
            SetStatus(false);
            throw;
        }
    }

    [Test]
    public void DragAndDrop()
    {
        try
        {
            driver.Navigate().GoToUrl("https://www.lambdatest.com/selenium-playground/drag-and-drop-demo");
            var draggable = driver.FindElement(By.XPath("//*[@id='todrag']/span[1]"));
            var target = driver.FindElement(By.Id("mydropzone"));
            Actions action = new Actions(driver);
            action.DragAndDrop(draggable, target);
            action.Perform();
            SetStatus(true);
        }
        catch (Exception)
        {
            SetStatus(false);
            throw;
        }
    }

    [Test]
    public void Hover()
    {
        try
        {
            driver.Navigate().GoToUrl("https://www.lambdatest.com/selenium-playground/hover-demo");
            var element = driver.FindElement(By.XPath("//div[contains(text(),'Hover Me')]"));
            new Actions(driver)
                .MoveToElement(element)
                .Perform();
            SetStatus(true);
        }
        catch (Exception)
        {
            SetStatus(false);
            throw;
        }
    }

    [Test]
    public void KeyboardActions()
    {
        try
        {
            driver.Navigate().GoToUrl("https://www.lambdatest.com/selenium-playground/simple-form-demo");
            var input = driver.FindElement(By.Id("user-message"));
            input.SendKeys("my text");
            new Actions(driver)
                .Click(input)
                .KeyDown(Keys.Control)
                .SendKeys("A")
                .KeyUp(Keys.Control)
                .Perform();
            SetStatus(true);
        }
        catch (Exception)
        {
            SetStatus(false);
            throw;
        }
    }

    [TearDown]
    public void TearDown()
    {
        driver.Quit();
    }
}