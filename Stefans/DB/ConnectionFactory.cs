using System.Configuration;

namespace DB
{
    public static class ConnectionFactory
    {
        public static string ConnectionString
        {
            get { return ConfigurationManager.ConnectionStrings["DBConnectionString"].ConnectionString; }
        }

        public static DBCoreDataContext GetCoreContext()
        {
            return new DBCoreDataContext(ConnectionString);
        }
    }
}
