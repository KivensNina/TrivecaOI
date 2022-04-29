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
    public partial class FormGenerarSolicitudInspeccion : Form
    {
        public FormGenerarSolicitudInspeccion()
        {
            InitializeComponent();
        }

        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hwnd, int wmsg, int wparam, int lparam);

        //agregar_solicitudES_Inspección


        private void FormGenerarSolicitudInspeccion_Load(object sender, EventArgs e)
        {
            lblIdUser.Text = UserLoginCache.IdUser.ToString();
            txtUsuario.Text = UserLoginCache.nombre.ToString();
            MostrarNroSolInspec();
            ListarProcInpeccion();
            ListarInspectores();
        }

        private void ListarProcInpeccion()
        {
            ProcInspecModel objPI = new ProcInspecModel();
            cboProcedimiento.DataSource = objPI.ListarProcInspeccion();
            cboProcedimiento.DisplayMember = "procedimiento";
            cboProcedimiento.ValueMember = "id_proc_inspeccion";
        }

        private void ListarInspectores()
        {
            InspectorModel objInspec = new InspectorModel();
            cboInspector.DataSource = objInspec.ListarInspector();
            cboInspector.DisplayMember = "nombre";
            cboInspector.ValueMember = "id_inspector";
        }

        private void MostrarNroSolInspec()
        {
            SolCot obj = new SolCot();
            int a;
            obj.exe("select max(nro_sol_inspeccion) from sol_inspeccion_medidores");
            if (obj.dr.Read())
            {
                if (obj.dr[0] != System.DBNull.Value)
                {
                    a = Convert.ToInt32(obj.dr[0].ToString());
                    txtNroSolInspec.Text = (a + 1).ToString();
                    Convert.ToInt32(txtNroSolInspec.Text);
                }
                else
                {
                    txtNroSolInspec.Text = "1";
                }
            }
        }

        public void visualizar_sol_cot()
        {
            //Instacia de la clase SQLConection
            DataTable dt = new DataTable();
            String MostrarDatos;
            MostrarDatos = "visualizar_sol_cotizacion_OI";
            SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["cs_trivecaoi"].ConnectionString);
            SqlDataAdapter da = new SqlDataAdapter(MostrarDatos, cn);
         
            if (cn.State == ConnectionState.Closed)
                cn.Open();
            da.SelectCommand.CommandType = CommandType.StoredProcedure;
            da.SelectCommand.Parameters.Add("@nro_solicitud", SqlDbType.VarChar).Value = txtNroSol.Text;
            da.Fill(dt);
            //SqlDataReader registro = comando.ExecuteReader();
         
            if (dt.Rows.Count > 0)
            {
                lblCodSap.Text = dt.Rows[0]["id_item"].ToString();
                txtVerificacion.Text = dt.Rows[0]["Verificacion"].ToString();
                richtxtObservaciones.Text = dt.Rows[0]["observaciones"].ToString();
            }
            else
            {
                MessageBox.Show("Solicitud no Existe");
                txtVerificacion.Clear();
                txtNroSol.Clear();
                richtxtObservaciones.Clear();
            }
            visualizar_item();
            Listar_series_nroSol();
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
            da.SelectCommand.Parameters.Add("@codigosap", SqlDbType.VarChar).Value = lblCodSap.Text;
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
            obj.exe("select count(id_series) from series where nro_solicitud = '" +txtNroSol.Text+"' ");
            if (obj.dr.Read())
            {
                if (obj.dr[0] != System.DBNull.Value)
                {
                    a = Convert.ToInt32(obj.dr[0].ToString());
                    txtCantidad.Text = a.ToString();
                    Convert.ToInt32(txtNroSol.Text);
                    Convert.ToInt32(txtCantidad.Text);
                }
                else
                {
                    MessageBox.Show("Solicitud de cotización no existe");
                }
            }
        }

        private void Listar_series_nroSol()
        {
            //Instacia de la clase SQLConection
            DataTable dt = new DataTable();
            String MostrarDatos;
            MostrarDatos = "select id_series from series where nro_solicitud = '" + txtNroSol.Text + "' ";
            SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["cs_trivecaoi"].ConnectionString);
            if (cn.State == ConnectionState.Closed)
                cn.Open();
            SqlDataAdapter da = new SqlDataAdapter(MostrarDatos, cn);
            da.Fill(dt);
            dgvSeries.DataSource = dt;
            SqlCommand comando = new SqlCommand(MostrarDatos, cn);
            SqlDataReader leer;
            leer = comando.ExecuteReader();
        }

        private void panel4_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Se descartara la Solicitud, ¿Esta Seguro de salir?",
               "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                this.Close();
        }
        
        private void Agregar_Guardar_SolInspec()
        {
            SolInspecModel objSI = new SolInspecModel();
            objSI.AgregarActualizarSolInspec(Convert.ToInt32(txtNroSolInspec.Text), lblFechaVersion.Text, lblVersion.Text, lblCodVersion.Text,
               dtpFechaEmi.Value, dtpFechaEntrega.Value, dtpFechaRecepcion.Value, richtxtObservaciones.Text, "Guargado",
               Convert.ToInt32(txtNroSol.Text), Convert.ToInt32(cboProcedimiento.SelectedValue), Convert.ToInt32(cboInspector.SelectedValue), Convert.ToInt32(lblIdUser.Text));
            MessageBox.Show("Solicitud de Inspección nro. " + txtNroSolInspec.Text + " guardada correctamente");
        }

        private void Agregar_Enviar_SolInpec()
        {
            SolInspecModel objSI = new SolInspecModel();
            objSI.AgregarActualizarSolInspec(Convert.ToInt32(txtNroSolInspec.Text), lblFechaVersion.Text, lblVersion.Text, lblCodVersion.Text,
               dtpFechaEmi.Value, dtpFechaEntrega.Value, dtpFechaRecepcion.Value, richtxtObservaciones.Text, "Enviado",
               Convert.ToInt32(txtNroSol.Text), Convert.ToInt32(cboProcedimiento.SelectedValue), Convert.ToInt32(cboInspector.SelectedValue), Convert.ToInt32(lblIdUser.Text));
            MessageBox.Show("Solicitud de Inspección nro. " + txtNroSolInspec.Text + " enviada correctamente");
        }
        
        private void btnGuardar_Click(object sender, EventArgs e)
        {

            Agregar_Guardar_SolInspec();
        }

        private void btnEnviar_Click(object sender, EventArgs e)
        {
            Agregar_Enviar_SolInpec();
        }
    }
}
