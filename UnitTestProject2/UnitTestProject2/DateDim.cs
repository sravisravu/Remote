using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Configuration;


namespace CloudReplicationTests
{
    [TestClass]
    public class Datedim
    {
        CommonMethods datedim = new CommonMethods();
        public static string schema =ConfigurationManager.AppSettings["schema"];
        public static string datedimtable = ConfigurationManager.AppSettings["datedim"];

        [TestCategory("DateDim")]
        [TestMethod]
        public void DateDimReplicationValidation()
        {            
            datedim.SourceTargetValidation(@"select top 1000 * from" + " " + datedimtable);
        }
        [TestCategory("DateDim")]
        [TestMethod]
        public void DataValidationForDateDimByCounts()
        {  
            datedim.SourceTargetValidation(@"select count(*) from" + " " + schema +"."+datedimtable);  
        }
        [TestCategory("DateDim")]
        [TestMethod]
        public void DataValidationDateDimCountsOfIndividualColumns()
        {
            
            string dimcolumns = datedim.ColumnNames(datedimtable);
            string[] words = dimcolumns.Split(',');
            foreach (string word in words)
            {               
                datedim.SourceTargetValidation("select count( distinct " + word + ")" + " " + "from" + " " +schema+"."+datedimtable);
            }

        }
        [TestCategory("DateDim")]
        [TestMethod]
        public void DataValidationForDateDimBySumOfIntColumns()
        {          
            string dimcolumns = datedim.IntColumnNames(datedimtable);
            string[] words = dimcolumns.Split(',');
            foreach (string word in words)
            {
                CommonMethods datedim = new CommonMethods();
                datedim.SourceTargetValidation("select sum(cast(" + word + " as bigint))" + " " + "from" + " "+schema+"."+datedimtable);
            }            

        }

    }
}



