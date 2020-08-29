using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AttendanceSystem.Models;
using AttendanceSystem.Models.DB;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;

namespace AttendanceSystem.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly EwidencjaContext _db;
        public EmployeeController(EwidencjaContext db)
        {
            _db = db;
        }
        
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
            DBCreateQuerrys db = new DBCreateQuerrys();
            db.AddNewEmployee(pracownik.Imie, pracownik.Nazwisko ,pracownik.Stanowisko,pracownik.Uprawnienia, pracownik.Email ,pracownik.Telefon);
            return RedirectToAction("AttendanceSystem", "Home");


        }
        public IActionResult AllUsers()
        {
            //if valid
            DBGetQuerrys db = new DBGetQuerrys();
            var empList=db.ShowUsersList();
            return View(empList);
        }

        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();

            }
            var employee = _db.Pracownik.Find(id);
            if (employee == null)
            {
                return NotFound();
            }
            return View(employee);
            
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Pracownik pracownik,int id)
        {

                DBUpdateQuerrys db = new DBUpdateQuerrys();
                db.UpdateEpmloyeeData(id, pracownik.Imie, pracownik.Nazwisko, pracownik.Stanowisko, pracownik.Uprawnienia, pracownik.Telefon);
                return RedirectToAction("AllUsers", "Employee");


        }

    }
}
