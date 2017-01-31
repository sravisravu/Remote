using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Data.SqlClient;
using System.Diagnostics;
using System.IO;
using System.Configuration;
using System.Xml;
using Microsoft.XmlDiffPatch;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.IE;
using OpenQA.Selenium.Firefox;
using System.Threading;

namespace CloudReplicationTests
{

    [TestClass]
    public class SchemaTests
    {
        int i, j;
        public string schema = "dbo";
        [TestMethod]
        public void DDLValidationByColumnName()
        {
            string source = "";
            string target = "";

            for (i = 0; i < CommonMethods.list.Count; i++)
            {
                source = "select COLUMN_NAME from [INFORMATION_SCHEMA].[COLUMNS] where table_name=" + "'" + CommonMethods.list[i] + "'";
                target = "select COLUMN_NAME from [INFORMATION_SCHEMA].[COLUMNS] where table_name=" + "'" + CommonMethods.list[i] + "' and table_schema=" + "'" + schema + "'";

                source = CommonMethods.ResultSetCount(source, "Source", "Source", CommonMethods.connStringdw);
                target = CommonMethods.ResultSetCount(target, "Target", "Target", CommonMethods.connStringdw1);
                if (source.Equals(target))
                {
                    Console.WriteLine(CommonMethods.list[i] + ":" + " " + "source and target are equal");

                }
                else
                {
                    CommonMethods.textCompare(source, target);

                    //CompareXml(@"C:\\ReplicationTests\\Source.xml", @"C:\\ReplicationTests\\Target.xml", @"C:\\ReplicationTests\\DiffBetweenSourceAndTarget.xml");
                }
            }
            Assert.AreEqual(source, target);

        }

        [TestMethod]
        public void DDLValidationByDataType()
        {
            string source = "";
            string target = "";
            for (i = 0; i < CommonMethods.list.Count; i++)
            {
                source = "select DATA_TYPE from [INFORMATION_SCHEMA].[COLUMNS] where table_name=" + "'" + CommonMethods.list[i] + "'";
                target = "select DATA_TYPE from [INFORMATION_SCHEMA].[COLUMNS] where table_name=" + "'" + CommonMethods.list[i] + "' and table_schema=" + "'" + schema + "'";

                source = CommonMethods.ResultSetCount(source, "Source", "Source", CommonMethods.connStringdw);
                target = CommonMethods.ResultSetCount(target, "Target", "Target", CommonMethods.connStringdw1);
                if (source.Equals(target))
                {
                    Console.WriteLine(CommonMethods.list[i] + ":" + " " + "source and target are equal");

                }
                else
                {
                    CommonMethods.textCompare(source, target);
                    Console.WriteLine(CommonMethods.list[i] + ":" + " " + "source and target are not equal");
                }
            }
            Assert.AreEqual(source, target);
        }
        [TestMethod]
        public void DDLValidationByColumnSize()
        {
            string source = "";
            string target = "";
            for (i = 0; i < CommonMethods.list.Count; i++)
            {
                source = "select CHARACTER_MAXIMUM_LENGTH from [INFORMATION_SCHEMA].[COLUMNS] where table_name=" + "'" + CommonMethods.list[i] + "'";
                target = "select CHARACTER_MAXIMUM_LENGTH from [INFORMATION_SCHEMA].[COLUMNS] where table_name=" + "'" + CommonMethods.list[i] + "' and table_schema=" + "'" + schema + "'";

                source = CommonMethods.ResultSetCount(source, "Source", "Source", CommonMethods.connStringdw);
                target = CommonMethods.ResultSetCount(target, "Target", "Target", CommonMethods.connStringdw1);
                if (source.Equals(target))
                {
                    Console.WriteLine(CommonMethods.list[i] + ":" + " " + "source and target are equal");

                }
                else
                {
                    CommonMethods.textCompare(source, target);
                    //CompareXml(@"C:\\ReplicationTests\\Source.xml", @"C:\\ReplicationTests\\Target.xml", @"C:\\ReplicationTests\\DiffBetweenSourceAndTarget.xml");
                }
            }
            Assert.AreEqual(source, target);
        }



        /*[TestMethod]
        public void PrimaryKeyUniqueness()
        {
            commonsqlstatement1("select top 1 fwduspspackagekey,count(*) from dbo.fwduspspackageevent group by FwdUSPSPackageKey,trackingeventkey,eventstddatekey,eventstddatekey having count(*)>1 and fwduspspackagekey='242730448'");
            CompareXml("c:\\first\\data.xml", "c:\\second\\data.xml", "c:\\second\\diff.xml");
        }*/

        [TestMethod]
        public void DDLValidationByISNullable()
        {
            string source = "";
            string target = "";

            for (i = 0; i < CommonMethods.list.Count; i++)
            {
                source = "select is_nullable from [INFORMATION_SCHEMA].[COLUMNS] where table_name=" + "'" + CommonMethods.list[i] + "'";
                target = "select is_nullable from [INFORMATION_SCHEMA].[COLUMNS] where table_name=" + "'" + CommonMethods.list[i] + "' and table_schema=" + "'" + schema + "'";

                source = CommonMethods.ResultSetCount(source, "Source", "Source", CommonMethods.connStringdw);
                target = CommonMethods.ResultSetCount(target, "Target", "Target", CommonMethods.connStringdw1);
                if (source.Equals(target))
                {
                    Console.WriteLine(CommonMethods.list[i] + ":" + " " + "source and target are equal");

                }
                else
                {

                    CommonMethods.textCompare(source, target);
                    //CompareXml(@"C:\\ReplicationTests\\Source.xml", @"C:\\ReplicationTests\\Target.xml", @"C:\\ReplicationTests\\DiffBetweenSourceAndTarget.xml");
                }
            }
            Assert.AreEqual(source, target);
        }
    }
}
