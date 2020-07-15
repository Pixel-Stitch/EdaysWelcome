using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;

namespace DataAccess
{
    public class SqlDataAccess
    {
        public static string ConnectionString = @"Data Source=.\EdaysWelcomeDB.db;Version=3;";

        public static IEnumerable<T> LoadData<T>(string sql)
        {
            using (IDbConnection connection = new SQLiteConnection(ConnectionString))
            {
                return connection.Query<T>(sql);
            }
        }

        public static int SaveData<T>(string sql, T data)
        {
            using (IDbConnection connection = new SQLiteConnection(ConnectionString))
            {
                return connection.Execute(sql, data);
            }
        }

        public static int ExecuteQuery(string sql)
        {
            using (IDbConnection connection = new SQLiteConnection(ConnectionString))
            {
                return connection.Execute(sql);
            }
        }
    }
}
