using Microsoft.Data.Sqlite;
using System;
using System.Collections.ObjectModel;
using TestFromDeeplayCompany.Data;
using TestFromDeeplayCompany.Models;

namespace TestFromDeeplayCompany.Services.Interfaces
{
    interface IDownloadProfileFromDB
    {
        protected static void ShowProfile(ObservableCollection<User> Users)
        {
            string sqlQuery = "SELECT * FROM Profile";
            Connection2db connection = new();
            connection.OpenConnection();
            SqliteCommand cmdSelectAllFromProfile = new(sqlQuery, connection.GetConnection());
            SqliteDataReader sqliteDataReader = cmdSelectAllFromProfile.ExecuteReader();
            while (sqliteDataReader.Read())
            {
                User user = new();
                user.IdUser = Convert.ToInt32(sqliteDataReader[0]);
                user.Name = sqliteDataReader[1].ToString();
                user.MiddleName = sqliteDataReader[2].ToString();
                user.Surname = sqliteDataReader[3].ToString();
                user.Birthday = Convert.ToDateTime(sqliteDataReader[4]);
                user.Adress = sqliteDataReader[5].ToString();
                user.PhoneNumber = sqliteDataReader[6].ToString();
                Users.Add(user);
            }
            sqliteDataReader.Close();
            connection.CloseConnection();
        }
    }
}
