using Microsoft.VisualStudio.TestTools.UnitTesting;


namespace CloudReplicationTests
{

    [TestClass]

    public class SchemaTests
    {
        CommonMethods st = new CommonMethods();
        int i;
        public string schema = "dbo";
        [TestMethod]
        public void DDLValidationByColumnName()
        {
            st.Count("column_name");       

        }

        [TestMethod]
        public void DDLValidationByDataType()
        {
            st.Count("data_type");
        }
        [TestMethod]
        public void DDLValidationByColumnSize()
        {
            st.Count("CHARACTER_MAXIMUM_LENGTH");
        }     
    
        [TestMethod]
        public void DDLValidationByISNullable()
        {
            st.Count("is_nullable");
        }
    }
}
