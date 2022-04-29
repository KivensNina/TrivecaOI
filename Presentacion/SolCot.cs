using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Presentacion
{
    class SolCot
    {
        public SqlConnection cn = new SqlConnection();
        public SqlCommand cmd = new SqlCommand();
        public SqlDataReader dr;

        public SolCot()
            {
            if (cn.State == ConnectionState.Open)
            {
                cn.Close();
                cn.Dispose();
            }
            cn.ConnectionString = "server = DESKTOP-1N4BB84\\TRIVECA; database=oitriveca; uid=sa; pwd=trivecaweb2014$5";
            cn.Open();
            cmd.Connection = cn;
            }

        public void exe(string qry)
        {
            //Instacia de la clase SQLConection
            cn.Close();
            cn.Open();
            cmd.CommandText = qry;
            dr = cmd.ExecuteReader();

        }
    }
}
