using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace DataAccess.SqlServer
{
    public class ClientDao : coneccionSQL
    {
        private coneccionSQL conexion = new coneccionSQL();
        SqlDataReader leer;
        DataTable tabla = new DataTable();
        //SqlCommand comando = new SqlCommand();
        
        public DataTable MostrarClientes()
        {
            using (var connection = GetConnection())
            {
                connection.Open();
                using (var command= new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "Select * from cliente";
                    leer = command.ExecuteReader();
                    tabla.Load(leer);
                    connection.Close();
                    return tabla;

                    
                    //command.Connection = connection;
                    //String MostrarDatos;
                    //MostrarDatos = "mostrar_clientes_x_ruc";
                    //SqlDataAdapter da = new SqlDataAdapter(MostrarDatos, connection);
                    //da.SelectCommand.CommandType = CommandType.StoredProcedure;
                    //da.SelectCommand.Parameters.Add("@ruc", SqlDbType.VarChar).Value = ruc;
                    //da.Fill(tabla);

                }
            }
        }

    }
}
