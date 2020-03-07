using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace Zjazd3__P4
{
    public class DB
    {
        public void Select(IDbConnection connection)
        {
            var sql = "SELECT * FROM [mg].[Kategorie]";
            var result= connection.Query<Kategorie>(sql);
            foreach (var item in result)
            {
                Console.WriteLine($"{item.IDkategorii} : {item.NazwaKategorii}");
            }

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
    }
}
