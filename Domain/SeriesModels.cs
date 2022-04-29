using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess.SqlServer;
using System.Data;
using System.Data.SqlClient;

namespace Domain
{
    public class SeriesModels
    {
        Series series = new Series();

        public void SeriesItems(int nro_sol, string prefijo, int id_series)
        {
            series.AgregarSeries(nro_sol, prefijo, id_series);
        }

        public void AgregarSeriesPorRango(int nro_sol, string prefijoserie, int id_series, int seriefinal,
                                          string prefijoprecinto, int nro_precinto, int precinto_final)
        {
            series.AgregarSeriesPorRango(nro_sol, prefijoserie, id_series, seriefinal, 
                                         prefijoprecinto, nro_precinto, precinto_final);
        }

        public void ModificarSeries(string id_series, string anom_precinto, string anom_luneta, string anom_obstruccion,
                                    string anom_rosca_brida, string anom_filtro, string anom_carcaza, string anom_puntero,string conformidad_visual)
        {
            series.ModificarSeries(id_series, anom_precinto, anom_luneta, anom_obstruccion,
                                    anom_rosca_brida, anom_filtro, anom_carcaza, anom_puntero, conformidad_visual);
        }
    }
    //public DataTable ListarSeries(int ns)
    //{
    //    Series series = new Series();
    //    DataTable tabla = new DataTable();
    //    tabla = series.ListarSeries(ns);
    //    return tabla;
    //}

}
