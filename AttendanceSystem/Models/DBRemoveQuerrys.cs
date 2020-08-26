using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AttendanceSystem.Models
{
    public class DBRemoveQuerrys
    {
        public readonly EwidencjaContext _connection;
        public DBRemoveQuerrys()
        {
            _connection = new EwidencjaContext(); 
        }
        
        public void RemoveEmployee(int id)
        {
            var RemovalItem = _connection.Pracownik.Where(s => s.Idpracownika == id);

            _connection.Remove(RemovalItem);
            _connection.SaveChanges();
        }

    }
}
