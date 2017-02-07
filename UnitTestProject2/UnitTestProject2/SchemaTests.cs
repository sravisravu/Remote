using Microsoft.VisualStudio.TestTools.UnitTesting;


namespace CloudReplicationTests
{

    [TestClass]
    public class SchemaTests
    {
        int i;
        public string schema = "dbo";
        [TestMethod]
        public void DDLValidationByColumnName()
        {
            CommonMethods.Count("column_name");       

        }

        [TestMethod]
        public void DDLValidationByDataType()
        {
            CommonMethods.Count("data_type");
        }
        [TestMethod]
        public void DDLValidationByColumnSize()
        {
            CommonMethods.Count("CHARACTER_MAXIMUM_LENGTH");
        }     
    
        [TestMethod]
        public void DDLValidationByISNullable()
        {
            CommonMethods.Count("is_nullable");
        }
    }
}
