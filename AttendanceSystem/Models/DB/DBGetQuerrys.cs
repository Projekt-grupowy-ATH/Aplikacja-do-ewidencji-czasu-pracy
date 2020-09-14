using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AttendanceSystem.Models.DB
{
    public class DBGetQuerrys
    {
        public readonly EwidencjaContext _connection;
        public DBGetQuerrys()
        {
            _connection = new EwidencjaContext(); 
        }
        public IEnumerable<EmployeeView> ShowUsersList()
        {
            List<EmployeeView> employeeList = new List<EmployeeView>();

            var item = (from element in _connection.Pracownik
            select new EmployeeView{
                Idpracownika = element.Idpracownika,
                Imie = element.Imie,
                Nazwisko = element.Nazwisko,
                Stanowisko = element.Stanowisko,
                Uprawnienia = element.Uprawnienia,
                Telefon = element.Telefon,
                Email = element.Email
            }).ToList();

            return item;
        }

        public IEnumerable<Projekt> ShowProjectsList()
        {
            List<Projekt> projekts = new List<Projekt>();

            var item = (from element in _connection.Projekt
                        select new Projekt
                        {
                            Idprojektu = element.Idprojektu,
                            NazwaProjektu = element.NazwaProjektu 
                        }).ToList();

            return item;
        }

        public IEnumerable<Projekt> ShowUserTask(string email)
        {
            int id = ShowUserId(email).Idpracownika;

            List<Projekt> projekts = new List<Projekt>();

            var item = (from element in _connection.Projekt
                        select new Projekt
                        {
                            NazwaProjektu = element.NazwaProjektu,
                            Idpracownika = element.Idpracownika
                        }).Where(x => x.Idpracownika == id).ToList();

            return item;
        }
        public EmployeeView ShowUserId(string email)
        {
            EmployeeView employeeList = new EmployeeView();

            var item = (from element in _connection.Pracownik
                        select new EmployeeView
                        {
                            Idpracownika = element.Idpracownika,
                            Email = element.Email
                        }).Where(x => x.Email == email).ToList().FirstOrDefault();

            return item;
        }

    }
}
