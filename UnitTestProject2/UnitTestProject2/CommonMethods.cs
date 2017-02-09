using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;
using System.Threading;

namespace CloudReplicationTests
{

    public class CommonMethods
    {
        public static List<string> list = new List<string>(new string[] { "DateDim", "AddressDim", "AuditDim", "FacilityDim", "FwdContainer", "FwdPackage", "FwdUSPSPackage", "FwdUSPSPackageEvent", "OrgDim", "PostalCodeDim", "TrackingEventDim", "USPSFacilityDim", "USPSFacilityServiceZip", "USPSPricingCategoryDim", "USPSRateCategoryDim", "FwdTracking", "FwdPackageEvent" });
        public static string connStringdw = "Database=" + ConfigurationManager.AppSettings["sngsdwDBName"] + ";Data Source=" + ConfigurationManager.AppSettings["sDBServer"] + ";User Id=etlprocess; password=etlprocess";
        //public static string connStringdw1 = "Server = tcp:" + ConfigurationManager.AppSettings["dDBServer"] + ",1433;Initial Catalog = DWCloud; Persist Security Info=False;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Authentication=Active Directory Integrated";
        public static string connStringdw1 = "Database=" + ConfigurationManager.AppSettings["dngsdwDBName"] + ";Data Source=" + ConfigurationManager.AppSettings["dDBServer"] + ";User Id=etlprocess6; password=etlprocess6p";
        int count;
        public static string schema = ConfigurationManager.AppSettings["schema"];

        public DataTable getDifferentRecords(DataTable FirstDataTable, DataTable SecondDataTable)
        {
            DataTable ResultDataTable = new DataTable("ResultDataTable");
            using (DataSet ds = new DataSet())
            {
                ds.Tables.AddRange(new DataTable[] { FirstDataTable.Copy(), SecondDataTable.Copy() });
                DataColumn[] firstColumns = new DataColumn[ds.Tables[0].Columns.Count];
                for (int i = 0; i < firstColumns.Length; i++)
                {
                    firstColumns[i] = ds.Tables[0].Columns[i];
                }
                DataColumn[] secondColumns = new DataColumn[ds.Tables[1].Columns.Count];
                for (int i = 0; i < secondColumns.Length; i++)
                {
                    secondColumns[i] = ds.Tables[1].Columns[i];
                }
                DataRelation r1 = new DataRelation(string.Empty, firstColumns, secondColumns, false);
                ds.Relations.Add(r1);
                DataRelation r2 = new DataRelation(string.Empty, secondColumns, firstColumns, false);
                ds.Relations.Add(r2); 
                for (int i = 0; i < FirstDataTable.Columns.Count; i++)
                {
                    ResultDataTable.Columns.Add(FirstDataTable.Columns[i].ColumnName, FirstDataTable.Columns[i].DataType);
                }                
                ResultDataTable.BeginLoadData(); 
                foreach (DataRow parentrow in ds.Tables[0].Rows)
                {                    
                    DataRow[] childrows = parentrow.GetChildRows(r1);
                    if (childrows == null || childrows.Length == 0)
                    {
                        count = 1;
                        ResultDataTable.LoadDataRow(parentrow.ItemArray, true);
                    }
                }
                foreach (DataRow parentrow in ds.Tables[1].Rows)
                {                    
                    DataRow[] childrows = parentrow.GetChildRows(r2);
                    if (childrows == null || childrows.Length == 0)
                    {
                        count = 1;
                        ResultDataTable.LoadDataRow(parentrow.ItemArray, true);
                    }
                }
                ResultDataTable.EndLoadData();
            }
            return ResultDataTable;
        }
      

        public string ColumnNames(string tablename)
        {
            string source = "DECLARE @categories varchar(8000);SET @categories = NULL;select top 32 @categories = COALESCE(@categories + ',','')  + COLUMN_Name from [INFORMATION_SCHEMA].[COLUMNS] where table_name=" + "'" + tablename + "';SELECT @categories;";
            source = ResultSetCount(source, CommonMethods.connStringdw);
            return source;
        }

        public string IntColumnNames(string tablename)
        {
            string source = "DECLARE @categories varchar(8000);SET @categories = NULL;select top 32 @categories = COALESCE(@categories + ',','')  + COLUMN_Name from [INFORMATION_SCHEMA].[COLUMNS] where table_name=" + "'" + tablename + "' and data_type = 'int';SELECT @categories;";
            source = ResultSetCount(source, CommonMethods.connStringdw);
            return source;

        }

        public string RemainingColumnNames(string tablename)
        {
            string source = "DECLARE @categories varchar(8000);SET @categories = NULL;select @categories = COALESCE(@categories + ',','')  + COLUMN_Name from [INFORMATION_SCHEMA].[COLUMNS] where table_name="+"'"+tablename+"' and column_name not in (select top 32 COLUMN_Name from [INFORMATION_SCHEMA].[COLUMNS] where table_name="+"'"+tablename+"');SELECT @categories;";
            source = ResultSetCount(source, CommonMethods.connStringdw);
            return source;
        }
       

        public string ResultSetCount(string inputsql, string connStringdw)
        {
            SqlConnection conndw = new SqlConnection(connStringdw);
            conndw.Open();
            SqlCommand cmdinsertdw = new SqlCommand(inputsql, conndw);
            string resultset = "";
            SqlDataReader readerngsdw = cmdinsertdw.ExecuteReader();
            while (readerngsdw.Read())
            {
                resultset = resultset + readerngsdw[0].ToString();
            }
            readerngsdw.Close();
            conndw.Close();
            Console.ReadLine();
            return resultset;
        }

       
        public void Schema(string columnname)
        {
            for (int i = 0; i < CommonMethods.list.Count; i++)
            {
                string source = "select" + " " + columnname + " " + "from [INFORMATION_SCHEMA].[COLUMNS] where table_name=" + "'" + CommonMethods.list[i] + "'";
                string target = "select" + " " + columnname + " " + "from [INFORMATION_SCHEMA].[COLUMNS] where table_schema="+"'"+schema+"'"+" "+"and table_name=" + "'" + CommonMethods.list[i] + "'";

                source = ResultSetCount(source, CommonMethods.connStringdw);
                target = ResultSetCount(target, CommonMethods.connStringdw1);
                if (source.Equals(target))
                {
                    Console.WriteLine(CommonMethods.list[i] + ":" + " " + "source and target are equal");

                }
                else
                {
                    Console.WriteLine(CommonMethods.list[i] + ":" + " " + "source and target are not equal");
                    Assert.Fail();
                }
            }
        }
        public void SourceTargetValidation(string sql)
        {
            DataTable dt1 = new DataTable();
            DataTable dt2 = new DataTable();
            SqlConnection con = new SqlConnection(CommonMethods.connStringdw);
            con.Open();
            SqlConnection con1 = new SqlConnection(CommonMethods.connStringdw1);
            con1.Open();
            SqlCommand cmd = new SqlCommand(sql);
            cmd.CommandTimeout = 0;
            SqlCommand cmd1 = new SqlCommand(sql);
            cmd1.CommandTimeout = 0;
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
            
            con.Close();
            using (con1)
            {
                using (SqlDataAdapter da = new SqlDataAdapter())
                {
                    cmd1.Connection = con1;
                    da.SelectCommand = cmd1;                    
                    da.Fill(dt2);
                    da.Dispose();

                }
            }
            con1.Close();
            DataTable DiffTable = new DataTable();
            string result = "";
            DiffTable = getDifferentRecords(dt1, dt2);            
            if (count==1)
            {
                Console.WriteLine("Source and Target Row Count/Row Content do not match");
                foreach (DataRow row in DiffTable.Rows)
                {
                    for (int x = 0; x < DiffTable.Columns.Count; x++)
                    {
                        result = result + row[x].ToString()+" ";
                    }
                    result = result + '\n';
                }
                Console.WriteLine(result);
                Assert.Fail();
            }
            else
            {
                Console.WriteLine("Source and Target Match");

            }
            count = 0;
        }

        public void SourceTargetChangeTracking(string sql,string sql1)
        {
            DataTable dt1 = new DataTable();
            DataTable dt2 = new DataTable();
            SqlConnection con = new SqlConnection(CommonMethods.connStringdw);
            con.Open();
            SqlConnection con1 = new SqlConnection(CommonMethods.connStringdw1);
            con1.Open();
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
            con.Close();
            using (con1)
            {
                using (SqlDataAdapter da = new SqlDataAdapter())
                {
                    foreach (DataRow row in dt1.Rows)
                    {                       
                            SqlCommand cmd1 = new SqlCommand(sql1 + row[0]);
                            cmd1.CommandTimeout = 0;
                            cmd1.Connection = con1;
                            da.SelectCommand = cmd1;
                            da.Fill(dt2);
                            da.Dispose();
                    }

                }
            }
            con1.Close();
            DataTable DiffTable = new DataTable();
            string result = "";
            DiffTable = getDifferentRecords(dt1, dt2);
            if (count == 1)
            {
                Console.WriteLine("Source and Target Row Count/Row Content do not match");
                foreach (DataRow row in DiffTable.Rows)
                {
                    for (int x = 0; x < DiffTable.Columns.Count; x++)
                    {
                        result = result + row[x].ToString();
                    }
                    result = result + '\n';
                }
                Console.WriteLine(result);
                Assert.Fail();
            }
            else
            {
                Console.WriteLine("Source and Target Match");
            }
        }
    }
}
