using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Common.Cache;

namespace Presentacion
{
    public partial class Esperar : Form
    {
        public Esperar()
        {
            InitializeComponent();
        }

        private void Esperar_Load(object sender, EventArgs e)
        {
            LoadUserData();
        }
        private void LoadUserData()
        {
            lblNombre.Text = UserLoginCache.nombre;
            lblCargo.Text = UserLoginCache.cargo;
        }
    }
}
