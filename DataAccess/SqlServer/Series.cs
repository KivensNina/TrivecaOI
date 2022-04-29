using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace DataAccess.SqlServer
{
    public class Series:coneccionSQL
    {
        public void AgregarSeries(int nro_sol, string prefijo, int id_series)
        {
            using (var connection = GetConnection())
            {
                connection.Open();
                using (var command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "insertar_series_unidad_prefijo";
                    command.Parameters.AddWithValue("@nro_solicitud", nro_sol);
                    command.Parameters.AddWithValue("@prefijo", prefijo);
                    command.Parameters.AddWithValue("@id_series", id_series);
                    command.CommandType = CommandType.StoredProcedure;
                    command.ExecuteNonQuery();
                    command.Parameters.Clear();

                }
            }
        }
        public void AgregarSeriesPorRango(int nro_sol, string prefijoserie, int id_series, int seriefinal,
                                          string prefijoprecinto, int nro_precinto, int precinto_final)
        {
            using (var connection = GetConnection())
            {
                connection.Open();
                using (var command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "insertar_series_precintos_rangos_prefijo";
                    command.Parameters.AddWithValue("@nro_solicitud", nro_sol);
                    command.Parameters.AddWithValue("@prefijoserie", prefijoserie);
                    command.Parameters.AddWithValue("@id_series", id_series);
                    command.Parameters.AddWithValue("@seriefinal", seriefinal);
                    command.Parameters.AddWithValue("@prefijoprecinto", prefijoprecinto);
                    command.Parameters.AddWithValue("@nro_precinto", nro_precinto);
                    command.Parameters.AddWithValue("@precinto_final", precinto_final);
                    command.CommandType = CommandType.StoredProcedure;
                    command.ExecuteNonQuery();
                    command.Parameters.Clear();

                }
            }
        }

        public void ModificarSeries(string id_series, string anom_precinto, string anom_luneta, string anom_obstruccion,
                                    string anom_rosca_brida, string anom_filtro, string anom_carcaza, string anom_puntero, string conformidad_visual)
        {
            using (var connection = GetConnection())
            {
                connection.Open();
                using (var command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "ActualizarAnomalias_x_Series";
                    command.Parameters.AddWithValue("@id_series", id_series);
                    command.Parameters.AddWithValue("@anom_luneta", anom_luneta);
                    command.Parameters.AddWithValue("@anom_filtro", anom_filtro);
                    command.Parameters.AddWithValue("@anom_obstruccion", anom_obstruccion);
                    command.Parameters.AddWithValue("@anom_rosca_brida", anom_rosca_brida);
                    command.Parameters.AddWithValue("@anom_carcaza", anom_carcaza);
                    command.Parameters.AddWithValue("@anom_puntero", anom_puntero);
                    command.Parameters.AddWithValue("@anom_precinto", anom_precinto);
                    command.Parameters.AddWithValue("@conformidad_visual", conformidad_visual);
                    command.CommandType = CommandType.StoredProcedure;
                    command.ExecuteNonQuery();
                    command.Parameters.Clear();

                }
            }
        }

    }
}
