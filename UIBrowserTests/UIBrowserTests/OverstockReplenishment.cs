using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;
using System.Threading.Tasks;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium;
using System.Text.RegularExpressions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UIBrowserTests
{
    class Login
    {
        public Login()
        {
            PageFactory.InitElements(PropertiesCollection.driver, this);
        }
        [FindsBy(How = How.Id, Using = "username")]
        IWebElement username { get; set; }

        [FindsBy(How = How.Id, Using = "password")]
        IWebElement password { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@id="login"]/form/p[3]/input")]
        IWebElement submitbutton { get; set; }   
        public void ClickLogin()
        {
            username.EnterText("smailavaram");
            password.EnterText("Transform2992?")
            submitbutton.Clicks();
                     
        }      
      
    }

}
