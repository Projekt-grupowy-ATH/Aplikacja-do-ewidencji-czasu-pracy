using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AttendanceSystem.Models
{
    public class DBQuerrys
    {
        readonly EwidencjaContext _connection; 
        
        DBQuerrys()
        {
            _connection = new EwidencjaContext(); 
        }
        public void ShowUsersList()
        {
                var item = (from element in _connection.Pracownik
                select new{
                    name = element.Imie,
                    surname = element.Nazwisko,
                    ID = element.Idpracownika
                }).ToList();
        }

        public void AddNewEmployee(string name, string surname, string job, string permission, int PhoneNumber)
        {
            List<Pracownik> NewEmployee = new List<Pracownik>()
            {
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
    }
}
