using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium;


namespace UIBrowserTests
{
    
    class Login
    {
        private string _username, _password;
         
        public Login()
        {
            PageFactory.InitElements(PropertiesCollection.driver, this);
        }
        [FindsBy(How = How.Id, Using = "username")]
        IWebElement username { get; set; }

        [FindsBy(How = How.Id, Using = "password")]
        IWebElement password { get; set; }

        [FindsBy(How = How.XPath, Using = "//input[@value='Log in']")]
        IWebElement submitbutton { get; set; }   
        public void ClickLogin()
        { 
            _username=System.Configuration.ConfigurationManager.AppSettings["LoginId"];
            _password = System.Configuration.ConfigurationManager.AppSettings["Password"]; 
            username.EnterText(_username);
            password.EnterText(_password);
            submitbutton.Clicks();      
                       
        }      
      
    }

}
