using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
namespace CloudReplicationTests
{
    [TestClass]
    public class Datedim
    {
        [TestCategory("DateDim")]
        [TestMethod]
        public void DateDimReplicationValidation()
        {
            CommonMethods.SourceTargetValidation(@"select * from dbo.Datedim");
        }
        [TestCategory("DateDim")]
        [TestMethod]
        public void DataValidationForDateDimByCounts()
        {
            CommonMethods.SourceTargetValidation(@"select count(*) from dbo.Datedim");          

        }
        [TestCategory("DateDim")]
        [TestMethod]
        public void DataValidationDateDimCountsOfIndividualColumns()
        {
            string dimcolumns = CommonMethods.ColumnNames("datedim");
            string[] words = dimcolumns.Split(',');
            foreach (string word in words)
            {
                CommonMethods.SourceTargetValidation("select count( distinct " + word + ")" + " " + "from" + " " + "datedim");
            }

        }

        [TestCategory("DateDim")]
        [TestMethod]
        public void DataValidationForDateDimBySumOfIntColumns()
        {
            string dimcolumns = CommonMethods.IntColumnNames("datedim");
            string[] words = dimcolumns.Split(',');
            foreach (string word in words)
            {
                CommonMethods.SourceTargetValidation("select sum(cast(" + word + " as bigint))" + " " + "from" + " " + "datedim");
            }            

        }

    }
}



