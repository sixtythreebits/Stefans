using System.Configuration;

namespace DB
{
    public static class ConnectionFactory
    {
        public static string ConnectionString
        {
            get { return ConfigurationManager.ConnectionStrings["DBConnectionString"].ConnectionString; }
        }

        public static DBUMDataContext GetUMContext()
        {
            return new DBUMDataContext(ConnectionString);
        }
    }
}
