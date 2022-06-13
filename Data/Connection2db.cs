using Microsoft.Data.Sqlite;
using System;

namespace TestFromDeeplayCompany.Data
{
    internal class Connection2db
    {
        private readonly SqliteConnection connection = new("Data Source=" + @"..\\..\\..\\Data\\Employees.db; Mode=ReadWrite");

        public void OpenConnection()
        {
            if (connection.State == System.Data.ConnectionState.Closed)
            {
                connection.Open();
            }
        }

        public void CloseConnection()
        {
            if (connection.State == System.Data.ConnectionState.Open)
            {
                connection.Close();
            }
        }
        public SqliteConnection GetConnection()
        {
            return connection;
        }
    }
}
