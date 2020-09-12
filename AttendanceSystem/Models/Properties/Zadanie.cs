using System;
using System.Collections.Generic;

namespace AttendanceSystem.Models
{
    public partial class Zadanie
    {
        public int Idzadania { get; set; }
        public string NazwaZadania { get; set; }
        public int? Idprojektu { get; set; }

        public virtual Projekt IdprojektuNavigation { get; set; }
    }
}
