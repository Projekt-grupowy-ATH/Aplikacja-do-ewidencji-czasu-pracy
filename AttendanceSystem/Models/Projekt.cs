using System;
using System.Collections.Generic;

namespace AttendanceSystem.Models
{
    public partial class Projekt
    {
        public Projekt()
        {
            Zadanie = new HashSet<Zadanie>();
        }

        public int Idprojektu { get; set; }
        public string NazwaProjektu { get; set; }
        public int? Idpracownika { get; set; }

        public virtual Pracownik IdpracownikaNavigation { get; set; }
        public virtual ICollection<Zadanie> Zadanie { get; set; }
    }
}
