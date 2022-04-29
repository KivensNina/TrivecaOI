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
    public class OrdenTrabajoModel
    {
        private OrdenTrabajoDAO objOT = new OrdenTrabajoDAO();

        public DataTable ListarOTs()
        {
            DataTable tabla = new DataTable();
            tabla = objOT.ListarOTs();
            return tabla;
        }

        public DataTable ListarOTsEnviados()
        {
            DataTable tabla = new DataTable();
            tabla = objOT.ListarOTsEnviados();
            return tabla;
        }

        public void AgregarActualizarOTs(int nro_orden_trabajo, string version_ot, string cod_version_ot, string fecha_version_ot, DateTime fecha_emision_ot, string observaciones,
                                         string estado, int id_usuario, int nro_sol_inspeccion, int id_detalle_estatica, int id_detalle_errores)
        {
            objOT.AgregarActualizarOTs(nro_orden_trabajo, version_ot, cod_version_ot, fecha_version_ot, fecha_emision_ot, observaciones, estado, id_usuario,
                                       nro_sol_inspeccion, id_detalle_estatica, id_detalle_errores);
        }
    }
    
}
