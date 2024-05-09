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

    [Test]
    public void Click()
    {
        driver.Navigate().GoToUrl("https://www.lambdatest.com/selenium-playground/checkbox-demo");
        var element = driver.FindElement(By.Id("isAgeSelected"));
        new Actions(driver)
            .Click(element)
            .Perform();
    }

    [Test]
    public void DragAndDrop()
    {
        driver.Navigate().GoToUrl("https://www.lambdatest.com/selenium-playground/drag-and-drop-demo");
        var draggable = driver.FindElement(By.XPath("//*[@id='todrag']/span[1]"));
        var target = driver.FindElement(By.Id("mydropzone"));
        Actions action = new Actions(driver);
        action.DragAndDrop(draggable, target);
        action.Build();
        action.Perform();
    }

    [Test]
    public void ClickAndHold()
    {
        driver.Navigate().GoToUrl("https://www.lambdatest.com/selenium-playground/drag-drop-range-sliders-demo");
        var slider = driver.FindElement(By.XPath("//*[@id='slider1']/div/input"));
        Actions action = new Actions(driver);
        action.ClickAndHold(slider).
            MoveByOffset((-(int)slider.Size.Width / 2), 0).
            MoveByOffset((int)(slider.Size.Width*0.34), 0).
            Release().
            Perform();
    }

    [TearDown]
    public void TearDown()
    {
        driver.Quit();
    }
}