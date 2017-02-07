using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
namespace CloudReplicationTests
{
    [TestClass]
    public class FwdContainer
    {
        CommonMethods fc = new CommonMethods();
        [TestCategory("FwdContainer")]
        [TestMethod]
        public void FwdContainerReplicationValidation()
        {
            string FwdContainercolumn = fc.ColumnNames("FwdContainer");
            fc.SourceTargetValidation(@"select top 100000" + " " + FwdContainercolumn + " " + "from dbo.FwdContainer order by 1 desc");

        }
        [TestCategory("FwdContainer")]
        [TestMethod]
        public void DataValidationForFwdContainerByCounts()
        {
            fc.SourceTargetValidation(@"select count(*) from dbo.FwdContainer");
        }
        [TestCategory("FwdContainer")]
        [TestMethod]
        public void DataValidationFwdContainerCountsOfIndividualColumns()
        {
            string columns = fc.ColumnNames("FwdContainer");
            string[] words = columns.Split(',');
            foreach (string word in words)
            {
                fc.SourceTargetValidation("select count( distinct " + word + ")" + " " + "from" + " " + "FwdContainer");
            }

        }

        [TestCategory("FwdContainer")]
        [TestMethod]
        public void DataValidationForFwdContainerBySumOfIntColumns()
        {
            string columns = fc.IntColumnNames("FwdContainer");
            string[] words = columns.Split(',');
            foreach (string word in words)
            {
                fc.SourceTargetValidation("select sum(cast(" + word + " as bigint))" + " " + "from" + " " + "FwdContainer");
            }

        }

    }
}



