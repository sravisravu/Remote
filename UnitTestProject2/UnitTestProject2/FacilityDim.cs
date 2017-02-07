using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
namespace CloudReplicationTests
{
    [TestClass]
    
    public class Facilitydim
    {
        CommonMethods facilitydim = new CommonMethods();
        [TestCategory("FacilityDim")]
        [TestMethod]
        public void FacilityDimReplicationValidation()
        {
            string Facilitydimcolumn = facilitydim.ColumnNames("Facilitydim");
            facilitydim.SourceTargetValidation(@"select top 1000" +" "+Facilitydimcolumn +" "+"from dbo.Facilitydim order by 1 desc");
           
        }
        [TestCategory("FacilityDim")]
        [TestMethod]
        public void DataValidationForFacilityDimByCounts()
        {
            facilitydim.SourceTargetValidation(@"select count(*) from dbo.Facilitydim");
        }
        [TestCategory("FacilityDim")]
        [TestMethod]
        public void DataValidationFacilityDimCountsOfIndividualColumns()
        {
            string dimcolumns = facilitydim.ColumnNames("Facilitydim");
            string[] words = dimcolumns.Split(',');
            foreach (string word in words)
            {
                facilitydim.SourceTargetValidation("select count( distinct " + word + ")" + " " + "from" + " " + "Facilitydim");
            }

        }
        [TestCategory("FacilityDim")]
        [TestMethod]
        public void DataValidationFacilityDimCountsOfRemainingIndividualColumns()
        {

            string remainingdimcolumns = facilitydim.RemainingColumnNames("Facilitydim");
            string[] remainingwords = remainingdimcolumns.Split(',');
            foreach (string remaining in remainingwords)
            {
                facilitydim.SourceTargetValidation("select count( distinct " + remaining + ")" + " " + "from" + " " + "Facilitydim");
            }

        }
        [TestCategory("FacilityDim")]
        [TestMethod]
        public void DataValidationForFacilityDimBySumOfIntColumns()
        {
            string dimcolumns = facilitydim.IntColumnNames("Facilitydim");
            string[] words = dimcolumns.Split(',');
            foreach (string word in words)
            {
                facilitydim.SourceTargetValidation("select sum(cast(" + word + " as bigint))" + " " + "from" + " " + "Facilitydim");
            }

        }

    }
}



