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
    public class BancosModel
    {
        private BancosDAO objBancos = new BancosDAO();

        public DataTable ListarBancosPE()
        {
            DataTable tabla = new DataTable();
            tabla = objBancos.ListarBancosPE();
            return tabla;
        }
        public DataTable ListarBancosPEI()
        {
            DataTable tabla = new DataTable();
            tabla = objBancos.ListarBancosPEI();
            return tabla;
        }
        public void AgregarDetalleBancosPE(string turno_inspeccion, string tipo_ensayo, int id_inspector, string id_banco_estatica)
        {
            objBancos.AgregarDetalleBancosPE(turno_inspeccion, tipo_ensayo, id_inspector, id_banco_estatica);
        }
        public void AgregarDetalleBancosPEI(string turno_inspeccion, string tipo_ensayo, int id_inspector, string id_banco_errores)
        {
            objBancos.AgregarDetalleBancosPEI(turno_inspeccion, tipo_ensayo, id_inspector, id_banco_errores);
        }
    }
}
