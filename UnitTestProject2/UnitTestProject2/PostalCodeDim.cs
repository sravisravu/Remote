using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
namespace CloudReplicationTests
{
    [TestClass]
    public class postalcodedim
    {
        [TestMethod]
        public void DataValidationForpostalcodedim()
        {
            List<string> PostalCodedimcolumn = CommonMethods.PopulateColumn(8);
            if (CommonMethods.source == CommonMethods.target)
            {
                CommonMethods.DataValidationForEntireTable(8, "PostalCodedim", "select top 100", "", "order by 1 desc", PostalCodedimcolumn);
                CommonMethods.DataValidationForEntireTable(8, "PostalCodedim", "select top 100", "where PostalCodekey not in (select top 100 PostalCodekey from dbo.PostalCodedim order by 1 desc)", "order by 1 desc", PostalCodedimcolumn);
                CommonMethods.DataValidationForEntireTable(8, "PostalCodedim", "select top 100", "", "order by 1", PostalCodedimcolumn);
            }
            else
            {
                Assert.Fail();
            }
        }

    }
}



