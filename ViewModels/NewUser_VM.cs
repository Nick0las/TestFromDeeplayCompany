using Microsoft.Data.Sqlite;
using System;
using System.Windows;
using System.Windows.Input;
using TestFromDeeplayCompany.Commands;
using TestFromDeeplayCompany.Data;
using TestFromDeeplayCompany.Models;
using TestFromDeeplayCompany.Services;
using TestFromDeeplayCompany.Services.Interfaces;
using TestFromDeeplayCompany.ViewModel.Base;


namespace TestFromDeeplayCompany.ViewModels
{
    internal class NewUser_VM : ViewModel_Base, IDownloadPostFromDb, IDownloadDepartament, IDownloadProfileFromDB
    {
        #region заголовок окна
        private string _Tittle = "Новый сотрудник (анкета)";
        /// <summary>Заголовок окна </summary>
        public string Tittle
        {
            get => _Tittle;
            set => Set(ref _Tittle, value);
        }
        #endregion

        #region Свойства, привязанные к окну
       // Фамилия
        private string _surname;
        public string Surname
        {
            get { return _surname; }
            set => Set(ref _surname, value);
        }
        // Имя
        private string _name;
        public string Name
        {
            get { return _name; }
            set => Set(ref _name, value);
        }
        // Отчество
        private string _middleName;
        public string MiddleName
        {
            get { return _middleName; }
            set => Set(ref _middleName, value);
        }
        // Дата рождения
        public DateTime UserBirthday { get; set; } = DateTime.Now;
        // Домашний адрес
        private string _address;
        public string Address
        {
            get { return _address; }
            set => Set(ref _address, value);
        }

        // Телефон
        private string _phone;
        public string Phone
        {
            get { return _phone; }
            set => Set(ref _phone, value);
        }
        // ComboBox Должность
        public PostsInfo SelectedPost { get; set; }
        // ComboBox Отдел
        public Departament SelectedDepartament { get; set; }
        
        // Выбор руководителя
        public DepartamentManager SelectedUser { get; set; }
        // Дата приема на работу
        public DateTime DateAdmission { get; set; } = DateTime.Now;
        public DateTime EndDateContract { get; set; } = DateTime.Now;

        #endregion

        #region Команда добавления нового сотрудника
        public ICommand AddNewEmployeeCmd { get; }
        private bool CanAddNewEmployeeCmdExecute(object p) => true;
        private void OnAddNewEmployeeCmdExecuted(object p)
        {
            int lastId;
            int date = 0;
            if(Surname == null || Name == null || MiddleName == null || Address == null || UserBirthday == DateTime.Today)
            {
                MessageBox.Show("Заполните все данные о новом сотруднике!", "Внимание!", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            switch (SelectedPost.IdPost)
            {
                case 1:
                    if (EndDateContract == DateTime.Today)
                    {
                        MessageBoxResult result = MessageBox.Show("Выбрана текущая дата договора! Измените!", "Внимание! Измените дату договора!", MessageBoxButton.OK, MessageBoxImage.Warning);
                        return;
                    }
                    else
                    {
                        lastId = AddNewProfile();
                        date = AddNewDateContract();
                        AddNewManager(lastId, date);
                        MessageBox.Show("Сотрудник добавлен!", "Внимание!", MessageBoxButton.OK, MessageBoxImage.Information);
                    }
                    break;
                case 2 or 3 or 4:
                    lastId = AddNewProfile();
                    AddNewManager(lastId, date);
                    MessageBox.Show("Сотрудник добавлен!", "Внимание!", MessageBoxButton.OK, MessageBoxImage.Information);
                    break;
                case 5:
                    lastId = AddNewProfile();
                    AddNewWorkPersonal(lastId);
                    MessageBox.Show("Сотрудник добавлен!", "Внимание!", MessageBoxButton.OK, MessageBoxImage.Information);
                    break;
            }
            Surname = "";
            Name = "";
            MiddleName = "";
            Address = "";
            Phone = "";
            UserBirthday = DateTime.Now;
            //Collections.WorkPersonals.Clear();
            //Collections.Managers.Clear();
            Collections.Users.Clear();
            IDownloadProfileFromDB.ShowProfile(Collections.Users);
        }

        #endregion


        // Конструктор
        public NewUser_VM()
        {
            Collections.PostsInfos.Clear();
            Collections.Posts.Clear();
            Collections.ManagersDepartaments.Clear();
            Collections.Users.Clear();
            AddNewEmployeeCmd = new LamdaCommand(OnAddNewEmployeeCmdExecuted, CanAddNewEmployeeCmdExecute);
            IDownloadProfileFromDB.ShowProfile(Collections.Users);
            IDownloadPostFromDb.ShowPost(Collections.Posts);
            IDownloadPostFromDb.ShowPostInfo(Collections.PostsInfos);
            IDownloadPostFromDb.ShowManagerDepartament(Collections.ManagersDepartaments);
            IDownloadDepartament.ShowDepartament(Collections.Departaments);
        }

        #region Методы
        // Заполнение таблицы Profile в БД (анкета сотрудника)
        private int AddNewProfile()
        {
            string surname = "'" + Surname + "', ";
            string name = "'" + Name + "', " ;
            string middleName = "'" + MiddleName + "', ";
            string birthday = "'" + UserBirthday.ToShortDateString() + "', ";
            string address = "'" + Address + "', ";
            string phoneNumber = "'" + Phone + "')";
            string sqlQueryAddProfile2Db = "INSERT INTO Profile VALUES (NULL, " + surname + name + middleName + birthday + address + phoneNumber;

            int lastId = 0;
            string sqlLastIdProfile = "SELECT  max(Id_profile) FROM Profile";

            Connection2db connection = new Connection2db();
            connection.OpenConnection();
            SqliteCommand cmdInsertNewProfile = new(sqlQueryAddProfile2Db, connection.GetConnection());
            cmdInsertNewProfile.ExecuteNonQuery();

            // Получение Id добавленной записи
            SqliteCommand cmdSelectLastId = new(sqlLastIdProfile, connection.GetConnection());
            SqliteDataReader sqliteDataReader = cmdSelectLastId.ExecuteReader();
            while (sqliteDataReader.Read())
            {
                lastId = Convert.ToInt32(sqliteDataReader[0]);
            }
            connection.CloseConnection();
            return lastId;
        }

        // Регистрация нового сотрудника (manager_personal)
        private void AddNewManager(int profile, int dateContract)
        {
            int idPost = SelectedPost.IdPost;
            //int? idDepartament = SelectedDepartament.IdDepartment;
            string dateAdmission = "'" + DateAdmission.ToShortDateString() + "' ";
            string sqlQuery = "";
            
            switch(idPost)
            {
                case 1:
                    sqlQuery = "INSERT INTO manager_personal VALUES (NULL, " + profile + ", " + idPost + ", " + "NULL, " + dateContract + ", " + dateAdmission + ", NULL)";
                    break;
                case 2:
                    sqlQuery = "INSERT INTO manager_personal VALUES (NULL, " + profile + ", " + idPost + ", " + SelectedDepartament.IdDepartment + ", NULL, " + dateAdmission + ", NULL)";
                    break;
                case 3 or 4:
                    sqlQuery = "INSERT INTO manager_personal VALUES (NULL, " + profile + ", " + idPost + ", NULL, NULL, "  + dateAdmission + ", NULL)";
                    break;
            }

            Connection2db connection = new Connection2db();
            connection.OpenConnection();
            SqliteCommand cmdInsertIntoManagerPersonal = new(sqlQuery, connection.GetConnection());
            cmdInsertIntoManagerPersonal.ExecuteNonQuery();
            connection.CloseConnection();
        }

        // Регистрация нового сотрудника (работник)
        private void AddNewWorkPersonal(int profile)
        {
            string dateAdmission = "'" + DateAdmission.ToShortDateString() + "', NULL)";
            string sqlQuery = "INSERT INTO work_personal VALUES (NULL, " + profile + ", " + SelectedPost.IdPost + ", " + SelectedUser.IdProfile + ", " + dateAdmission;
            
            Connection2db connection = new Connection2db();
            connection.OpenConnection();
            SqliteCommand cmdInsertIntoWorkPersonal = new(sqlQuery, connection.GetConnection());
            cmdInsertIntoWorkPersonal.ExecuteNonQuery();
            connection.CloseConnection();
        }


        // Заполнение таблицы Contract (для должности "Директор"), получение ID последней записи
        private int AddNewDateContract()
        {
            string date = "'" + EndDateContract.ToShortDateString() + "')";
            string sqlQuery = "INSERT INTO contract VALUES (NULL, " + date;

            int lastId = 0;
            string sqlLastIdContract = "SELECT  max(id_contract) FROM contract";

            Connection2db connection = new Connection2db();
            connection.OpenConnection();
            SqliteCommand cmdInsertNewContract = new(sqlQuery, connection.GetConnection());
            cmdInsertNewContract.ExecuteNonQuery();

            // Получение Id добавленной записи
            SqliteCommand cmdSelectLastId = new(sqlLastIdContract, connection.GetConnection());
            SqliteDataReader sqliteDataReader = cmdSelectLastId.ExecuteReader();
            while (sqliteDataReader.Read())
            {
                lastId = Convert.ToInt32(sqliteDataReader[0]);
            }
            connection.CloseConnection();
            return lastId;
        }

        #endregion
    }
}
