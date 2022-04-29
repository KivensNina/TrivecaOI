using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Domain;
using Presentacion;

namespace Presentacion
{
    public partial class ListarSolicitudesCotizacion : Form
    {
        SolCotModel objetoSC = new SolCotModel();

        public ListarSolicitudesCotizacion()
        {
            InitializeComponent();
        }

        private void ListarSolicitudesCotizacion_Load(object sender, EventArgs e)
        {
            MostrarSolCot();
        }
        public void MostrarSolCot()
        {
            dgwListar.DataSource = objetoSC.MostrarSolicCotiz();
        }

        private void dgwListar_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            FormVisualizarSolicitudCotizacion formulario = new FormVisualizarSolicitudCotizacion();
            formulario.Show();
            formulario.txtNroSol.Text = dgwListar.SelectedCells[0].Value.ToString();
            formulario.visualizar_sol_cot();
        }
    }
}
