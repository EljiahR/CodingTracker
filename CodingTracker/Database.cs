using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Collections.Specialized;
using System.Data.SQLite;
using Dapper;

namespace CodingTracker
{
    internal class Database
    {
        private static string? _connString = ConfigurationManager.AppSettings.Get("connString");

        public static void CreateEmpty()
        {
            if(!string.IsNullOrEmpty(_connString))
            {
                using (var connection = new SQLiteConnection(_connString))
                {
                    connection.Open();
                    connection.Execute(
                        @"CREATE TABLE IF NOT EXISTS tracker(
                            id INT PRIMARY KEY,
                            start DATETIME NOT NULL,
                            end DATETIME NOT NULL
                        );"
                    );

                }
            } else
            {
                Console.WriteLine("Missing connection string in config file");
            }

        }
    }
}
