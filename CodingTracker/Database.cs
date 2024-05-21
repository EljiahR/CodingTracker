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
        private static string _connString = ConfigurationManager.AppSettings.Get("connString") ?? "Data Source=tracker.db";
        private static string _filePath = ConfigurationManager.AppSettings.Get("path") ?? "tracker.db";

        public static void CreateEmpty()
        {
            using (var connection = new SQLiteConnection(_connString))
            {
                connection.Open();
                connection.Execute(
                    @"CREATE TABLE IF NOT EXISTS tracker(
                        id INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT,
                        StartTime DATETIME NOT NULL,
                        EndTime DATETIME NOT NULL
                    );"
                );

            }
        }

        public static void InsertRow(CodingSession session)
        {
            using (var connection = new SQLiteConnection(_connString))
            {
                connection.Open();
                string sql = "INSERT INTO tracker(StartTime, EndTime) VALUES(@StartTime, @EndTime)";
                connection.Execute(sql, session);
            }    
        }

        public static void UpdateRow(CodingSession session)
        {
            using (var connection = new SQLiteConnection(_connString))
            {
                connection.Open();
                string sql = "UPDATE tracker SET StartTime = @StartTime, EndTime = @EndTime WHERE id = @id";
                connection.Execute(sql, session);
            }
        }

        public static void DeleteRow(CodingSession session)
        {

            using (var connection = new SQLiteConnection(_connString))
            {
                connection.Open();
                string sql = "DELETE FROM tracker WHERE id = @id";
                connection.Execute( sql, session);
            }
        }

        public static List<CodingSession> ViewAll()
        {
            using (var connection = new SQLiteConnection(_connString))
            {
                connection.Open();
                string sql = "SELECT StartTime, EndTime, id FROM tracker";
                return connection.Query<CodingSession>(sql).ToList();
            }
        }

        public static void DeleteAll()
        {
            File.Delete(_filePath);
            CreateEmpty();
        }

        public static Dictionary<string, double> GetHoursPerDay()
        {
            Dictionary<string, double> result = new();

            
            using (var connection = new SQLiteConnection(_connString))
            {
                connection.Open();
                string sql = "SELECT SUM(ROUND((JULIANDAY(EndTime) - JULIANDAY(StartTime)) * 24, 2)) as column1 FROM tracker GROUP BY STRFTIME('%Y-%m-%d', StartTime) Order By StartTime";
                var query = connection.Query(sql);
                foreach(var item in query)
                {
                    Console.WriteLine(item.column1);
                }
            }

            return result;
        }
    }
}
