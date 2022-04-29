using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using DataAccess.SqlServer;
using DataAccess;

namespace Domain
{
    public class SolCotModel
    {
        //Instanciando SolCotDao
        private SolCotDao objSC = new SolCotDao();

        public DataTable MostrarSolicCotiz()
        {
            DataTable tabla = new DataTable();
            tabla = objSC.MostrarSolCotAlmacen();
            return tabla;
        }

        public DataTable ListarSolCotEnviados()
        {
            DataTable tabla = new DataTable();
            tabla = objSC.ListarSolCotEnviadosAdministrativoOI();
            return tabla;
        }

        public void AgregarSolCot(string fecha_versionsol, string version_sol, string codigo_version)
        {
            objSC.AgregarSolCotMedSeries(fecha_versionsol, version_sol, codigo_version);
        }

        public void ActualizarSolCotMedList2(int nro_solicitud, DateTime fecha_emision, string tipo_verificacion, int cantidad, string formato,
                                            string observaciones, string estado, int id_cliente, int id_usuario, string id_item, int id_norma)
        {
            objSC.ActualizarSolCotMedList2(nro_solicitud, fecha_emision, tipo_verificacion, cantidad, formato, observaciones, estado, id_cliente, id_usuario, id_item, id_norma);
        }

    }

}

