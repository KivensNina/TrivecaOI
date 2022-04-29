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

namespace Presentacion
{
    public partial class ListarSolCotOI : Form
    {
        public ListarSolCotOI()
        {
            InitializeComponent();
        }

        private void ListarSolCotOI_Load(object sender, EventArgs e)
        {
            ListarSolCotEnviados();
        }

        SolCotModel objetoSC = new SolCotModel();
        public void ListarSolCotEnviados()
        {
            dgwListar.DataSource = objetoSC.ListarSolCotEnviados();
        }

        private void dgwListar_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            FormGenerarSolicitudInspeccion formulario = new FormGenerarSolicitudInspeccion();
            formulario.Show();
            formulario.txtNroSol.Text = dgwListar.SelectedCells[0].Value.ToString();
            formulario.visualizar_sol_cot();
        }
    }
}
