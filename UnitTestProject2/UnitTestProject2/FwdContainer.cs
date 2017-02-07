using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
namespace CloudReplicationTests
{
    [TestClass]
    public class FwdContainer
    {
        [TestCategory("FwdContainer")]
        [TestMethod]
        public void FwdContainerReplicationValidation()
        {
            string FwdContainercolumn = CommonMethods.ColumnNames("FwdContainer");
            CommonMethods.SourceTargetValidation(@"select top 100000" + " " + FwdContainercolumn + " " + "from dbo.FwdContainer order by 1 desc");

        }
        [TestCategory("FwdContainer")]
        [TestMethod]
        public void DataValidationForFwdContainerByCounts()
        {
            CommonMethods.SourceTargetValidation(@"select count(*) from dbo.FwdContainer");
        }
        [TestCategory("FwdContainer")]
        [TestMethod]
        public void DataValidationFwdContainerCountsOfIndividualColumns()
        {
            string columns = CommonMethods.ColumnNames("FwdContainer");
            string[] words = columns.Split(',');
            foreach (string word in words)
            {
                CommonMethods.SourceTargetValidation("select count( distinct " + word + ")" + " " + "from" + " " + "FwdContainer");
            }

        }

        [TestCategory("FwdContainer")]
        [TestMethod]
        public void DataValidationForFwdContainerBySumOfIntColumns()
        {
            string columns = CommonMethods.IntColumnNames("FwdContainer");
            string[] words = columns.Split(',');
            foreach (string word in words)
            {
                CommonMethods.SourceTargetValidation("select sum(cast(" + word + " as bigint))" + " " + "from" + " " + "FwdContainer");
            }

        }

    }
}



