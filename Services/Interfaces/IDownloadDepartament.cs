using Microsoft.Data.Sqlite;
using System;
using System.Collections.ObjectModel;
using TestFromDeeplayCompany.Data;
using TestFromDeeplayCompany.Models;

namespace TestFromDeeplayCompany.Services.Interfaces
{
    interface IDownloadDepartament
    {
        protected static void ShowDepartament(ObservableCollection<Departament> departments)
        {
            string sqlQuery = "SELECT * FROM departament";
            Connection2db connection = new();
            connection.OpenConnection();
            SqliteCommand cmdSelectAllFromDepartament = new(sqlQuery, connection.GetConnection());
            SqliteDataReader sqliteDataReader = cmdSelectAllFromDepartament.ExecuteReader();
            while (sqliteDataReader.Read())
            {
                Departament departament = new();
                departament.IdDepartment = Convert.ToInt32(sqliteDataReader[0]);
                departament.NameDepartment = sqliteDataReader[1].ToString();
                departments.Add(departament);
            }
            sqliteDataReader.Close();
            connection.CloseConnection();
        }
    }
}
