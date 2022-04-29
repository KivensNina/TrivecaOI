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
    public partial class FormGenerarSolicitudCotizacionAdmOI : Form
    {
        public FormGenerarSolicitudCotizacionAdmOI()
        {
            InitializeComponent();
        }

        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hwnd, int wmsg, int wparam, int lparam);

        //agregar_solicitudES_cotizacion


        private void FormGenerarSolicitudCotizacionAdmOI_Load(object sender, EventArgs e)
        {
            MostrarNroSolCot();
            lblIdUsuario.Text = UserLoginCache.IdUser.ToString();
            ListarNormas();
        }

        private void ListarNormas()
        {
            NormasModel NormasModel = new NormasModel();
            cboNormas.DataSource = NormasModel.ListarInspector();
            cboNormas.DisplayMember = "descripcion";
            cboNormas.ValueMember = "id_norma";
        }

        private void Solcargada()
        {
            SolCotModel objsolcot = new SolCotModel();

            objsolcot.AgregarSolCot(lblFechaVersion.Text, lblVersion.Text, lblCodVersion.Text);

        }

        private void MostrarNroSolCot()
        {
            SolCot obj = new SolCot();
            int a;
            obj.exe("select max(nro_solicitud) from sol_cotizacion_inspec_med");
            if (obj.dr.Read())
            {
                if (obj.dr[0] != System.DBNull.Value)
                {
                    a = Convert.ToInt32(obj.dr[0].ToString());
                    txtNroSol.Text = (a + 1).ToString();
                    Convert.ToInt32(txtNroSol.Text);
                }
                else
                {
                    txtNroSol.Text = "1";
                }
            }
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
                    txtNroSol.Text = "1";
                }
            }
        }

        private void Listar_series_nroSol()
        {
            //Instacia de la clase SQLConection
            DataTable dt = new DataTable();
            String MostrarDatos;
            MostrarDatos = "select id_series, nro_precinto from series where nro_solicitud = '" + txtNroSol.Text + "' ";
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

        private void btnCargarCliente_Click(object sender, EventArgs e)
        {
            //Instacia de la clase SQLConection
            DataTable dt = new DataTable();
            String MostrarDatos;
            MostrarDatos = "mostrar_clientes_x_ruc";
            SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["cs_trivecaoi"].ConnectionString);
            SqlDataAdapter da = new SqlDataAdapter(MostrarDatos, cn);

            //SqlCommand comando = new SqlCommand("mostrar_clientes_x_ruc", cn);
            //comando.Parameters.AddWithValue("@ruc", txtRuc.Text);
            if (cn.State == ConnectionState.Closed)
                cn.Open();
            da.SelectCommand.CommandType = CommandType.StoredProcedure;
            da.SelectCommand.Parameters.Add("@ruc", SqlDbType.VarChar).Value = txtRuc.Text;
            da.Fill(dt);
            //SqlDataReader registro = comando.ExecuteReader();

            if (dt.Rows.Count > 0)
            {
                lblCodSapCliente.Text = dt.Rows[0]["id_cliente"].ToString();
                txtOrganizacion.Text = dt.Rows[0]["organizacion"].ToString();
                txtDireccion.Text = dt.Rows[0]["direccion"].ToString();
                txtContacto.Text = dt.Rows[0]["contacto"].ToString();
                txtCargo.Text = dt.Rows[0]["cargo_contacto"].ToString();
                txtTelefono.Text = dt.Rows[0]["telefono"].ToString();
                txtMail.Text = dt.Rows[0]["mail"].ToString();
            }
            else
            {
                MessageBox.Show("Cliente no Existe");
                txtOrganizacion.Clear();
                txtDireccion.Clear();
                txtContacto.Clear();
                txtCargo.Clear();
                txtMail.Clear();
                txtTelefono.Clear();
            }

        }

        private void btnCargarItem_Click(object sender, EventArgs e)
        {
            Solcargada();
            //Instacia de la clase SQLConection
            DataTable dt = new DataTable();
            String MostrarDatos;
            MostrarDatos = "mostrar_item_x_codigosap";
            SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["cs_trivecaoi"].ConnectionString);
            SqlDataAdapter da = new SqlDataAdapter(MostrarDatos, cn);

            //SqlCommand comando = new SqlCommand("mostrar_clientes_x_ruc", cn);
            //comando.Parameters.AddWithValue("@ruc", txtRuc.Text);

            da.SelectCommand.CommandType = CommandType.StoredProcedure;
            da.SelectCommand.Parameters.Add("@codigosap", SqlDbType.VarChar).Value = txtCodsap.Text;
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
        SeriesModels objseries = new SeriesModels();
        private void btnAgregar_Click(object sender, EventArgs e)
        {
            if (txtPrefUnit.Text != "")
            {
                if (Convert.ToInt32(txtUnidad.Text) != 0)
                {
                    objseries.SeriesItems(Convert.ToInt32(txtNroSol.Text), txtPrefUnit.Text, Convert.ToInt32(txtUnidad.Text));
                    MessageBox.Show("insertado");
                    Mostrar_Cantidad();
                    Listar_series_nroSol();
                }
                else
                {
                    MessageBox.Show("Ingresar serie en unidad");
                }
            }
            else
            {
                MessageBox.Show("Ingresar prefijo de unidad");
            }
        }

        private void btnInsertarSeries_Click(object sender, EventArgs e)
        {
            if (txtPrefRango.Text != "")
            {
                if (Convert.ToInt32(txtDesde.Text) != 0 && Convert.ToInt32(txtDesde.Text) != 0)
                {
                    objseries.AgregarSeriesPorRango(Convert.ToInt32(txtNroSol.Text), txtPrefRango.Text, Convert.ToInt32(txtDesde.Text), Convert.ToInt32(txtHasta.Text), txtPrefPrcnto.Text, Convert.ToInt32(txtPrcntoIni.Text), Convert.ToInt32(txtPrcntoFin.Text));
                    MessageBox.Show("datos insertados correctamente");
                    Mostrar_Cantidad();
                    Listar_series_nroSol();
                }
                else
                {
                    MessageBox.Show("Ingresar rango de las series");
                }
                
            }
            else
            {
                MessageBox.Show("Ingresar prefijo de series");
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            SolCotModel objsolcot = new SolCotModel();
            objsolcot.ActualizarSolCotMedList2(Convert.ToInt32(txtNroSol.Text), dtpFecha.Value, cboVerificacion.Text, Convert.ToInt32(txtCantidad.Text), cboImpCertificado.Text, richtxtObservaciones.Text,"Guardado", Convert.ToInt32(lblCodSapCliente.Text), Convert.ToInt32(lblIdUsuario.Text), txtCodsap.Text, Convert.ToInt32(cboNormas.SelectedValue));
            MessageBox.Show("Solicitud de cotización nro. " +txtNroSol.Text+ " guardada correctamente");
        }

        private void btnEnviar_Click(object sender, EventArgs e)
        {
            FormPrincipal test = new FormPrincipal();
            SolCotModel objsolcot = new SolCotModel();
            objsolcot.ActualizarSolCotMedList2(Convert.ToInt32(txtNroSol.Text), dtpFecha.Value, cboVerificacion.Text, Convert.ToInt32(txtCantidad.Text), cboImpCertificado.Text, richtxtObservaciones.Text, "Enviado", Convert.ToInt32(lblCodSapCliente.Text), Convert.ToInt32(lblIdUsuario.Text), txtCodsap.Text, Convert.ToInt32(cboNormas.SelectedValue));
            MessageBox.Show("Solicitud de cotización nro. " + txtNroSol.Text + " enviada correctamente");
        }

        private void txtDesde_Click(object sender, EventArgs e)
        {
            if (txtDesde.Text == "Desde")
            {
                txtDesde.Clear();
                txtDesde.ForeColor = Color.Black;
            } else if (txtDesde.Text == "")
            {
                txtDesde.ForeColor = Color.Black;
            }
            else
            {
                txtDesde.ForeColor = Color.Black;
            }
        }

        private void txtHasta_Click(object sender, EventArgs e)
        {
            if (txtHasta.Text == "Hasta")
            {
                txtHasta.Clear();
                txtHasta.ForeColor = Color.Black;
            }
            else if (txtHasta.Text == "")
            {
                txtHasta.ForeColor = Color.Black;
            }
            else
            {
                txtHasta.ForeColor = Color.Black;
            }
        }

        private void txtPrcntoIni_Click(object sender, EventArgs e)
        {
            if (txtPrcntoIni.Text == "Desde")
            {
                txtPrcntoIni.Clear();
                txtPrcntoIni.ForeColor = Color.Black;
            }
            else if (txtPrcntoIni.Text == "")
            {
                txtPrcntoIni.ForeColor = Color.Black;
            }
            else
            {
                txtPrcntoIni.ForeColor = Color.Black;
            }
        }

        private void txtPrcntoFin_Click(object sender, EventArgs e)
        {
            if (txtPrcntoFin.Text == "Hasta")
            {
                txtPrcntoFin.Clear();
                txtPrcntoFin.ForeColor = Color.Black;
            }
            else if (txtPrcntoFin.Text == "")
            {
                txtPrcntoFin.ForeColor = Color.Black;
            }
            else
            {
                txtPrcntoFin.ForeColor = Color.Black;
            }
        }

        private void richtxtObservaciones_Click(object sender, EventArgs e)
        {
            if (richtxtObservaciones.Text == "Observaciones")
            {
                richtxtObservaciones.Clear();
                richtxtObservaciones.ForeColor = Color.Black;
            }
            else if (richtxtObservaciones.Text == "")
            {
                richtxtObservaciones.ForeColor = Color.Black;
            }
            else
            {
                richtxtObservaciones.ForeColor = Color.Black;
            }
        }
    }
}
