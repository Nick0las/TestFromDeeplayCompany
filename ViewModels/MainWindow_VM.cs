using System.Windows;
using System.Windows.Input;
using TestFromDeeplayCompany.Commands;
using TestFromDeeplayCompany.Services;
using TestFromDeeplayCompany.Services.Interfaces;
using TestFromDeeplayCompany.ViewModel.Base;
using TestFromDeeplayCompany.Views.Windows;

namespace TestFromDeeplayCompany.ViewModels
{
    class MainWindow_VM : ViewModel_Base, IDownloadProfileFromDB
    {
        #region заголовок окна
        private string _Tittle = "Персонал v1.0";
        /// <summary>Заголовок окна </summary>
        public string Tittle
        {
            get => _Tittle;
            set => Set(ref _Tittle, value);
        }
        #endregion

        #region Команды
        
        #endregion


        public MainWindow_VM()
        {
            IDownloadProfileFromDB.ShowProfile(Collections.Users);
        }
    }
}
