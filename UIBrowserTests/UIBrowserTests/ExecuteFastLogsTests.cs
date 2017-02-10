using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TestStack.White.Bricks;
using TestStack.White;
using System.Configuration;
using TestStack.White.UIItems.WindowItems;
using TestStack.White.UIItems.Finders;
using System.Data;
using System.Threading;

namespace UITests
{
    [TestClass()]
    class ExecuteFastLogsTests
    {
        private string _loginusername,_loginpassword,_applicationlocation;
        Application application;
        [TestInitialize()]
        public void Initialize()
        {
            _loginusername = System.Configuration.ConfigurationManager.AppSettings["LoginId"];
            _loginpassword = System.Configuration.ConfigurationManager.AppSettings["Password"];
            _applicationlocation = System.Configuration.ConfigurationManager.AppSettings["application"];
            application = Application.Launch(@_applicationlocation);             
        }
          [TestMethod()]
        public void Login()
        {
            Window GRSIFastTrakLogistics = application.GetWindow("GRSI FastTrak Logistics");
            Window LogOntoGRSIFastTrakLogistics = GRSIFastTrakLogistics.ModalWindow("Log On to GRSI FastTrak Logistics");
            var _userName = LogOntoGRSIFastTrakLogistics.Get(SearchCriteria.ByAutomationId("txtUsername"));
            _userName.Enter("leek");
            var _Password = LogOntoGRSIFastTrakLogistics.Get(SearchCriteria.ByAutomationId("txtPassword"));
            _Password.Enter("leek237");
            var _button = LogOntoGRSIFastTrakLogistics.Get(SearchCriteria.ByAutomationId("btnOK"));
            _button.Click();        

        }     
       
    }

}
