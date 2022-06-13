using System;
using System.Windows;
using TestFromDeeplayCompany.Commands.Base;
using TestFromDeeplayCompany.Views.Windows;

namespace TestFromDeeplayCompany.Commands
{
    class AddNewUserCommand : Command
    {
        private Window_NewUser _Window;
        public override bool CanExecute(object parameter) => _Window == null;
        public override void Execute(object parameter)
        {
            Window_NewUser window = new Window_NewUser
            {
                Owner = Application.Current.MainWindow
            };
            _Window = window;
            window.Closed += OnWindowClosed;
            window.ShowDialog();
        }
        private void OnWindowClosed(object Sender, EventArgs E)
        {
            ((Window)Sender).Closed -= OnWindowClosed;
            _Window = null;
        }
    }
}
