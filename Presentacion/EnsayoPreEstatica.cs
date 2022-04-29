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
    public partial class EnsayoPreEstatica : Form
    {
        public EnsayoPreEstatica()
        {
            InitializeComponent();
        }

        private void EnsayoPreEstatica_Load(object sender, EventArgs e)
        {

        }

        private void Listar_series_nroSol()
        {
            ////Instacia de la clase SQLConection
            //DataTable dt = new DataTable();
            //String MostrarDatos;
            //MostrarDatos = "select id_series, nro_precinto from series where nro_solicitud = '" + txtNroSol.Text + "' ";
            //SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["cs_trivecaoi"].ConnectionString);
            //if (cn.State == ConnectionState.Closed)
            //    cn.Open();
            //SqlDataAdapter da = new SqlDataAdapter(MostrarDatos, cn);
            //da.Fill(dt);
            //dgvSeries.DataSource = dt;
            //SqlCommand comando = new SqlCommand(MostrarDatos, cn);
            //SqlDataReader leer;
            //leer = comando.ExecuteReader();
        }
        SeriesModels objSeries = new SeriesModels();
        string operacion = "Insertar";
        private void btnModificar_Click(object sender, EventArgs e)
        {
            if (dgvConformidad.SelectedRows.Count > 0)
            {
                operacion = "Editar";
                txtPrecinto.Text = dgvConformidad.CurrentRow.Cells["Precinto"].Value.ToString();
                txtLuneta.Text = dgvConformidad.CurrentRow.Cells["Luneta"].Value.ToString();
                txtObstruccion.Text = dgvConformidad.CurrentRow.Cells["Obstruccion"].Value.ToString();
                txtRosBri.Text = dgvConformidad.CurrentRow.Cells["RoscaBrida"].Value.ToString();
                txtFiltro.Text = dgvConformidad.CurrentRow.Cells["Filtro"].Value.ToString();
                txtCarcaza.Text = dgvConformidad.CurrentRow.Cells["Carcaza"].Value.ToString();
                txtPuntero.Text = dgvConformidad.CurrentRow.Cells["Puntero"].Value.ToString();
                txtConclusion.Text = dgvConformidad.CurrentRow.Cells["Conclusion"].Value.ToString();
                txtSerie.Text = dgvConformidad.CurrentRow.Cells["Serie"].Value.ToString();

            }
            else
            {
                MessageBox.Show("Seleccionar una fila");
            }
        }

    }
}
