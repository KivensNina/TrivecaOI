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
    public class InspectorModel
    {
        private InspectorDAO objInspec = new InspectorDAO();

        public DataTable ListarInspector()
        {
            DataTable tabla = new DataTable();
            tabla = objInspec.cargarProc();
            return tabla;
        }
    }
}
