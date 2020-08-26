using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AttendanceSystem.Models
{
    public class EmployeeView
    {
        public string Imie { get; set; }
        public string Nazwisko { get; set; }
        public string Stanowisko { get; set; }
        public string Uprawnienia { get; set; }
        public int? Telefon { get; set; }
    }
}
