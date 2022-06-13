using System;
using TestFromDeeplayCompany.Models;
using TestFromDeeplayCompany.Services;
using TestFromDeeplayCompany.Services.Interfaces;
using TestFromDeeplayCompany.ViewModel.Base;

namespace TestFromDeeplayCompany.ViewModels
{
    internal class NewUser_VM : ViewModel_Base, IDownloadPostFromDb, IDownloadDepartament
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
        private string _adress;
        public string Adress
        {
            get { return _adress; }
            set => Set(ref _adress, value);
        }

        // Телефон
        private string _phone;
        public string Phone
        {
            get { return _phone; }
            set => Set(ref _phone, value);
        }
        // ComboBox Должность
        public Post SelectedPost { get; set; }
        // ComboBox Отдел
        public Departament SelectedDepartament { get; set; }
        
        // Выбор руководителя
        public User SelectedUser { get; set; }
        // Дата приема на работу
        public DateTime DateAdmission { get; set; } = DateTime.Now;

        #endregion



        // Конструктор
        public NewUser_VM()
        {
            IDownloadPostFromDb.ShowPost(Collections.Posts);
            IDownloadDepartament.ShowDepartament(Collections.Departaments);
        }
    }
}
