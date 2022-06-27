using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestFromDeeplayCompany.Models
{
    class Manager
    {
        public int IdManager { get; set; }
        public int IdProfile { get; set; }
        public int IdPost { get; set; }
        public int IdDepartament { get; set; }
        public int IdContract { get; set; }
        public DateTime DateAdmission { get; set; }
        public DateTime? DateFired { get; set; }

    }
}
