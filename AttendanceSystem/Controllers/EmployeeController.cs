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
        public EmployeeController(EwidencjaContext db)
        {
            _db = db;
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
            DBCreateQuerrys db = new DBCreateQuerrys();
            db.AddNewEmployee(pracownik.Imie, pracownik.Nazwisko, pracownik.Stanowisko, pracownik.Uprawnienia, pracownik.Email, pracownik.Telefon);
            return RedirectToAction("AttendanceSystem", "Home");


        }
        [Authorize(Roles = "Admin")]
        public IActionResult AllUsers()
        {
            //if valid
            DBGetQuerrys db = new DBGetQuerrys();
            var empList = db.ShowUsersList();
            return View(empList);
        }

        //public IActionResult Edit(int? id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();

        //    }

        //    var employee = _db.Pracownik.Where(s => s.Idpracownika == id);
        //    if (employee == null)
        //    {
        //        return NotFound();
        //    }
        //    return View(employee);

        //}
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
            //int idP = pracownik.Idpracownika;
            //if (id != idP)
            //{
            //    return NotFound();
            //}

            if (ModelState.IsValid)
            {
                try
                {
                    //_db.Update(pracownik);
                    DBUpdateQuerrys db = new DBUpdateQuerrys();
                    db.UpdateEpmloyeeData(id, pracownik.Imie, pracownik.Nazwisko, pracownik.Stanowisko, pracownik.Uprawnienia, pracownik.Telefon);
                    //_db.SaveChanges();
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
                //return RedirectToAction(nameof(AllUsers));
                return RedirectToAction("AllUsers", "Employee");
            }
            //return View(pracownik);
            return RedirectToAction("AllUsers", "Employee");
        }
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public IActionResult Edit(int id, Pracownik pracownik)
        //{

        //    DBUpdateQuerrys db = new DBUpdateQuerrys();
        //    db.UpdateEpmloyeeData(id, pracownik.Imie, pracownik.Nazwisko, pracownik.Stanowisko, pracownik.Uprawnienia, pracownik.Telefon);

        //    return RedirectToAction("AllUsers", "Employee");


        //}
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
    }
}