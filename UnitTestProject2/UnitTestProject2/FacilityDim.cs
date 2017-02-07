using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
namespace CloudReplicationTests
{
    [TestClass]
    public class Facilitydim
    {
        [TestCategory("FacilityDim")]
        [TestMethod]
        public void FacilityDimReplicationValidation()
        {
            string Facilitydimcolumn = CommonMethods.ColumnNames("Facilitydim");            
            CommonMethods.SourceTargetValidation(@"select" +" "+Facilitydimcolumn +" "+"from dbo.Facilitydim order by 1 desc");
           
        }
        [TestCategory("FacilityDim")]
        [TestMethod]
        public void DataValidationForFacilityDimByCounts()
        {
            CommonMethods.SourceTargetValidation(@"select count(*) from dbo.Facilitydim");
        }
        [TestCategory("FacilityDim")]
        [TestMethod]
        public void DataValidationFacilityDimCountsOfIndividualColumns()
        {
            string dimcolumns = CommonMethods.ColumnNames("Facilitydim");
            string[] words = dimcolumns.Split(',');
            foreach (string word in words)
            {
                CommonMethods.SourceTargetValidation("select count( distinct " + word + ")" + " " + "from" + " " + "Facilitydim");
            }

        }
        [TestCategory("FacilityDim")]
        [TestMethod]
        public void DataValidationFacilityDimCountsOfRemainingIndividualColumns()
        {

            string remainingdimcolumns = CommonMethods.RemainingColumnNames("Facilitydim");
            string[] remainingwords = remainingdimcolumns.Split(',');
            foreach (string remaining in remainingwords)
            {
                CommonMethods.SourceTargetValidation("select count( distinct " + remaining + ")" + " " + "from" + " " + "Facilitydim");
            }

        }
        [TestCategory("FacilityDim")]
        [TestMethod]
        public void DataValidationForFacilityDimBySumOfIntColumns()
        {
            string dimcolumns = CommonMethods.IntColumnNames("Facilitydim");
            string[] words = dimcolumns.Split(',');
            foreach (string word in words)
            {
                CommonMethods.SourceTargetValidation("select sum(cast(" + word + " as bigint))" + " " + "from" + " " + "Facilitydim");
            }

        }

    }
}



