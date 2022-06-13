using Microsoft.Data.Sqlite;
using System;
using System.Collections.ObjectModel;
using TestFromDeeplayCompany.Data;
using TestFromDeeplayCompany.Models;

namespace TestFromDeeplayCompany.Services.Interfaces
{
    interface IDownloadPostFromDb
    {
        protected static void ShowPost(ObservableCollection<Post> posts)
        {
            string sqlQuery = "SELECT * FROM post";
            Connection2db connection = new();
            connection.OpenConnection();
            SqliteCommand cmdSelectAllFromPost = new(sqlQuery, connection.GetConnection());
            SqliteDataReader sqliteDataReader = cmdSelectAllFromPost.ExecuteReader();
            while (sqliteDataReader.Read())
            {
                Post post = new();
                post.IdPost = Convert.ToInt32(sqliteDataReader[0]);
                post.NamePost = sqliteDataReader[1].ToString();
                posts.Add(post);
            }
            sqliteDataReader.Close();
            connection.CloseConnection();
        }
    }
}
