using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace DataAccess
{
    public class coneccionSQL
    {
        private readonly string connectionstring;
        public coneccionSQL()
        {
            connectionstring = "server = DESKTOP-1N4BB84\\TRIVECA; database=oitriveca; uid=sa; pwd=trivecaweb2014$5";
        }
        protected SqlConnection GetConnection()
        {
            return new SqlConnection(connectionstring);
        }
        
    }
}
