using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AttendanceSystem.Models
{
    public class DBUpdateQuerrys
    {
        readonly EwidencjaContext _connection; 
        
        public DBUpdateQuerrys()
        {
            _connection = new EwidencjaContext(); 
        }

        public void UpdateEpmloyeeData(int Id, string name, string surname, string job, string permission, int? phoneNumber)
        {
            List <Pracownik> CurrentSettings = new List<Pracownik>();

            CurrentSettings = _connection.Pracownik.Where(s => s.Idpracownika == Id).Select(s => new Pracownik {
                Idpracownika = s.Idpracownika,
                Imie = s.Imie,
                Nazwisko = s.Nazwisko,
                Stanowisko = s.Stanowisko,
                Uprawnienia = s.Uprawnienia,
                Telefon = s.Telefon,
                Email = s.Email
            }).ToList();

            CurrentSettings.ForEach(s =>
            {
                s.Imie = name;
                s.Nazwisko = surname;
                s.Stanowisko = job;
                s.Uprawnienia = permission;
                s.Telefon = phoneNumber;
                s.Email = s.Email;
            });

            _connection.UpdateRange(CurrentSettings);
            _connection.SaveChanges();
        }
    }
}
