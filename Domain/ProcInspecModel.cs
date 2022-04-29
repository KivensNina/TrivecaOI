using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess;
using System.Data;
using System.Data.SqlClient;

namespace Domain
{
    public class ProcInspecModel
    {
        private ProcInspecDAO objPI = new ProcInspecDAO();

        public DataTable ListarProcInspeccion()
        {
            DataTable tabla = new DataTable();
            tabla = objPI.cargarProc();
            return tabla;
        }
    }
}
