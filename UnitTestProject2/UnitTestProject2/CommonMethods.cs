using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Data.SqlClient;
using System.IO;
using System.Configuration;
using System.Xml;
using Microsoft.XmlDiffPatch;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;


namespace CloudReplicationTests
{

    public class CommonMethods
    {
        public static List<string> list = new List<string>(new string[] { "AddressDim", "AuditDim", "FacilityDim", "FwdContainer", "FwdPackage", "FwdUSPSPackage", "FwdUSPSPackageEvent", "OrgDim", "PostalCodeDim", "TrackingEventDim", "USPSFacilityDim", "USPSFacilityServiceZip", "USPSPricingCategoryDim", "USPSRateCategoryDim", "FwdTracking", "FwdPackageEvent", "DateDim" });
        public static string connStringdw = "Database=" + ConfigurationManager.AppSettings["sngsdwDBName"] + ";Data Source=" + ConfigurationManager.AppSettings["sDBServer"] + ";Integrated Security=SSPI;";
        //public static string connStringdw1 = "Server = tcp:" + ConfigurationManager.AppSettings["dDBServer"] + ",1433;Initial Catalog = DWCloud; Persist Security Info=False;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Authentication=Active Directory Integrated";
        public static string connStringdw1 = "Database=" + ConfigurationManager.AppSettings["dngsdwDBName"] + ";Data Source=" + ConfigurationManager.AppSettings["dDBServer"] + ";Integrated Security=SSPI;";
        public string schema = "dbo";
        public static int j;
        public static string source = "";
        public static string target = "";        

        public static void textCompare(string source, string target)
        {
            FirefoxDriver driver = new FirefoxDriver();
            driver.Navigate().GoToUrl("https://text-compare.com/");
            driver.Manage().Window.Maximize();
            driver.FindElement(By.Id("inputText1")).SendKeys(source);
            driver.FindElement(By.Id("inputText2")).SendKeys(target);
            driver.FindElement(By.Id("compareButton")).Click();
            driver.FindElement(By.Id("emailComparisonButton")).Click();
            driver.FindElement(By.Id("emailAddressField")).SendKeys("sravisravu@gmail.com");
            driver.FindElement(By.Id("sendComparisonButton")).Click();
            driver.Close();

        } 


        public static string ColumnNames(int i)
        {
            string source = "";
            source = "select COLUMN_NAME from [INFORMATION_SCHEMA].[COLUMNS] where table_name=" + "'" + CommonMethods.list[i] + "'";
            source = ResultSetCount(source, "Source", "Source", CommonMethods.connStringdw);
            //Console.WriteLine(source);
            return source;

        }

        public static string IntColumnNames(int i)
        {
            string source = "";
            source = "select COLUMN_NAME from [INFORMATION_SCHEMA].[COLUMNS] where table_name=" + "'" + CommonMethods.list[i] + "' and data_type = 'int'";
            source = ResultSetCount(source, "Source", "Source", CommonMethods.connStringdw);
            //Console.WriteLine(source);
            return source;

        }
        public static string ReplaceFirst(string text, string search, string replace)
        {
            int pos = text.IndexOf(search);
            if (pos < 0)
            {
                return text;
            }
            return text.Substring(0, pos) + replace + text.Substring(pos + search.Length);
        }

        public static string ReplaceLastOccurrence(string Source, string Find, string Replace)
        {
            int place = Source.LastIndexOf(Find);

            if (place == -1)
                return Source;

            string result = Source.Remove(place, Find.Length).Insert(place, Replace);
            return result;
        }
        
        public static string TargetCount(int i)
        {
            string Target = "select count(*) from ";
            Target = Target + " " + list[i];
            Target = ResultSetCount(Target, "Target", "Target", connStringdw1);            
            return Target;

        }

        public static string SourceCount(int i)
        {
            string source = "select count(*) from";
            source = source + " " + list[i];            
            source = ResultSetCount(source, "Source", "Source", connStringdw);           
            return source;
        }

        public static string DDLValidationByColumns(string tablename)
        {

            string source = "select count(*) from [INFORMATION_SCHEMA].[COLUMNS] where table_name=" + "'" + tablename + "'";
            source = ResultSetCount(source, "Source", "Source", connStringdw);
            return source;

        }


        public static void DataValidationForEntireTable(int count, string tablename, string select, string where, string orderby, List<string> tablenamecolumns)
        {
            string source = "";
            string target = "";            
            string dimcolumns = CommonMethods.StringReplace(count);
            string[] words = dimcolumns.Split(',');
            foreach (string word in words)
            {
                
                source = select + " " + word + " " + "from" + " " + CommonMethods.list[count] + " " + where + " " + orderby;
                target = select + " " + word + " " + "from" + " " + CommonMethods.list[count] + " " + where + " " + orderby;                
                source = CommonMethods.ResultSetCount(source, "Source", "Source", CommonMethods.connStringdw);                
                target = CommonMethods.ResultSetCount(target, "Target", "Target", CommonMethods.connStringdw1);
                
                if (source.ToLower().Equals(target.ToLower()))
                {
                    Console.WriteLine(word + ":" + " " + "source and target are equal");
                    Console.WriteLine(source);
                    Console.WriteLine(target);
                }
                else
                {
                        CommonMethods.textCompare(CommonMethods.list[count] + word + ":" + " " + source, CommonMethods.list[count] + word + ":" + " " + target);                      

                 }
                
            }            

        }  

        public static void CountDistinctColumn(int i)
        {           
            string dimcolumns = CommonMethods.StringReplace(i);
            string[] words = dimcolumns.Split(',');
            foreach (string word in words)
            {
                source = "select count( distinct " + word+ ")" + " " + "from"+" "+ list[i];
                source = ResultSetCount(source, "Source", "Source", connStringdw);               
                Console.WriteLine("Source Count:" + word+" "+source);
                target = "select count( distinct " + word + ")" + " " + "from" + " " + list[i];
                target = ResultSetCount(target, "Target", "Target", connStringdw1);
                Console.WriteLine("Source Count:" + word + " " + target);
               
                 if (source.ToLower().Equals(target.ToLower()))
                 {
                     Console.WriteLine("source and target are equal");

                 }
                 else
                 {
                     CommonMethods.textCompare(CommonMethods.list[i] + word + ":" + " " + source, CommonMethods.list[i] + word + ":" + " " + target);
                 }

            }
        }


        public static void SumIntColumn(int i)
        {
            string dimcolumns = CommonMethods.intStringReplace(i);
            string[] words = dimcolumns.Split(',');
            foreach (string word in words)
            {
                
                source = "select sum(cast("+word+" as bigint))" + " " + "from" + " " + list[i];
                source = ResultSetCount(source, "Source", "Source", connStringdw);
                Console.WriteLine("Source Count:" + word + " " + source);

                target = "select sum(cast(" + word + " as bigint))" + " " + "from" + " " + list[i];
                target = ResultSetCount(target, "Target", "Target", connStringdw1);
                Console.WriteLine("Target Count:" + word + " " + target);

                if (source.ToLower().Equals(target.ToLower()))
                {
                    Console.WriteLine("source and target are equal");

                }
                else
                {
                    CommonMethods.textCompare(CommonMethods.list[i] + word + ":" + " " + source, CommonMethods.list[i] + word + ":" + " " + target);


                }

            }
        }

        public static string StringReplace(int i)
        {
            string columns = CommonMethods.ColumnNames(i);
            columns = columns.Replace(" ", "\",\"");            
            columns = CommonMethods.ReplaceFirst(columns, "\",", "");
            string temp = columns;
            string output = temp.Substring(temp.Length - 1, 1);
            columns = CommonMethods.ReplaceLastOccurrence(columns, output, output + "\"");            
            return columns;
        }

        public static string intStringReplace(int i)
        {
            string columns = CommonMethods.IntColumnNames(i);
            columns = columns.Replace(" ", "\",\"");
            columns = CommonMethods.ReplaceFirst(columns, "\",", "");
            string temp = columns;
            string output = temp.Substring(temp.Length - 1, 1);
            columns = CommonMethods.ReplaceLastOccurrence(columns, output, output + "\"");
            return columns;
        }


        

        public static List<string> PopulateColumn(int i)
        {
            string dimcolumns = CommonMethods.StringReplace(i);
            //Console.WriteLine(dimcolumns);
            source = CommonMethods.SourceCount(i);
            target = CommonMethods.TargetCount(i);            
            return new List<string>(new string[] { dimcolumns } );

           
        }

        


        public static string ResultSetCount(string inputsql, string resultset, string filename, string connStringdw)
        {
            SqlConnection conndw = new SqlConnection(connStringdw);
            conndw.Open();
            /*XmlDocument xmltest = new XmlDocument(); */
            SqlCommand cmdinsertdw = new SqlCommand(inputsql, conndw);
            cmdinsertdw.CommandTimeout = 500000;
            resultset = "";
            SqlDataReader readerngsdw = cmdinsertdw.ExecuteReader();
            while (readerngsdw.Read())
            {
                resultset = resultset + " " + readerngsdw[0].ToString();
            }

            /* xmltest.LoadXml("<body><head>"+ resultset + "</head></body>");          
             XmlWriter writer = XmlWriter.Create(@"C:\\ReplicationTests\\"+ filename + ".xml");
             xmltest.Save(writer);          
             writer.Close();*/
            readerngsdw.Close();
            conndw.Close();
            Console.ReadLine();
            return resultset;
        }

        public static void CompareXml(string file1, string file2, string diffFileNameWithPath)
        {

            XmlReader reader1 = XmlReader.Create(new StringReader(file1));
            XmlReader reader2 = XmlReader.Create(new StringReader(file2));

            StringBuilder differenceStringBuilder = new StringBuilder();

            using (FileStream fs = new FileStream(diffFileNameWithPath, FileMode.Create))
            {
                XmlWriter diffGramWriter = XmlWriter.Create(fs);

                XmlDiff xmldiff = new XmlDiff(XmlDiffOptions.IgnoreChildOrder |
                                        XmlDiffOptions.IgnoreNamespaces |
                                        XmlDiffOptions.IgnorePrefixes);
                bool bIdentical = xmldiff.Compare(file1, file2, false, diffGramWriter);

                diffGramWriter.Close();
            }
        }

    }
}
