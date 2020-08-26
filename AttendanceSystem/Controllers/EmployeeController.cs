using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AttendanceSystem.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;

namespace AttendanceSystem.Controllers
{
    public class EmployeeController : Controller
    {
       
        
        public IActionResult Index()
        {
            return View();
        }
       
        public IActionResult CreateNew()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult CreateNew(Pracownik pracownik)
        {
            
                //if valid
            DBQuerrys db = new DBQuerrys();
            db.AddNewEmployee(pracownik.Imie, pracownik.Nazwisko ,pracownik.Stanowisko,pracownik.Uprawnienia, pracownik.Telefon);
            return RedirectToAction("AttendanceSystem", "Home");


        }
        public IActionResult AllUsers()
        {
            //if valid
            DBQuerrys db = new DBQuerrys();
            var empList=db.ShowUsersList();
            return View(empList);
        }

    }
}
