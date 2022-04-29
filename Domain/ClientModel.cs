using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using DataAccess.SqlServer;

namespace Domain
{
    public class ClientModel
    {
        //Instanciando ClienteDAO
        private ClientDao objetoCD = new ClientDao();

        public DataTable MostrarCli()
        {
            DataTable tabla = new DataTable();
            tabla = objetoCD.MostrarClientes();
            return tabla;
        }
        
    }
}
