using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AttendanceSystem.Models.Properties
{
    public class TaskViewModel
    {
        public IEnumerable<Projekt> Projekts { get; set; }

        public Zadanie Zadanies { get; set; }
    }
}
