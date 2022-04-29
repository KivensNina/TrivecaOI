using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace DataAccess
{
    public class BancosDAO : coneccionSQL
    {
        private coneccionSQL conexion = new coneccionSQL();
        public SqlDataReader leer;
        DataTable tabla = new DataTable();

        public DataTable ListarBancosPE()
        {
            using (var connection = GetConnection())
            {
                connection.Open();
                using (var command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "listar_bancos_PE";
                    command.CommandType = CommandType.StoredProcedure;
                    leer = command.ExecuteReader();
                    tabla.Load(leer);
                    connection.Close();
                    return tabla;
                }
            }
        }
        public DataTable ListarBancosPEI()
        {
            using (var connection = GetConnection())
            {
                connection.Open();
                using (var command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "listar_bancos_PEI";
                    command.CommandType = CommandType.StoredProcedure;
                    leer = command.ExecuteReader();
                    tabla.Load(leer);
                    connection.Close();
                    return tabla;
                }
            }
        }
        public void AgregarDetalleBancosPE(string turno_inspeccion,string tipo_ensayo, int id_inspector, string id_banco_estatica)
        {
            using (var connection = GetConnection())
            {
                connection.Open();
                using (var command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "agregar_detalle_inspeccion_PE";
                    command.Parameters.AddWithValue("@turno_inspeccion", turno_inspeccion);
                    command.Parameters.AddWithValue("@tipo_ensayo", tipo_ensayo);
                    command.Parameters.AddWithValue("@id_inspector", id_inspector);
                    command.Parameters.AddWithValue("@id_banco_estatica", id_banco_estatica);
                    command.CommandType = CommandType.StoredProcedure;
                    command.ExecuteNonQuery();
                    command.Parameters.Clear();

                }
            }
        }
        public void AgregarDetalleBancosPEI(string turno_inspeccion, string tipo_ensayo, int id_inspector, string id_banco_errores)
        {
            using (var connection = GetConnection())
            {
                connection.Open();
                using (var command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "agregar_detalle_inspeccion_PEI";
                    command.Parameters.AddWithValue("@turno_inspeccion", turno_inspeccion);
                    command.Parameters.AddWithValue("@tipo_ensayo", tipo_ensayo);
                    command.Parameters.AddWithValue("@id_inspector", id_inspector);
                    command.Parameters.AddWithValue("@id_banco_errores", id_banco_errores);
                    command.CommandType = CommandType.StoredProcedure;
                    command.ExecuteNonQuery();
                    command.Parameters.Clear();

                }
            }
        }
    }
}
