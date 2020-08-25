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

        public void UpdateEpmloyeeData(string name, string surname, string job, string permission, int phoneNumber)
        {
            List<Pracownik> UpdateEmployee = new List<Pracownik>(){
            new Pracownik(){
                Imie = name,
                Nazwisko = surname,
                Stanowisko = job,
                Uprawnienia = permission,
                Telefon = phoneNumber
            }};

            _connection.UpdateRange(UpdateEmployee);
        }
    }
}
