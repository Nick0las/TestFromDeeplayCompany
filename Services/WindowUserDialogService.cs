using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using TestFromDeeplayCompany.Models;
using TestFromDeeplayCompany.Services.Interfaces;
using TestFromDeeplayCompany.Views.Windows;

namespace TestFromDeeplayCompany.Services
{
    class WindowUserDialogService : IUserDialogService
    {
        public bool Edit(object item)
        {
            if (item is null)
                throw new ArgumentNullException(nameof(item));

            switch (item)
            {
                default: 
                    throw new NotSupportedException
                        ($"Редактирование объекта типа {item.GetType().Name} не поддерживается");
                case User user:
                    return EditUser(user);                
            }
                
        }


        public bool Confirm(string Message, string Caption, bool Exclamation) =>
            MessageBox.Show(
                Message,
                Caption,
                MessageBoxButton.YesNo,
                Exclamation ? MessageBoxImage.Exclamation : MessageBoxImage.Question)
                == MessageBoxResult.Yes;

        public void ShowError(string Message, string Caption) =>
            MessageBox.Show(Message, Caption, MessageBoxButton.OK, MessageBoxImage.Error);

        public void ShowInformation(string Information, string Caption) =>
            MessageBox.Show(Information, Caption, MessageBoxButton.OK, MessageBoxImage.Information);

        public void ShowWarning(string Message, string Caption) =>
            MessageBox.Show(Message, Caption, MessageBoxButton.OK, MessageBoxImage.Warning);

        private static bool EditUser(User user)
        {
            var dlg = new Window_NewUser();
            if (dlg.ShowDialog() == true)
            {
                MessageBox.Show("Пользователь создан!");
            }
            else
                MessageBox.Show("Админ отказался!");

            if (dlg.ShowDialog() != true)
                return false;

            return dlg.ShowDialog() == true;
        }
    }
}
