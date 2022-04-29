using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace DataAccess
{
    public class SolInspecDao : coneccionSQL
    {
        private coneccionSQL conexion = new coneccionSQL();
        public SqlDataReader leer;
        DataTable tabla = new DataTable();
        //SqlCommand comando = new SqlCommand();

        public DataTable ListarSolInspec()
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

        public DataTable ListarSolInspecEnviados()
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

        public void AgregarActualizarSolInspec(int nro_sol_inspeccion, string fecha_versionsolOI, string version_solOI, string codigo_versionOI, DateTime fecha_emision, DateTime fecha_entrega,
                                     DateTime fecha_recepcionMed, string observaciones, string estado_oi, int nro_solicitud, int id_proc_inspeccion, int id_inspector, int id_usuario)
        {
            using (var connection = GetConnection())
            {
                connection.Open();
                using (var command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "Agregar_Actualizar_SolInspec";
                    command.Parameters.AddWithValue("@nro_sol_inspeccion", nro_sol_inspeccion);
                    command.Parameters.AddWithValue("@fecha_versionsolOI", fecha_versionsolOI);
                    command.Parameters.AddWithValue("@version_solOI", version_solOI);
                    command.Parameters.AddWithValue("@codigo_versionOI", codigo_versionOI);
                    command.Parameters.AddWithValue("@fecha_emision", fecha_emision);
                    command.Parameters.AddWithValue("@fecha_entrega", fecha_entrega);
                    command.Parameters.AddWithValue("@fecha_recepcionMed", fecha_recepcionMed);
                    command.Parameters.AddWithValue("@observaciones", observaciones);
                    command.Parameters.AddWithValue("@estado_oi", estado_oi);
                    command.Parameters.AddWithValue("@nro_solicitud", nro_solicitud);
                    command.Parameters.AddWithValue("@id_proc_inspeccion", id_proc_inspeccion);
                    command.Parameters.AddWithValue("@id_inspector", id_inspector);
                    command.Parameters.AddWithValue("@id_usuario", id_usuario);
                    command.CommandType = CommandType.StoredProcedure;
                    command.ExecuteNonQuery();
                    command.Parameters.Clear();

                }
            }
        }

    }
}
