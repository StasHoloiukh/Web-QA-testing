using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using QA_Testing_Proj.Pages;

namespace QA_Testing_Proj.Tests;

public class LoginTests
{
    private IWebDriver _driver;
    private LoginPage _loginPage;

    [SetUp]
    public void SetUp()
    {
        _driver = new ChromeDriver();
        _driver.Manage().Window.Maximize();
        _loginPage = new LoginPage(_driver);
        _loginPage.Open();
    }

    [TearDown]
    public void TearDown()
    {
        _driver.Quit();
        _driver.Dispose();
    }

    [Test]
    public void Login_WithValidCredentials_RedirectsToProductsPage()
    {
        _loginPage.Login("standard_user", "secret_sauce");

        Assert.That(_driver.Url, Does.Contain("inventory.html"));
    }

    [Test]
    public void Login_WithInvalidPassword_ShowsErrorMessage()
    {
        _loginPage.Login("standard_user", "wrong_password");

        Assert.Multiple(() =>
        {
            Assert.That(_loginPage.IsErrorDisplayed(), Is.True);
            Assert.That(_loginPage.GetErrorMessage(),
                    Does.Contain("Username and password do not match"));
            Assert.That(_driver.Url, Does.Not.Contain("inventory.html"));
        });
        }
    }
