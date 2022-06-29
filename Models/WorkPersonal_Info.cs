using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestFromDeeplayCompany.Models
{
    class WorkPersonal_Info
    {
        public int IdProfileWorkPersonal { get; set; }
        public int IdWorkPersonal { get; set; }
        public string LastNameWorkPersonal { get; set; }
        public string FirstNameWorkPersonal { get; set; }
        public string MiddleNameWorkPersonal { get; set; }
        public string BirthdayWorkPersonal { get; set; }
        public string AdressWorkPersonal { get; set; }
        public string PhoneNumberWorkPersonal { get; set;  }
        public string PostWorkPersonal { get; set; }
        public int PersonalManagerIdProfile { get; set; }
        public int PersonalManagerIdManager { get; set; }
        public string PersonalManagerLastName { get; set; }
        public string PersonalManagerFirstName { get; set; }
        public string PersonalManagerMiddleName { get; set; }
        public string PersonalManagerDepartament { get; set; }
        public string WorkPersonalDateAdmission { get; set; }
    }
}
