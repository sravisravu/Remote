using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
namespace CloudReplicationTests
{
    [TestClass]
    public class addressdim
    {
        CommonMethods AddressDim = new CommonMethods();
        [TestCategory("AddressDim")]
        [TestMethod]
        public void AddressDimReplicationValidation()
        {
            string addressdimcolumn = AddressDim.ColumnNames("addressdim");
            AddressDim.SourceTargetValidation(@"select top 1000" +addressdimcolumn+" "+"from dbo.addressdim order by 1 desc");
        }
        [TestCategory("AddressDim")]
        [TestMethod]
        public void DataValidationForaddressDimByCounts()
        {
            AddressDim.SourceTargetValidation(@"select count(*) from dbo.addressdim");
        }
      /*  [TestCategory("AddressDim")]
        [TestMethod]
        public void DataValidationaddressDimCountsOfIndividualColumns()
        {
            string dimcolumns = CommonMethods.ColumnNames("addressdim");
            string[] words = dimcolumns.Split(',');
            foreach (string word in words)
            {
                CommonMethods.SourceTargetValidation("select count( distinct " + word + ")" + " " + "from" + " " + "addressdim");
            }

        }

        [TestCategory("AddressDim")]
        [TestMethod]
        public void DataValidationForaddressDimBySumOfIntColumns()
        {
            string dimcolumns = CommonMethods.IntColumnNames("addressdim");
            string[] words = dimcolumns.Split(',');
            foreach (string word in words)
            {
                CommonMethods.SourceTargetValidation("select sum(cast(" + word + " as bigint))" + " " + "from" + " " + "addressdim");
            }

        }*/

    }
}



