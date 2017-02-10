using OpenQA.Selenium.Chrome;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium.IE;
using OpenQA.Selenium.Firefox;
using System.Threading;

namespace UIBrowserTests
{
   [TestClass]
    public class InternalTests
    {
        private string _url, _browser,_driverPath;        
        [TestInitialize]
        public void Initialize()        
        { 
            _browser=System.Configuration.ConfigurationManager.AppSettings["browser"];
            _driverPath = System.Configuration.ConfigurationManager.AppSettings["WebDriverPath"]; 

            switch (_browser)
                {
                    case "IE":
                        PropertiesCollection.driver = new InternetExplorerDriver(_driverPath);
                        break;
                    case "Chrome":
                        PropertiesCollection.driver = new ChromeDriver(_driverPath);
                        break;
                    case "Firefox":
                        PropertiesCollection.driver = new FirefoxDriver();
                        break;
                    default:
                        break;
                }
           
            _url=System.Configuration.ConfigurationManager.AppSettings["url"];
            PropertiesCollection.driver.Navigate().GoToUrl(@_url);
            Thread.Sleep(200);            
        }       
       
        public void ExecuteLogin()
        {
            Login login = new Login();
            login.ClickLogin();          

        }

        [TestMethod]
        public void LeftPanelElementsEnabledTest()
        {
            ExecuteLogin();
            Thread.Sleep(1000);
            LeftPanel lp = new LeftPanel();
            lp.CheckElements();
        }

        [TestMethod]
        public void OneWeekElementClickedTest()
        {
            ExecuteLogin();
            Thread.Sleep(5000);
            LeftPanel lp = new LeftPanel();
            RightUpperPanel up = new RightUpperPanel();       
            lp.ClickOneWeekElement();
            Thread.Sleep(1000);
            up.VerifyElements();
        }

        [TestMethod]
        public void TwoDayElementClickedTest()
        {
            ExecuteLogin();
            Thread.Sleep(1000);
            LeftPanel lp = new LeftPanel();
            RightUpperPanel up = new RightUpperPanel();
            lp.ClickTwoDayElement();
            Thread.Sleep(1000);
            up.VerifyTwoDaysElements();
        }

        [TestMethod]
        public void LinkExistenceTest()
        {
            ExecuteLogin();
            Thread.Sleep(1000);
            LeftPanel lp = new LeftPanel();
            RightMiddlePanel up = new RightMiddlePanel();
            lp.ClickTwoDayElement();
            Thread.Sleep(1000);
            up.VerifyElements();
        }

        [TestMethod]
        public void MapPopupTest()
        {
            ExecuteLogin();
            Thread.Sleep(6000);
            LeftPanel lp = new LeftPanel();
            MapPage mp = new MapPage();
            mp.VerifyElements();
        }

        [TestMethod]
        public void CourierLanesPage()
        {
            ExecuteLogin();
            Thread.Sleep(6000);
            LeftPanel lp = new LeftPanel();
            CourierLanesPage mp = new CourierLanesPage();            
            mp.VerifyElements();
        }

        [TestCleanup]
        public void TearDown()
        {       
            PropertiesCollection.driver.Close();
            PropertiesCollection.driver.Quit();
        }
    }
}