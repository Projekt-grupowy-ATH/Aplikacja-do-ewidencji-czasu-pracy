using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AttendanceSystem.Models;
using AttendanceSystem.Models.DB;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;

namespace AttendanceSystem.Controllers
{
    public class EmployeeController : Controller
    {
       
        [Authorize(Roles = "Admin")]
        public IActionResult Index()
        {
            return View();
        }
       [Authorize(Roles = "Admin")]
        public IActionResult CreateNew()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public IActionResult CreateNew(Pracownik pracownik)
        {

            //if valid
            DBCreateQuerrys db = new DBCreateQuerrys();
            db.AddNewEmployee(pracownik.Imie, pracownik.Nazwisko ,pracownik.Stanowisko,pracownik.Uprawnienia, pracownik.Email ,pracownik.Telefon);
            return RedirectToAction("AttendanceSystem", "Home");


        }
        [Authorize(Roles = "Admin")]
        public IActionResult AllUsers()
        {
            //if valid
            DBGetQuerrys db = new DBGetQuerrys();
            var empList=db.ShowUsersList();
            return View(empList);
        }

    }
}
