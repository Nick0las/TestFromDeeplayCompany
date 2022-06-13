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
        
        // Коллекция, хранящая данные о всех сотрудниках
        public static ObservableCollection<Employee> Employees { get; set; } = new ObservableCollection<Employee>();
        

    }
}
