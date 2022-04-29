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
    public partial class ListarSolInspeccion : Form
    {
        SolInspecModel objetoSI = new SolInspecModel();

        public ListarSolInspeccion()
        {
            InitializeComponent();
        }

        private void ListarSolInspeccion_Load(object sender, EventArgs e)
        {
            ListarSolInspec();
        }

        public void ListarSolInspec()
        {
            dgwListar.DataSource = objetoSI.ListarSolicInspec();
        }

        private void dgwListar_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            GenerarOrdenTrabajo formulario = new GenerarOrdenTrabajo();
            formulario.Show();
            formulario.txtNroSolInspec.Text = dgwListar.SelectedCells[0].Value.ToString();
            formulario.visualizar_sol_cot();
        }
    }
}
