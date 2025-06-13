using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogiTrack.Core.Data
{
    public static class DatabaseConfig
    {
        public static string GetConnectionString()
        {
            return "Server=localhost;Port=5432;Database=logitrack;Uid=root;Pwd=;";
        }

        public static string GetMySqlVersion()
        {
            return "8.0.21"; 
        }
    }
}
