using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AttendanceSystem.Models
{
    public class DBCreateQuerrys
    {
        readonly EwidencjaContext _connection; 
        
        public DBCreateQuerrys()
        {
            _connection = new EwidencjaContext(); 
        }
               
        public void AddNewEmployee(string name, string surname, string job, string permission, string email, int? phoneNumber)
        {
            List<Pracownik> NewEmployee = new List<Pracownik>(){
            new Pracownik(){
                Imie = name,
                Nazwisko = surname,
                Stanowisko = job,
                Uprawnienia = permission,
                Telefon = phoneNumber,
                Email = email
            }};

            _connection.Pracownik.AddRange(NewEmployee);
            _connection.SaveChanges();
        }

        public void AddNewProject(string projectTitle)
        {
            List<Projekt> NewProject = new List<Projekt>(){
                new Projekt(){ 
                    NazwaProjektu = projectTitle
                }};
            _connection.Projekt.AddRange(NewProject);
            _connection.SaveChanges();
        }

        public void AddNewTaskToProject(string projectTitle, string taskTitle)
        {
            var _projectID = _connection.Projekt.Where(s => s.NazwaProjektu == projectTitle).Select(s => s.Idprojektu).FirstOrDefault();

            List<Zadanie> NewTask = new List<Zadanie>(){
                new Zadanie(){
                    NazwaZadania = taskTitle,
                    Idprojektu = _projectID
                }};
            _connection.Zadanie.AddRange(NewTask);
            _connection.SaveChanges();
        }

    }
}
