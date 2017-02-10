using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
namespace UIBrowserTests
{
    public static class GetMethods
    {
        //Getting value out from Textbox
        public static string GetText(this IWebElement element)
        {
            return element.GetAttribute("value");
        }
        //Getting value out from Dropdown List
        public static string GetTextFromDDL(this IWebElement element)
        {
            return new SelectElement(element).AllSelectedOptions.SingleOrDefault().Text;
        }
    }

}
