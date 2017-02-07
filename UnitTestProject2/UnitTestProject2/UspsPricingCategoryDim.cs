using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
namespace CloudReplicationTests
{
    [TestClass]
    public class UspsPricingCategoryDim
    {
        [TestCategory("UspsPricingCategoryDim")]
        [TestMethod]
        public void UspsPricingCategoryDimReplicationValidation()
        {
            string UspsPricingCategoryDimcolumn = CommonMethods.ColumnNames("UspsPricingCategoryDim");
            CommonMethods.SourceTargetValidation(@"select top 100000" + " " + UspsPricingCategoryDimcolumn + " " + "from dbo.UspsPricingCategoryDim order by 1 desc");

        }
        [TestCategory("UspsPricingCategoryDim")]
        [TestMethod]
        public void DataValidationForUspsPricingCategoryDimByCounts()
        {
            CommonMethods.SourceTargetValidation(@"select count(*) from dbo.UspsPricingCategoryDim");
        }
        [TestCategory("UspsPricingCategoryDim")]
        [TestMethod]
        public void DataValidationUspsPricingCategoryDimCountsOfIndividualColumns()
        {
            string dimcolumns = CommonMethods.ColumnNames("UspsPricingCategoryDim");
            string[] words = dimcolumns.Split(',');
            foreach (string word in words)
            {
                CommonMethods.SourceTargetValidation("select count( distinct " + word + ")" + " " + "from" + " " + "UspsPricingCategoryDim");
            }

        }

        [TestCategory("UspsPricingCategoryDim")]
        [TestMethod]
        public void DataValidationForUspsPricingCategoryDimBySumOfIntColumns()
        {
            string dimcolumns = CommonMethods.IntColumnNames("UspsPricingCategoryDim");
            string[] words = dimcolumns.Split(',');
            foreach (string word in words)
            {
                CommonMethods.SourceTargetValidation("select sum(cast(" + word + " as bigint))" + " " + "from" + " " + "UspsPricingCategoryDim");
            }

        }

    }
}



