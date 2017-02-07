using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
namespace CloudReplicationTests
{
    [TestClass]
    public class UspsRateCategoryDim
    {
        CommonMethods urcd = new CommonMethods();
        [TestCategory("UspsRateCategoryDim")]
        [TestMethod]
        public void UspsRateCategoryDimReplicationValidation()
        {
            string UspsRateCategoryDimcolumn = urcd.ColumnNames("UspsRateCategoryDim");
            
            urcd.SourceTargetValidation(@"select top 1000" + " " + UspsRateCategoryDimcolumn + " " + "from dbo.UspsRateCategoryDim order by 1 desc");

        }
        [TestCategory("UspsRateCategoryDim")]
        [TestMethod]
        public void DataValidationForUspsRateCategoryDimByCounts()
        {
            
            urcd.SourceTargetValidation(@"select count(*) from dbo.UspsRateCategoryDim");
        }
        [TestCategory("UspsRateCategoryDim")]
        [TestMethod]
        public void DataValidationUspsRateCategoryDimCountsOfIndividualColumns()
        {
            string dimcolumns = urcd.ColumnNames("UspsRateCategoryDim");
            string[] words = dimcolumns.Split(',');
            foreach (string word in words)
            {
                
                urcd.SourceTargetValidation("select count( distinct " + word + ")" + " " + "from" + " " + "UspsRateCategoryDim");
            }

        }

        [TestCategory("UspsRateCategoryDim")]
        [TestMethod]
        public void DataValidationForUspsRateCategoryDimBySumOfIntColumns()
        {
            string dimcolumns = urcd.IntColumnNames("UspsRateCategoryDim");
            string[] words = dimcolumns.Split(',');
            foreach (string word in words)
            {
                
                urcd.SourceTargetValidation("select sum(cast(" + word + " as bigint))" + " " + "from" + " " + "UspsRateCategoryDim");
            }

        }

    }
}



