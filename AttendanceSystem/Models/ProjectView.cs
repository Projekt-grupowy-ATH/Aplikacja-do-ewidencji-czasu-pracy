using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AttendanceSystem.Models
{
    public class ProjectView
    {
        public IEnumerable<Pracownik> EmployeeList { get; set; }
        public Projekt projekt { get; set; }

    }
}
