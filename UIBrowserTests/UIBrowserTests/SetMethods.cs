using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
namespace UIBrowserTests
{
    public static class SetMethods
    {
        //Entering Text into a Textbox
        public static void EnterText(this IWebElement element, string value)
        {
            element.SendKeys(value);
        }

        //Pressing Enter Key
        public static void Enter(this IWebElement element)
        {
            element.SendKeys(Keys.Enter);
        }

        //Selecting a drop down control
        public static void SelectDropDown(this IWebElement element, string value)
        {
        
                new SelectElement(element).SelectByText(value);
           
        }
        //Clicking an element
        public static void Clicks(this IWebElement element)
        {
            element.Click();
            
           
        }
        //To Check if an element is displayed
        public static void Displayed(this IWebElement element)
        {
            if (element.Displayed)
            {
                Console.WriteLine("element is displayed");
            }
            else
            {
                Console.WriteLine("element is not displayed");
            }
        }
       
    }
}
