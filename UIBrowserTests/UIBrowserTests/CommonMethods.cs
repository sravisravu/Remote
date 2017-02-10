using System;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;
using OpenQA.Selenium;
using System.Threading;
namespace UIBrowserTests

{
    public class CommonMethods
    {
        public static string connStringdw = "Server = tcp:" + ConfigurationManager.AppSettings["dDBServer"] + ",1433;Initial Catalog = DWCloud; Persist Security Info=False;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Authentication=Active Directory Integrated";

        public static string ResultSetCount(string inputsql, string connStringdw)
        {
            SqlConnection conndw = new SqlConnection(connStringdw);
            conndw.Open();
            SqlCommand cmdinsertdw = new SqlCommand(inputsql, conndw);
            cmdinsertdw.CommandTimeout = 0;
            string resultset = "";
            SqlDataReader readerngsdw = cmdinsertdw.ExecuteReader();

            while (readerngsdw.Read())
            {
                resultset = readerngsdw[0].ToString();
            }
            readerngsdw.Close();
            conndw.Close();
            Console.ReadLine();
            return resultset;
        }

        public static DataTable SourceTargetValidation(string sql)
        {
            DataTable dt1 = new DataTable();
            SqlConnection con = new SqlConnection(CommonMethods.connStringdw);
            con.Open();
            SqlCommand cmd = new SqlCommand(sql);
            cmd.CommandTimeout = 0;
            using (con)
            {
                using (SqlDataAdapter da = new SqlDataAdapter())
                {
                    cmd.Connection = con;
                    da.SelectCommand = cmd;
                    da.Fill(dt1);
                    da.Dispose();
                }
            }
            return dt1;
        }

        public static string ClickAndSwitchWindow(IWebElement elementToBeClicked,IWebDriver driver, int timer = 2000)
        {
            System.Collections.Generic.List<string> previousHandles = new
            System.Collections.Generic.List<string>();
            System.Collections.Generic.List<string> currentHandles = new
            System.Collections.Generic.List<string>();
            previousHandles.AddRange(driver.WindowHandles);
            elementToBeClicked.Click();
            Thread.Sleep(timer);
            for (int i = 0; i < 20; i++)
            {
                currentHandles.Clear();
                currentHandles.AddRange(driver.WindowHandles);
                foreach (string s in previousHandles)
                {
                    currentHandles.RemoveAll(p => p == s);
                }
                if (currentHandles.Count == 1)
                {
                    driver.SwitchTo().Window(currentHandles[0]);
                    Thread.Sleep(100);
                    return currentHandles[0];
                }
                else
                {
                    Thread.Sleep(500);
                }
            }
            return null;
        }
    }

}