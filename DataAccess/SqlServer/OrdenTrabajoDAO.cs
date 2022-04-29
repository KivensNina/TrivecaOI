using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace DataAccess
{
    public class OrdenTrabajoDAO : coneccionSQL
    {
        private coneccionSQL conexion = new coneccionSQL();
        public SqlDataReader leer;
        DataTable tabla = new DataTable();
        //SqlCommand comando = new SqlCommand();


        public DataTable ListarOTs()
        {
            using (var connection = GetConnection())
            {
                connection.Open();
                using (var command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "listar_sol_inspeccion";
                    command.CommandType = CommandType.StoredProcedure;
                    leer = command.ExecuteReader();
                    tabla.Load(leer);
                    connection.Close();
                    return tabla;
                }
            }
        }

        public DataTable ListarOTsEnviados()
        {
            using (var connection = GetConnection())
            {
                connection.Open();
                using (var command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "listar_solInspec_x_estado_enviado";
                    command.CommandType = CommandType.StoredProcedure;
                    leer = command.ExecuteReader();
                    tabla.Load(leer);
                    connection.Close();
                    return tabla;
                }
            }
        }
        public void AgregarActualizarOTs(int nro_orden_trabajo, string version_ot, string cod_version_ot, string fecha_version_ot, DateTime fecha_emision_ot, string observaciones,
                                         string estado, int id_usuario, int nro_sol_inspeccion, int id_detalle_estatica, int id_detalle_errores)
        {
            using (var connection = GetConnection())
            {
                connection.Open();
                using (var command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "Agregar_Actualizar_OrdenTrabajo";
                    command.Parameters.AddWithValue("@nro_orden_trabajo", nro_orden_trabajo);
                    command.Parameters.AddWithValue("@version_ot", version_ot);
                    command.Parameters.AddWithValue("@cod_version_ot", cod_version_ot);
                    command.Parameters.AddWithValue("@fecha_version_ot", fecha_version_ot);
                    command.Parameters.AddWithValue("@fecha_emision_ot", fecha_emision_ot);
                    command.Parameters.AddWithValue("@observaciones", observaciones);
                    command.Parameters.AddWithValue("@estado", estado);
                    command.Parameters.AddWithValue("@id_usuario", id_usuario);
                    command.Parameters.AddWithValue("@nro_sol_inspeccion", nro_sol_inspeccion);
                    command.Parameters.AddWithValue("@id_detalle_estatica", id_detalle_estatica);
                    command.Parameters.AddWithValue("@id_detalle_errores", id_detalle_errores);
                    command.CommandType = CommandType.StoredProcedure;
                    command.ExecuteNonQuery();
                    command.Parameters.Clear();
                    //visualizar_sol_cotizacion_x_NroInspeccion
                }
            }
        }

    }
}
