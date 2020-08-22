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


    }
}
