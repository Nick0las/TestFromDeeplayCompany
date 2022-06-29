using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestFromDeeplayCompany.ViewModels
{
    class EditEmployee_VM
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



        #endregion
    }
}
