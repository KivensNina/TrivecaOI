using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace DataAccess
{
    public class SolCotDao : coneccionSQL
    {
        private coneccionSQL conexion = new coneccionSQL();
        public SqlDataReader leer;
        DataTable tabla = new DataTable();
        //SqlCommand comando = new SqlCommand();

        public DataTable MostrarSolCotAlmacen()
        {
            using (var connection = GetConnection())
            {
                connection.Open();
                using (var command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "listar_sol_cotizacion_mod_almacen";
                    command.CommandType = CommandType.StoredProcedure;
                    leer = command.ExecuteReader();
                    tabla.Load(leer);
                    connection.Close();
                    return tabla;
                }
            }
        }

        public DataTable ListarSolCotEnviadosAdministrativoOI()
        {
            using (var connection = GetConnection())
            {
                connection.Open();
                using (var command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "listar_solCot_enviadas_mod_Administrativo_OI";
                    command.CommandType = CommandType.StoredProcedure;
                    leer = command.ExecuteReader();
                    tabla.Load(leer);
                    connection.Close();
                    return tabla;
                }
            }
        }

        //public void nrosol(string codsol)
        //{
        //    using (var connection = GetConnection())
        //    {
        //        connection.Open();
        //        using (var command = new SqlCommand())
        //        {
        //            command.CommandText = codsol;
        //            leer = command.ExecuteReader();
        //
        //        }
        //    }
        //}

        public void AgregarSolCotMedSeries(string fecha_versionsol, string version_sol, string codigo_version)
        {
            using (var connection = GetConnection())
            {
                connection.Open();
                using (var command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "agregar_nroSolCotMed";
                    command.Parameters.AddWithValue("@fecha_versionsol", fecha_versionsol);
                    command.Parameters.AddWithValue("@version_sol", version_sol);
                    command.Parameters.AddWithValue("@codigo_version", codigo_version);
                    command.CommandType = CommandType.StoredProcedure;
                    command.ExecuteNonQuery();
                    command.Parameters.Clear();

                }
            }
        }
        
        public void ActualizarSolCotMedList2(int nro_solicitud, DateTime fecha_emision, string tipo_verificacion, int cantidad, string formato,
                                            string observaciones, string estado, int id_cliente,int id_usuario, string id_item, int id_norma)
        {
            using (var connection = GetConnection())
            {
                connection.Open();
                using (var command = new SqlCommand())
                {
                    SqlDataAdapter da = new SqlDataAdapter();
                    command.Connection = connection;
                    command.CommandText = "actualizar_solicitud_cotizacion";
                    command.Parameters.AddWithValue("@nro_solicitud", nro_solicitud);
                    command.Parameters.AddWithValue("@fecha_emision", fecha_emision);
                    command.Parameters.AddWithValue("@tipo_verificacion", tipo_verificacion);
                    command.Parameters.AddWithValue("@cantidad", cantidad);
                    command.Parameters.AddWithValue("@formato", formato); 
                    command.Parameters.AddWithValue("@estado", estado);
                    command.Parameters.AddWithValue("@observaciones", observaciones);
                    command.Parameters.AddWithValue("@id_cliente", id_cliente);
                    command.Parameters.AddWithValue("@id_usuario", id_usuario);
                    command.Parameters.AddWithValue("@id_item", id_item);
                    command.Parameters.AddWithValue("@id_norma", id_norma);
                    command.CommandType = CommandType.StoredProcedure;
                    command.ExecuteNonQuery();
                    command.Parameters.Clear();
                    connection.Close();
                }
            }
        }
    }
}
