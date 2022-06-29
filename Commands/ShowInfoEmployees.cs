using System;
using System.Windows;
using TestFromDeeplayCompany.Commands.Base;
using TestFromDeeplayCompany.Views.Windows;

namespace TestFromDeeplayCompany.Commands
{
    class ShowInfoEmployees : Command
    {
        private Window_UserInformation _Window;
        public override bool CanExecute(object parameter) => _Window == null;
        public override void Execute(object parameter)
        {
            Window_UserInformation window = new Window_UserInformation
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
