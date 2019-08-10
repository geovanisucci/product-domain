using System.Data.SqlClient;

namespace ProductBoundedContext.Data.Context
{
    public class ProductSqlDataContext 
    {
        public ProductSqlDataContext(string connectionString)
        {
            Connection = new SqlConnection(connectionString);
        }
        public SqlConnection Connection { get; }

    }
}