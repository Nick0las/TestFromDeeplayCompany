using System;


namespace TestFromDeeplayCompany.Models
{
    class Employee
    {
        public int IdEmployee { get; set; }
        public int IdProfile { get; set; }
        public int IdPost { get; set; }
        public int IdDepartament { get; set; }
        public int IdSupervisor { get; set; }
        public DateTime DateAdmission { get; set; }
        public DateTime DateFired { get; set; }
    }
}
