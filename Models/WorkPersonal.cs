using System;
namespace TestFromDeeplayCompany.Models
{
    class WorkPersonal
    {
        public int IdWorkPersonal { get; set; }
        public int IdProfile { get; set; }
        public int IdPost { get; set; }
        public int IdManager { get; set; }
        public DateTime DateAdmission { get; set; }
        public DateTime? DateFired { get; set; }
    }
}
