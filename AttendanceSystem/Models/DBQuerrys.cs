using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AttendanceSystem.Models
{
    public class DBQuerrys
    {
        readonly EwidencjaContext _connection; 
        
        public DBQuerrys()
        {
            _connection = new EwidencjaContext(); 
        }
        public IEnumerable<EmployeeView> ShowUsersList()
        {
            List<EmployeeView> employeeList = new List<EmployeeView>();

                var item = (from element in _connection.Pracownik
                select new EmployeeView{
                    Imie = element.Imie,
                    Nazwisko = element.Nazwisko,
                    Stanowisko = element.Stanowisko,
                    Uprawnienia = element.Uprawnienia,
                    Telefon = element.Telefon,
                }).ToList();


            return item;
        }
        
        public void AddNewEmployee(string name, string surname, string job, string permission, int? PhoneNumber)
        {
            List<Pracownik> NewEmployee = new List<Pracownik>(){
            new Pracownik(){
                Imie = name,
                Nazwisko = surname,
                Stanowisko = job,
                Uprawnienia = permission,
                Telefon = PhoneNumber
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
