using System;
using System.Collections.Generic;

namespace AttendanceSystem.Models
{
    public partial class Pracownik
    {
        public Pracownik()
        {
            Projekt = new HashSet<Projekt>();
        }

        public int Idpracownika { get; set; }
        public string Imie { get; set; }
        public string Nazwisko { get; set; }
        public string Stanowisko { get; set; }
        public string Uprawnienia { get; set; }
        public int? Telefon { get; set; }
        public string Email { get; set; }

        public virtual ICollection<Projekt> Projekt { get; set; }
    }
}
