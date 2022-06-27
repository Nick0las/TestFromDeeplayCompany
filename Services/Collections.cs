using System;
using System.Collections.ObjectModel;
using TestFromDeeplayCompany.Models;

namespace TestFromDeeplayCompany.Services
{
    class Collections
    {
        // Коллекция для хранения данных о пользователях (анкетные данные).
        public static ObservableCollection<User> Users { get; set; } = new ObservableCollection<User>();

        // Коллекция, хранящая данные о существующих должностях
        public static ObservableCollection<Post> Posts { get; set; } = new ObservableCollection<Post>();
        
        // Коллекция, хранящая данные о существующих отделах
        public static ObservableCollection<Departament> Departaments { get; set; } = new ObservableCollection<Departament>();

        // Коллекция, хранящая данные о руководителях (таблица manager_personal)
        public static ObservableCollection<Manager> Managers { get; set; } = new ObservableCollection<Manager>();

        // Коллекция, хранящая данные о рабочем персонале (таблица WorkPersonal)
        public static ObservableCollection<WorkPersonal> WorkPersonals { get; set; } = new ObservableCollection<WorkPersonal>();

        // Коллекция, хранящая всю информацию о должностях (id, namePost, TypeControler)
        public static ObservableCollection<PostsInfo> PostsInfos { get; set; } = new ObservableCollection<PostsInfo>();

        // Коллекция, хрянаящая информацию об управляющих подразделениями (ФИО, должность, отдел)
        public static ObservableCollection<DepartamentManager> ManagersDepartaments { get; set; } = new ObservableCollection<DepartamentManager>();
        
    }
}
