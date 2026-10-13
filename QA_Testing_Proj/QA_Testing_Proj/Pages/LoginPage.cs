using OpenQA.Selenium;

namespace QA_Testing_Proj.Pages;

public class LoginPage
{
    private readonly IWebDriver _driver;
    private const string Url = "https://www.saucedemo.com/";
 
    // Locators
    private By UsernameInput => By.Id("user-name");
    private By PasswordInput => By.Id("password");
    private By LoginButton => By.Id("login-button");
    private By ErrorMessage => By.CssSelector("[data-test='error']");
 
    public LoginPage(IWebDriver driver)
    {
        _driver = driver;
    }
 
    // Helper methods 
    private void Type(By locator, string text)
    {
        var element = _driver.FindElement(locator);
        element.Clear();
        element.SendKeys(text);
    }
 
    private void Click(By locator)
    {
        _driver.FindElement(locator).Click();
    }
 
    // Page's public actions
    public LoginPage Open()
    {
        _driver.Navigate().GoToUrl(Url);
        return this;
    }
 
    public LoginPage EnterUsername(string username)
    {
        Type(UsernameInput, username);
        return this;
    }
 
    public LoginPage EnterPassword(string password)
    {
        Type(PasswordInput, password);
        return this;
    }
 
    public void ClickLogin()
    {
        Click(LoginButton);
    }
 
    public void Login(string username, string password)
    {
        EnterUsername(username);
        EnterPassword(password);
        ClickLogin();
    }
 
    // Checking
    public string GetErrorMessage() => _driver.FindElement(ErrorMessage).Text;
 
    public bool IsErrorDisplayed() => _driver.FindElements(ErrorMessage).Count > 0;
}

