using System;
using System.Collections.Generic;

namespace AttendanceSystem.Models
{
    public partial class Wykonanie
    {
        public DateTime PoczZadania { get; set; }
        public DateTime ZakZadania { get; set; }
        public int? SumaGodzin { get; set; }
        public int? Idpracownika { get; set; }
        public int? Idzadania { get; set; }

        public virtual Pracownik IdpracownikaNavigation { get; set; }
        public virtual Zadanie IdzadaniaNavigation { get; set; }
    }
}
