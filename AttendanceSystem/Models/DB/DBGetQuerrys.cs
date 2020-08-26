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

    }
}
