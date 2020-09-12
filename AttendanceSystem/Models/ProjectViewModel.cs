
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AttendanceSystem.Models
{
	public class ProjectViewModel
	{
		public IEnumerable<EmployeeView> Pracownicy { get; set; }
		
		public Projekt NewProjekt { get; set; }

    }
}
