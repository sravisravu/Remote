using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
namespace CloudReplicationTests
{
    [TestClass]
    public class UspsPricingCategoryDim
    {
        CommonMethods UPCD = new CommonMethods();
        [TestCategory("UspsPricingCategoryDim")]
        [TestMethod]
        public void UspsPricingCategoryDimReplicationValidation()
        {
            string UspsPricingCategoryDimcolumn = UPCD.ColumnNames("UspsPricingCategoryDim");
           
            UPCD.SourceTargetValidation(@"select top 100000" + " " + UspsPricingCategoryDimcolumn + " " + "from dbo.UspsPricingCategoryDim order by 1 desc");

        }
        [TestCategory("UspsPricingCategoryDim")]
        [TestMethod]
        public void DataValidationForUspsPricingCategoryDimByCounts()
        {
            
            UPCD.SourceTargetValidation(@"select count(*) from dbo.UspsPricingCategoryDim");
        }
        [TestCategory("UspsPricingCategoryDim")]
        [TestMethod]
        public void DataValidationUspsPricingCategoryDimCountsOfIndividualColumns()
        {
            string dimcolumns = UPCD.ColumnNames("UspsPricingCategoryDim");
            string[] words = dimcolumns.Split(',');
            foreach (string word in words)
            {
                
                UPCD.SourceTargetValidation("select count( distinct " + word + ")" + " " + "from" + " " + "UspsPricingCategoryDim");
            }

        }

        [TestCategory("UspsPricingCategoryDim")]
        [TestMethod]
        public void DataValidationForUspsPricingCategoryDimBySumOfIntColumns()
        {
            string dimcolumns = UPCD.IntColumnNames("UspsPricingCategoryDim");
            string[] words = dimcolumns.Split(',');
            foreach (string word in words)
            {
                
                UPCD.SourceTargetValidation("select sum(cast(" + word + " as bigint))" + " " + "from" + " " + "UspsPricingCategoryDim");
            }

        }

    }
}



