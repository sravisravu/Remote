using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
namespace CloudReplicationTests
{
    [TestClass]
    public class UspsRateCategoryDim
    {
        [TestCategory("UspsRateCategoryDim")]
        [TestMethod]
        public void UspsRateCategoryDimReplicationValidation()
        {
            string UspsRateCategoryDimcolumn = CommonMethods.ColumnNames("UspsRateCategoryDim");
            CommonMethods.SourceTargetValidation(@"select top 100000" + " " + UspsRateCategoryDimcolumn + " " + "from dbo.UspsRateCategoryDim order by 1 desc");

        }
        [TestCategory("UspsRateCategoryDim")]
        [TestMethod]
        public void DataValidationForUspsRateCategoryDimByCounts()
        {
            CommonMethods.SourceTargetValidation(@"select count(*) from dbo.UspsRateCategoryDim");
        }
        [TestCategory("UspsRateCategoryDim")]
        [TestMethod]
        public void DataValidationUspsRateCategoryDimCountsOfIndividualColumns()
        {
            string dimcolumns = CommonMethods.ColumnNames("UspsRateCategoryDim");
            string[] words = dimcolumns.Split(',');
            foreach (string word in words)
            {
                CommonMethods.SourceTargetValidation("select count( distinct " + word + ")" + " " + "from" + " " + "UspsRateCategoryDim");
            }

        }

        [TestCategory("UspsRateCategoryDim")]
        [TestMethod]
        public void DataValidationForUspsRateCategoryDimBySumOfIntColumns()
        {
            string dimcolumns = CommonMethods.IntColumnNames("UspsRateCategoryDim");
            string[] words = dimcolumns.Split(',');
            foreach (string word in words)
            {
                CommonMethods.SourceTargetValidation("select sum(cast(" + word + " as bigint))" + " " + "from" + " " + "UspsRateCategoryDim");
            }

        }

    }
}



