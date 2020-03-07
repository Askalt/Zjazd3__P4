using System;
using System.Data.SqlClient;

namespace Zjazd3__P4
{
    class Program
    {
        static void Main(string[] args)
        {
            var connString = @"Data Source=DESKTOP-MPTGS57\SQLEXPRESS;Initial Catalog=ZNorthwind;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
            using var connection = new SqlConnection(connString);
            var db = new DB();
            db.Select(connection);
           db.Insert(connection, 306, "RegionZ");
            db.Insert(connection, 304, "RegionZ");
        }
    }
}
