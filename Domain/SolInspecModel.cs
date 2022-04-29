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
    public class SolInspecModel
    {
        //Instanciando SolCotDao
        private SolInspecDao objSI = new SolInspecDao();

        public DataTable ListarSolicInspec()
        {
            DataTable tabla = new DataTable();
            tabla = objSI.ListarSolInspec();
            return tabla;
        }

        public DataTable ListarSolCotEnviados()
        {
            DataTable tabla = new DataTable();
            tabla = objSI.ListarSolInspecEnviados();
            return tabla;
        }

        public void AgregarActualizarSolInspec(int nro_sol_inspeccion, string fecha_versionsolOI, string version_solOI, string codigo_versionOI, DateTime fecha_emision, DateTime fecha_entrega,
                                     DateTime fecha_recepcionMed, string observaciones, string estado_oi, int nro_solicitud, int id_proc_inspeccion, int id_inspector, int usuario)
        {
            objSI.AgregarActualizarSolInspec(nro_sol_inspeccion, fecha_versionsolOI, version_solOI, codigo_versionOI, fecha_emision, fecha_entrega, fecha_recepcionMed, observaciones, 
                                   estado_oi, nro_solicitud, id_proc_inspeccion, id_inspector, usuario);
        }

    }
}
