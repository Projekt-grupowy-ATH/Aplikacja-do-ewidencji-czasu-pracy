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
        public string ShowUsersList()
        {
            var item = (from element in _connection.Pracownik
                select new{
                    name = element.Imie,
                    surname = element.Nazwisko,
                    ID = element.Idpracownika
                }).ToList();
            foreach(var a in item)
            {
                Console.WriteLine(a);
            }
            return item.ToString();
        }
    }
}
