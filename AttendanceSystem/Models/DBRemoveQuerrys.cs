using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AttendanceSystem.Models
{
    public class DBRemoveQuerrys
    {
        readonly EwidencjaContext _connection;
          public DBRemoveQuerrys()
        {
            _connection = new EwidencjaContext(); 
        }

    }
}
