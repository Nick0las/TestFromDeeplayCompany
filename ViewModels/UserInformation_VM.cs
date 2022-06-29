using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestFromDeeplayCompany.Models;
using TestFromDeeplayCompany.Services;
using TestFromDeeplayCompany.Services.Interfaces;
using TestFromDeeplayCompany.ViewModel.Base;

namespace TestFromDeeplayCompany.ViewModels
{
    class UserInformation_VM : ViewModel_Base, IDownload_ManagerAllInfo, IDownloadWorkPersonal_Info
    {
        #region Свойства, прявязанные к окну

        #region заголовок окна
        private string _Tittle = "Информация о сотрудниках";
        /// <summary>Заголовок окна </summary>
        public string Tittle
        {
            get => _Tittle;
            set => Set(ref _Tittle, value);
        }
        #endregion

        //Выбор управляющего персонала
        /// <summary>Выбранный сотрудник управляющего персонала</summary>
        private ManagerPersonal_Info _SelectedManager;
        public ManagerPersonal_Info SelectedManager
        {
            get => _SelectedManager;
            set => Set(ref _SelectedManager, value);
        }

        // Выбор рабочего персонала
        /// <summary>Выбранный сотрудник рабочего персонала</summary>
        private WorkPersonal_Info _SelectedWorkPersonal;
        public WorkPersonal_Info SelectedWorkPersonal
        {
            get => _SelectedWorkPersonal;
            set => Set(ref _SelectedWorkPersonal, value);
        }

        #endregion

        public UserInformation_VM()
        {
            Collections.ManagersInfo.Clear();
            Collections.WorkPersonals_Info.Clear();
            IDownloadWorkPersonal_Info.ShowAllWorkPersonalInfo(Collections.WorkPersonals_Info);
            IDownload_ManagerAllInfo.ShowAllManagerInfo(Collections.ManagersInfo);
        }
    }
}
