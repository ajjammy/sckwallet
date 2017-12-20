using System;
using MySql.Data.MySqlClient;

namespace hello_ewallet
{
    public class AppDb: IDisposable
    {
        public MySqlConnection Connection;
        public AppDb()
        {
            Connection = new MySqlConnection(AppConfig.Config["ConnectionString:DefaultConnection"]);
        }
        public void Dispose()
        {
            Connection.Close();
        }
    }
}