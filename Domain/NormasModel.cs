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
    public class NormasModel
    {
        private NormasDAO objNormas = new NormasDAO();

        public DataTable ListarInspector()
        {
            DataTable tabla = new DataTable();
            tabla = objNormas.cargarNormas();
            return tabla;
        }
    }
}
