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
                Imie = element.Imie,
                Nazwisko = element.Nazwisko
            }).ToList();

            return item;
        }


    }
}
