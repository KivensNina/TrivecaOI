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
    public partial class FormVisualizarSolicitudCotizacion : Form
    {
        public FormVisualizarSolicitudCotizacion()
        {
            InitializeComponent();
        }

        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hwnd, int wmsg, int wparam, int lparam);

        //agregar_solicitudES_cotizacion

       
        public void visualizar_sol_cot()
        {
            //Instacia de la clase SQLConection
            DataTable dt = new DataTable();
            String MostrarDatos;
            MostrarDatos = "visualizar_sol_cotizacion";
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
                lblCodSapCliente.Text = dt.Rows[0]["id_cliente"].ToString();
                txtCodsap.Text = dt.Rows[0]["id_item"].ToString();
                txtVerificacion.Text = dt.Rows[0]["Verificacion"].ToString();
                txtCertificado.Text = dt.Rows[0]["formato"].ToString();
                richtxtObservaciones.Text = dt.Rows[0]["observaciones"].ToString();
                dtpFecha.Text= dt.Rows[0]["fecha_emision"].ToString();
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
            visualizar_cliente();
            visualizar_item();
            Listar_series_nroSol();
            Mostrar_Cantidad();
        }

        public void Listar_series_nroSol()
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

        private void ListarNormas()
        {
            NormasModel NormasModel = new NormasModel();
            cboNormas.DataSource = NormasModel.ListarInspector();
            cboNormas.DisplayMember = "descripcion";
            cboNormas.ValueMember = "id_norma";
        }

        public void Mostrar_Cantidad()
        {
            SolCot obj = new SolCot();
            int a;
            obj.exe("select count(id_series) from series where nro_solicitud = '" + txtNroSol.Text + "' ");
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

        public void visualizar_cliente()
        {
            //Instacia de la clase SQLConection
            DataTable dt = new DataTable();
            String MostrarDatos;
            MostrarDatos = "mostrar_clientes_x_id_cliente";
            SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["cs_trivecaoi"].ConnectionString);
            SqlDataAdapter da = new SqlDataAdapter(MostrarDatos, cn);

            //SqlCommand comando = new SqlCommand("mostrar_clientes_x_ruc", cn);
            //comando.Parameters.AddWithValue("@ruc", txtRuc.Text);
            if (cn.State == ConnectionState.Closed)
                cn.Open();
            da.SelectCommand.CommandType = CommandType.StoredProcedure;
            da.SelectCommand.Parameters.Add("@id_cliente", SqlDbType.VarChar).Value = lblCodSapCliente.Text;
            da.Fill(dt);
            //SqlDataReader registro = comando.ExecuteReader();

            if (dt.Rows.Count > 0)
            {
                txtRuc.Text = dt.Rows[0]["ruc"].ToString();
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
                txtRuc.Clear();
                txtOrganizacion.Clear();
                txtDireccion.Clear();
                txtContacto.Clear();
                txtCargo.Clear();
                txtMail.Clear();
                txtTelefono.Clear();
            }

        }

        public void visualizar_item()
        {
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

        SeriesModels objseries = new SeriesModels();
        
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
        
        private void btnGuardar_Click(object sender, EventArgs e)
        {
            SolCotModel objsolcot = new SolCotModel();
            objsolcot.ActualizarSolCotMedList2(Convert.ToInt32(txtNroSol.Text), dtpFecha.Value, txtVerificacion.Text,
                        Convert.ToInt32(txtCantidad.Text), txtCertificado.Text, richtxtObservaciones.Text,"Guargado",
                        Convert.ToInt32(lblCodSapCliente.Text), Convert.ToInt32(lblIdUsuario.Text), txtCodsap.Text, Convert.ToInt32(cboNormas.SelectedValue));
            MessageBox.Show("Solicitud de cotización nro. " +txtNroSol.Text+ " guardada correctamente");
            Lista.MostrarSolCot();
        }
        ListarSolicitudesCotizacion Lista = new ListarSolicitudesCotizacion();
        private void btnEnviar_Click(object sender, EventArgs e)
        {
            FormPrincipal test = new FormPrincipal();
            SolCotModel objsolcot = new SolCotModel();
            objsolcot.ActualizarSolCotMedList2(Convert.ToInt32(txtNroSol.Text), dtpFecha.Value, txtVerificacion.Text,
                        Convert.ToInt32(txtCantidad.Text), txtCertificado.Text, richtxtObservaciones.Text, "Enviado", 
                         Convert.ToInt32(lblCodSapCliente.Text), Convert.ToInt32(lblIdUsuario.Text), txtCodsap.Text, Convert.ToInt32(cboNormas.SelectedValue));
            MessageBox.Show("Solicitud de cotización nro. " + txtNroSol.Text + " enviada correctamente");
            Lista.MostrarSolCot();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
                if (txtPrefUnit.Text != "")
                {
                    if (Convert.ToInt32(txtUnidad.Text) != 0)
                    {
                        objseries.SeriesItems(Convert.ToInt32(txtNroSol.Text), txtPrefUnit.Text,
                                              Convert.ToInt32(txtUnidad.Text));
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

        private void InsertarSeriesPrecintos()
        {
            if (txtPrefRango.Text != "" && txtPrefPrcnto.Text != "")
            {
                if (Convert.ToInt32(txtPrcntoIni.Text) != 0 && Convert.ToInt32(txtPrcntoFin.Text) != 0)
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
                    MessageBox.Show("Ingresar rango de los precintos");
                }
            }
            else
            {
                MessageBox.Show("Ingresar prefijo de series y precintos");
            }
        }

        private void FormVisualizarSolicitudCotizacion_Load(object sender, EventArgs e)
        {
            lblIdUsuario.Text = UserLoginCache.IdUser.ToString();
            ListarNormas();
        }

        private void txtDesde_Click(object sender, EventArgs e)
        {
            if (txtDesde.Text == "Desde")
            {
                txtDesde.Clear();
                txtDesde.ForeColor = Color.Black;
            }
            else if (txtDesde.Text == "")
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

        private void btnInsertarSeries_Click_1(object sender, EventArgs e)
        {
            InsertarSeriesPrecintos();
        }
    }
}
