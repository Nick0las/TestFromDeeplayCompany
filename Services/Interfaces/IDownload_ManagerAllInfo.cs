using Microsoft.Data.Sqlite;
using System;
using System.Collections.ObjectModel;
using TestFromDeeplayCompany.Data;
using TestFromDeeplayCompany.Models;

namespace TestFromDeeplayCompany.Services.Interfaces
{
    interface IDownload_ManagerAllInfo
    {
        protected static void ShowAllManagerInfo(ObservableCollection<ManagerPersonal_Info> ManagersInfo)
        {
            string sqlQuery = "SELECT manager_personal.id_manager, Profile.ID_profile, Profile.Last_Name, Profile.First_Name, " +
                "Profile.Middle_Name, Profile.Birthday, Profile.Adress, Profile.Phone_Number, Post.Name_Post, Departament.Name_Departament, " +
                "type_controler.typeControler, manager_personal.Date_Admission " +
                "FROM manager_personal " +
                "JOIN Profile ON manager_personal.id_profile=Profile.ID_profile " +
                "LEFT OUTER JOIN Post ON manager_personal.id_post=Post.Id_Post " +
                "LEFT OUTER JOIN Departament ON manager_personal.id_departament=Departament.Id_Departament " +
                "LEFT OUTER JOIN type_controler ON Post.id_typeControler=type_controler.id_typeControler";

            Connection2db connection = new();
            connection.OpenConnection();
            SqliteCommand cmdSelectAllInfoManagers = new(sqlQuery, connection.GetConnection());
            SqliteDataReader sqliteDataReader = cmdSelectAllInfoManagers.ExecuteReader();
            while (sqliteDataReader.Read())
            {
                ManagerPersonal_Info manager = new();
                manager.IdManager = Convert.ToInt32(sqliteDataReader[0]);
                manager.IdProfileManager = Convert.ToInt32(sqliteDataReader[1]);
                manager.LastNameManager = sqliteDataReader[2].ToString();
                manager.FirstNameManager = sqliteDataReader[3].ToString();
                manager.MiddleNameManager = sqliteDataReader[4].ToString();
                manager.BirthdayManager = sqliteDataReader[5].ToString();
                manager.AdressManager = sqliteDataReader[6].ToString();
                manager.PhoneNumberManager = sqliteDataReader[7].ToString();
                manager.PostManager = sqliteDataReader[8].ToString();
                if (DBNull.Value.Equals(sqliteDataReader[9]) == false)
                {
                    manager.DepartamentManager = sqliteDataReader[9].ToString();
                }
                else
                    manager.DepartamentManager = "Нет информации";
                if (DBNull.Value.Equals(sqliteDataReader[10]) == false)
                {
                    manager.TypeControler = sqliteDataReader[10].ToString();
                }
                else
                {
                    manager.TypeControler = "Нет информации"; 
                }
                manager.ManagerDateAdmission = sqliteDataReader[11].ToString();
                ManagersInfo.Add(manager);
            }
            sqliteDataReader.Close();
            connection.CloseConnection();
        }
    }
}
