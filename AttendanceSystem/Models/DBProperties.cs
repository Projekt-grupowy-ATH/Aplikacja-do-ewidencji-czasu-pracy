using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AttendanceSystem.Models
{
    public class User
    {
        public string UserID { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Password { get; set; }
        public string Job { get; set; }
        public string TypeOfUser { get; set; }
    }

    public class Project
    {
        public int IDProjektu { get; set; }
        public string NazwaProjektu { get; set; }
        public Nullable<int> IDPracownika { get; set; }
    
        public virtual Pracownik Pracownik { get; set; }
        public virtual ICollection<Zadanie> Zadanie { get; set; }
    }

}
