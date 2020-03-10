using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zjazd3__P4
{
    public class DB
    {
        //public void Select(IDbConnection connection)
        //{
        //    var sql = "SELECT * FROM [mg].[Kategorie]";
        //    var result= connection.Query<Kategorie>(sql);
        //    foreach (var item in result)
        //    {
        //        Console.WriteLine($"{item.IDkategorii} : {item.NazwaKategorii}");
        //    }

        //}

        public List<Kategorie> Select(IDbConnection conn)
        {

            List<Kategorie> regions = new List<Kategorie>();
            var sql = "SELECT * FROM Northwind.dbo.Region";
            var result = conn.Query<Kategorie>(sql);
            foreach (var item in result)
            {
                Console.WriteLine($"{item.IDkategorii.ToString()}: {item.NazwaKategorii}");
                regions.Add(item);
            }
            return regions;
        }

        public void Insert(IDbConnection connection,int id,string opis)
        {
            var sql = "INSERT INTO [mg].[Kategorie](IDkategorii,NazwaKategorii) VALUES(@id,@opis)";
            var changed = connection.Execute(sql,
                    new{
                        id= id,
                        opis= opis
                    });
            Console.WriteLine($"Wrzucono{changed}");
        }

        public void Delete(IDbConnection connection, List<Kategorie> kategories)
        {
            foreach (var item in kategories)
            {
                var sql = $"DELETE FROM ZNorthwind.[mg].[Kategorie] WHERE {item.IDkategorii} = 301";
                var result = connection.Execute(sql);
                if (item.IDkategorii == 300)
                {
                    Console.WriteLine($"Usunięto kategorie {item.NazwaKategorii}");
                }
            }
        }

        public void Update(IDbConnection connection)
        {
            var sql = $"UPDATE ? SET ? = ? WHERE ? = ?";
            var result = connection.Query<Kategorie>(sql);

        }

        //public void Delete(IDbConnection connection, List<Kategorie> kategories)
        //{
        //    foreach (var item in kategories)
        //    {
        //        var sql = $"DELETE FROM ZNorthwind.[mg].[Kategorie] WHERE {item.IDkategorii} = 301";
        //        var result = connection.Execute(sql);
        //        if (item.IDkategorii == 300)
        //        {
        //            Console.WriteLine($"Usunięto kategorie {item.NazwaKategorii}");
        //        }
        //    }
        //}
    }
}
