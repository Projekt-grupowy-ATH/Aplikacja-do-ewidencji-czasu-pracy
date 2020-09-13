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

        private readonly EwidencjaContext _db;
        private readonly DBCreateQuerrys _connectionADD;
        private readonly DBGetQuerrys _connectionGET;

        public EmployeeController(EwidencjaContext db,
            DBCreateQuerrys connectionADD,
            DBGetQuerrys connectionGET)
        {
            _db = db;
            _connectionADD = connectionADD;
            _connectionGET = connectionGET;
        }

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
            _connectionADD.AddNewEmployee(pracownik.Imie, pracownik.Nazwisko, pracownik.Stanowisko,
                pracownik.Uprawnienia, pracownik.Email, pracownik.Telefon);

           // return RedirectToPage("/Home/AttendanceSystem");
            return RedirectToAction("AttendanceSystem", "Home");
        }
        [Authorize(Roles = "Admin")]
        public IActionResult AllUsers()
        {
            //if valid
            var empList = _connectionGET.ShowUsersList();
            return View(empList);
        }


        // GET: Menu/Edit/5
        [Authorize(Roles = "Admin")]
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pracownik = _db.Pracownik.Find(id);
            if (pracownik == null)
            {
                return NotFound();
            }
            return View(pracownik);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public IActionResult Edit(int id, [Bind("Id,Imie,Nazwisko,Stanowisko,Uprawnienia,Telefon")] Pracownik pracownik)
        {

            if (ModelState.IsValid)
            {
                try
                {
                    DBUpdateQuerrys db = new DBUpdateQuerrys();
                    db.UpdateEpmloyeeData(id, pracownik.Imie, pracownik.Nazwisko, pracownik.Stanowisko, pracownik.Uprawnienia, pracownik.Telefon);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PracownikModelExists(pracownik.Idpracownika))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction("AllUsers", "Employee");
            }
            return RedirectToAction("AllUsers", "Employee");
        }

        [Authorize(Roles = "Admin")]
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var menuModel = _db.Pracownik
                .FirstOrDefault(m => m.Idpracownika == id);
            if (menuModel == null)
            {
                return NotFound();
            }

            return View(menuModel);
        }
        // POST: Menu/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public IActionResult DeleteConfirmed(int id)
        {
            var menuModel = _db.Pracownik.Find(id);
            _db.Pracownik.Remove(menuModel);
            _db.SaveChanges();
            return RedirectToAction(nameof(AllUsers));
        }
        private bool PracownikModelExists(int id)
        {
            return _db.Pracownik.Any(e => e.Idpracownika == id);
        }

        [Authorize(Roles = "Admin")]
        public IActionResult CreateNewProject()
        {
            DBGetQuerrys db = new DBGetQuerrys();
            ProjectViewModel model = new ProjectViewModel()
            {
                
                Pracownicy = db.ShowUsersList(),
                NewProjekt = new Projekt()
            };

            return View(model);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public IActionResult CreateNewProject(ProjectViewModel model)
        {
            _db.Projekt.Add(model.NewProjekt);
            _db.SaveChanges();
            return RedirectToAction("AttendanceSystem", "Home");
        }
    }
}