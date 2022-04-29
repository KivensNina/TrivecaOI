using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Configuration;
using System.Runtime.InteropServices;
using Common.Cache;
using Domain;
using Presentacion;

namespace Presentacion
{
    public partial class GenerarOrdenTrabajo : Form
    {
        public GenerarOrdenTrabajo()
        {
            InitializeComponent();
        }

        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hwnd, int wmsg, int wparam, int lparam);

        private void GenerarOrdenTrabajo_Load(object sender, EventArgs e)
        {
            lblDni.Text = UserLoginCache.IdUser.ToString();
            lblResponsable.Text = UserLoginCache.nombre.ToString();
            lblCargo.Text = UserLoginCache.cargo.ToString();
            MostrarNroOrdenTrabajo();
            ListarInspectoresPE();
            ListarInspectoresPEI();
            ListarBancosPE();
            ListarBancosPEI();
            MostrarNroDPEI();
            MostrarNroDPE();
        }

        private void ListarInspectoresPE()
        {
            InspectorModel objInspec = new InspectorModel();
            cboInspectorPE.DataSource = objInspec.ListarInspector();
            cboInspectorPE.DisplayMember = "nombre";
            cboInspectorPE.ValueMember = "id_inspector";
        }

        private void ListarInspectoresPEI()
        {
            InspectorModel objInspec = new InspectorModel();
            cboInspectorPEI.DataSource = objInspec.ListarInspector();
            cboInspectorPEI.DisplayMember = "nombre";
            cboInspectorPEI.ValueMember = "id_inspector";
        }

        private void ListarBancosPE()
        {
            BancosModel objBancos = new BancosModel();
            cboNroBancoPE.DataSource = objBancos.ListarBancosPE();
            cboNroBancoPE.DisplayMember = "nro_banco";
            cboNroBancoPE.ValueMember = "id_banco_estatica";
        }
        private void ListarBancosPEI()
        {
            BancosModel objBancos = new BancosModel();
            cboNroBancoPEI.DataSource = objBancos.ListarBancosPEI();
            cboNroBancoPEI.DisplayMember = "nro_banco";
            cboNroBancoPEI.ValueMember = "id_banco_errores";
        }
        private void MostrarNroOrdenTrabajo()
        {
            SolCot obj = new SolCot();
            int a;
            obj.exe("select max(nro_orden_trabajo) from orden_trabajo");
            if (obj.dr.Read())
            {
                if (obj.dr[0] != System.DBNull.Value)
                {
                    a = Convert.ToInt32(obj.dr[0].ToString());
                    txtNroOrdenTrabajo.Text = (a + 1).ToString();
                    Convert.ToInt32(txtNroOrdenTrabajo.Text);
                }
                else
                {
                    txtNroOrdenTrabajo.Text = "1";
                }
            }
        }
        private void MostrarNroDPE()
        {
            SolCot obj = new SolCot();
            int a;
            obj.exe("select max(id_detalle_estatica) from detalle_inspeccion_estatica");
            if (obj.dr.Read())
            {
                if (obj.dr[0] != System.DBNull.Value)
                {
                    a = Convert.ToInt32(obj.dr[0].ToString());
                    lblNroDIEPE.Text = (a + 1).ToString();
                    Convert.ToInt32(lblNroDIEPE.Text);
                }
                else
                {
                    lblNroDIEPE.Text = "1";
                }
            }
        }
        private void MostrarNroDPEI()
        {
            SolCot obj = new SolCot();
            int a;
            obj.exe("select max(id_detalle_errores) from detalle_inspeccion_errores");
            if (obj.dr.Read())
            {
                if (obj.dr[0] != System.DBNull.Value)
                {
                    a = Convert.ToInt32(obj.dr[0].ToString());
                    lblNroDIEPEI.Text = (a + 1).ToString();
                    Convert.ToInt32(lblNroDIEPEI.Text);
                }
                else
                {
                    lblNroDIEPEI.Text = "1";
                }
            }
        }
        public void visualizar_sol_cot()
        {
            //Instacia de la clase SQLConection
            DataTable dt = new DataTable();
            String MostrarDatos;
            MostrarDatos = "visualizar_sol_cotizacion_x_NroInspeccion";
            SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["cs_trivecaoi"].ConnectionString);
            SqlDataAdapter da = new SqlDataAdapter(MostrarDatos, cn);

            if (cn.State == ConnectionState.Closed)
                cn.Open();
            da.SelectCommand.CommandType = CommandType.StoredProcedure;
            da.SelectCommand.Parameters.Add("@nro_sol_inspeccion", SqlDbType.VarChar).Value = txtNroSolInspec.Text;
            da.Fill(dt);
            //SqlDataReader registro = comando.ExecuteReader();

            if (dt.Rows.Count > 0)
            {
                txtCodSap.Text = dt.Rows[0]["id_item"].ToString();
                txtFechaEmision.Text = dt.Rows[0]["fecha_emision"].ToString();
                txtFechaEntrega.Text = dt.Rows[0]["fecha_entrega"].ToString();
                txtProcInspec.Text = dt.Rows[0]["procedimiento"].ToString();
            }
            else
            {
                MessageBox.Show("Solicitud no Existe");
                txtCodSap.Clear();
                txtFechaEmision.Clear();
                txtFechaEntrega.Clear();
                txtProcInspec.Clear();
            }
            visualizar_item();
            Listar_series_nroInspec();
            Mostrar_Cantidad();
        }

        public void visualizar_item()
        {
            //Instacia de la clase SQLConection
            DataTable dt = new DataTable();
            String MostrarDatos;
            MostrarDatos = "mostrar_item_x_codigosap";
            SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["cs_trivecaoi"].ConnectionString);
            SqlDataAdapter da = new SqlDataAdapter(MostrarDatos, cn);

            da.SelectCommand.CommandType = CommandType.StoredProcedure;
            da.SelectCommand.Parameters.Add("@codigosap", SqlDbType.VarChar).Value = txtCodSap.Text;
            da.Fill(dt);
            //SqlDataReader registro = comando.ExecuteReader();

            if (dt.Rows.Count > 0)
            {
                txtMarca.Text = dt.Rows[0]["marca"].ToString();
                txtTipo.Text = dt.Rows[0]["tipo"].ToString();
                txtModelo.Text = dt.Rows[0]["modelo"].ToString();
                txtLongitud.Text = dt.Rows[0]["longitud"].ToString();
                txtDn.Text = dt.Rows[0]["dn"].ToString();
                txtQ3.Text = dt.Rows[0]["q3"].ToString();
                txtQ3Q1.Text = dt.Rows[0]["r"].ToString();
                txtPma.Text = dt.Rows[0]["pma"].ToString();
                txtTma.Text = dt.Rows[0]["tma"].ToString();
                txtFabricante.Text = dt.Rows[0]["fabricante"].ToString();
                txtPais.Text = dt.Rows[0]["pais_procedencia"].ToString();
                txtAnio.Text = dt.Rows[0]["anio_fabricacion"].ToString();
                txtMetrologica.Text = dt.Rows[0]["clase_metrologica"].ToString();
                txtHomologacion.Text = dt.Rows[0]["certificado_homologacion"].ToString();
                txtAprobModelo.Text = dt.Rows[0]["certificado_apro_modelo"].ToString();
            }
            else
            {
                MessageBox.Show("Item No se encuentra en la lista");
                txtMarca.Clear();
                txtTipo.Clear();
                txtModelo.Clear();
                txtLongitud.Clear();
                txtDn.Clear();
                txtQ3.Clear();
                txtQ3Q1.Clear();
                txtPma.Clear();
                txtFabricante.Clear();
                txtPais.Clear();
                txtAnio.Clear();
                txtMetrologica.Clear();
                txtHomologacion.Clear();
                txtAprobModelo.Clear();

            }

            cn.Close();
        }

        private void Mostrar_Cantidad()
        {
            SolCot obj = new SolCot();
            int a;
            obj.exe("select count(series.id_series) as series from sol_cotizacion_inspec_med " +
                    "inner join sol_inspeccion_medidores on sol_cotizacion_inspec_med.nro_solicitud = sol_inspeccion_medidores.nro_solicitud " +
                    "inner join series on sol_cotizacion_inspec_med.nro_solicitud = series.nro_solicitud " +
                    "where nro_sol_inspeccion = '" + txtNroSolInspec.Text + "' ");
            if (obj.dr.Read())
            {
                if (obj.dr[0] != System.DBNull.Value)
                {
                    a = Convert.ToInt32(obj.dr[0].ToString());
                    txtCantidad.Text = a.ToString();
                    Convert.ToInt32(txtNroSolInspec.Text);
                    Convert.ToInt32(txtCantidad.Text);
                }
                else
                {
                    MessageBox.Show("Solicitud de cotización no existe");
                }
            }
        }

        private void Listar_series_nroInspec()
        {
            //Instacia de la clase SQLConection
            DataTable dt = new DataTable();
            String MostrarDatos;
            MostrarDatos = "select series.id_series as Serie, series.nro_precinto as Precinto from sol_cotizacion_inspec_med " +
                           "inner join sol_inspeccion_medidores on sol_cotizacion_inspec_med.nro_solicitud = sol_inspeccion_medidores.nro_solicitud " +
                           "inner join series on sol_cotizacion_inspec_med.nro_solicitud = series.nro_solicitud " +
                           "where nro_sol_inspeccion = '" + txtNroSolInspec.Text + "' ";
            SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["cs_trivecaoi"].ConnectionString);
            if (cn.State == ConnectionState.Closed)
                cn.Open();
            SqlDataAdapter da = new SqlDataAdapter(MostrarDatos, cn);
            da.Fill(dt);
            dgvListarSeries.DataSource = dt;
            SqlCommand comando = new SqlCommand(MostrarDatos, cn);
            SqlDataReader leer;
            leer = comando.ExecuteReader();
        }

        private void cboNroBancoPE_SelectedIndexChanged(object sender, EventArgs e)
        {
            //Instacia de la clase SQLConection
            DataTable dt = new DataTable();
            String MostrarDatos;
            MostrarDatos = "mostrar_detallebanco_x_nrobancoPE";
            SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["cs_trivecaoi"].ConnectionString);
            SqlDataAdapter da = new SqlDataAdapter(MostrarDatos, cn);

            da.SelectCommand.CommandType = CommandType.StoredProcedure;
            da.SelectCommand.Parameters.Add("@nro_banco", SqlDbType.Int).Value = Convert.ToInt32(cboNroBancoPE.Text);
            da.Fill(dt);
            //SqlDataReader registro = comando.ExecuteReader();

            if (dt.Rows.Count > 0)
            {
                lblIdBancoPE.Text = dt.Rows[0]["id_banco_estatica"].ToString();
                txtBancoPE.Text = dt.Rows[0]["banco"].ToString();
                txtDocCalibPE.Text = dt.Rows[0]["doc_calibracion"].ToString();
                txtFechaCalibPE.Text = dt.Rows[0]["fecha_calibracion"].ToString();
            }
            else
            {
                MessageBox.Show("Banco PEI, No se encuentra en la lista");
                txtBancoPE.Clear();
                txtDocCalibPE.Clear();
                txtFechaCalibPE.Clear();
            }

            cn.Close();
        }

        private void cboNroBancoPEI_SelectedIndexChanged(object sender, EventArgs e)
        {
            //Instacia de la clase SQLConection
            DataTable dt = new DataTable();
            String MostrarDatos;
            MostrarDatos = "mostrar_detallebanco_x_nrobancoPEI";
            SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["cs_trivecaoi"].ConnectionString);
            SqlDataAdapter da = new SqlDataAdapter(MostrarDatos, cn);
            
            da.SelectCommand.CommandType = CommandType.StoredProcedure;
            da.SelectCommand.Parameters.Add("@nro_banco", SqlDbType.Int).Value = Convert.ToInt32(cboNroBancoPEI.Text);
            da.Fill(dt);
            //SqlDataReader registro = comando.ExecuteReader();

            if (dt.Rows.Count > 0)
            {
                lblIdBancoPEI.Text = dt.Rows[0]["id_banco_errores"].ToString();
                txtBancoPEI.Text = dt.Rows[0]["banco"].ToString();
                txtDocCalibPEI.Text = dt.Rows[0]["doc_calibracion"].ToString();
                txtFechaCalibPEI.Text = dt.Rows[0]["fecha_calibracion"].ToString();
            }
            else
            {
                MessageBox.Show("Banco PEI, No se encuentra en la lista");
                txtBancoPEI.Clear();
                txtDocCalibPEI.Clear();
                txtFechaCalibPEI.Clear();
            }

            cn.Close();
        }

        private void Agregar_Detalle_Estatica()
        {
            BancosModel objBanco = new BancosModel();
            objBanco.AgregarDetalleBancosPE(cboTurnoPE.Text, lblTipoEnsayoPE.Text, Convert.ToInt32(cboInspectorPE.SelectedValue), lblIdBancoPE.Text);
            //MessageBox.Show("Solicitud de Inspección nro. " + lblIdBancoPE.Text + " guardada correctamente");
        }
        private void Agregar_Detalle_Errores()
        {
            BancosModel objBanco = new BancosModel();
            objBanco.AgregarDetalleBancosPEI(cboTurnoPEI.Text, lblTipoEnsayoPEI.Text, Convert.ToInt32(cboInspectorPEI.SelectedValue), lblIdBancoPEI.Text);
        }

        private void Agregar_Guardar_OT()
        {
            OrdenTrabajoModel objOT = new OrdenTrabajoModel();
            objOT.AgregarActualizarOTs(Convert.ToInt32(txtNroOrdenTrabajo.Text), lblVersion.Text, lblCodVersion.Text, lblFechaVersion.Text, dtpFechaEmisionOT.Value, txtObservaciones.Text,
                                       "Guargado", Convert.ToInt32(lblDni.Text), Convert.ToInt32(txtNroSolInspec.Text), Convert.ToInt32(lblNroDIEPE.Text), Convert.ToInt32(lblNroDIEPEI.Text));
            MessageBox.Show("Orden de Trabajo nro. " + txtNroOrdenTrabajo.Text + " guardada correctamente");
        }

        private void Agregar_Enviar_OT()
        {
            OrdenTrabajoModel objOT = new OrdenTrabajoModel();
            objOT.AgregarActualizarOTs(Convert.ToInt32(txtNroOrdenTrabajo.Text), lblVersion.Text, lblCodVersion.Text, lblFechaVersion.Text, dtpFechaEmisionOT.Value, txtObservaciones.Text,
                                       "Enviar", Convert.ToInt32(lblDni.Text), Convert.ToInt32(txtNroSolInspec.Text), Convert.ToInt32(lblNroDIEPE.Text), Convert.ToInt32(lblNroDIEPEI.Text));
            MessageBox.Show("Orden de Trabajo nro. " + txtNroOrdenTrabajo.Text + " enviada correctamente");
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            Agregar_Detalle_Estatica();
            Agregar_Detalle_Errores();
            timer1.Start();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            Agregar_Guardar_OT();
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            Agregar_Enviar_OT();
        }

        private void btnEnviar_Click(object sender, EventArgs e)
        {
            Agregar_Detalle_Estatica();
            Agregar_Detalle_Errores();
            timer2.Start();
        }

        private void btnDevolver_Click(object sender, EventArgs e)
        {
            //SolInspecModel objSI = new SolInspecModel();

        }
    }
}
