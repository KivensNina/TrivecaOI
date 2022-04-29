using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Common.Cache;
using Domain;
using System.Data.SqlClient;
using Presentacion;

//Se puede crear un indice de abrir y ocultar código con #region + un nombre ...... y al final colocas #endregion
namespace Presentacion
{
    public partial class FormPrincipal : Form
    {
        
        private void LoadUserData()
        {
            lblNombre.Text = UserLoginCache.nombre;
            lblCargo.Text = UserLoginCache.cargo;
            lblIdUser.Text= UserLoginCache.IdUser.ToString();
        }
        public FormPrincipal()
        {
            InitializeComponent();
            PersonalizarDiseno();
        }

        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hwnd, int wmsg, int wparam, int lparam);

        private void PersonalizarDiseno()
        {
            panelSubmenuAlmacen.Visible = false;
            panelSubMenuAdmOI.Visible = false;
            panelSubMenuInspectorOI.Visible = false;
            panelSubMenuJefeOI.Visible = false;
            panelSubMenuGerenteOI.Visible = false;
        }

        private void OcultarSubmenu()
        {
            if (panelSubmenuAlmacen.Visible == true)
                panelSubmenuAlmacen.Visible = false;
            if (panelSubMenuAdmOI.Visible == true)
                panelSubMenuAdmOI.Visible = false;
            if (panelSubMenuJefeOI.Visible == true)
                panelSubMenuJefeOI.Visible = false;
            if (panelSubMenuInspectorOI.Visible == true)
                panelSubMenuInspectorOI.Visible = false;
            if (panelSubMenuGerenteOI.Visible == true)
                panelSubMenuGerenteOI.Visible = false;
        }

        private void MostrarSubmenu(Panel submenu)
        {
            if (submenu.Visible == false)
            {
                OcultarSubmenu();
                submenu.Visible = true;
            }
            else
                submenu.Visible = false;
        }

        private void solicitudDeInspecciónToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        public void btnAlmacen_Click(object sender, EventArgs e)
        {
            MostrarSubmenu(panelSubmenuAlmacen);
        }

        private void btnAdministrativoOI_Click(object sender, EventArgs e)
        {
            MostrarSubmenu(panelSubMenuAdmOI);
        }

        private void btnJefeOI_Click(object sender, EventArgs e)
        {
            MostrarSubmenu(panelSubMenuJefeOI);
        }

        private void btnInspectorOI_Click(object sender, EventArgs e)
        {
            MostrarSubmenu(panelSubMenuInspectorOI);
        }

        private void btnGerenteOI_Click(object sender, EventArgs e)
        {
            MostrarSubmenu(panelSubMenuGerenteOI);
        }

        private void btnSolCotizacionInterno_Click(object sender, EventArgs e)
        {
            AbrirFormulariosenPanel<FormGenerarSolicitudCotizacion>();
            //..
            //codigo que muestre contenido al costado

        }

        private void btnListarSolCotizacionesAlmac_Click(object sender, EventArgs e)
        {
            AbrirFormulariosenPanel<ListarSolicitudesCotizacion>();
            //..
            //codigo que muestre contenido al costado

        }
        public void versol()
        {
            AbrirFormulariosenPanel<FormVisualizarSolicitudCotizacion>();
            //..
            //codigo que muestre contenido al costado

        }

        private void btnSolCotizacionExterno_Click(object sender, EventArgs e)
        {
            AbrirFormulariosenPanel<FormGenerarSolicitudCotizacionAdmOI>();
            //codigo que muestre contenido al costado

            OcultarSubmenu();
        }

        private void btnListarSolCotizacionesAdmOI_Click(object sender, EventArgs e)
        {
            AbrirFormulariosenPanel<ListarSolCotOI>();
            //codigo que muestre contenido al costado

            OcultarSubmenu();
        }

        private void btnListarSolInspeccionAdmOI_Click(object sender, EventArgs e)
        {
            //..
            AbrirFormulariosenPanel<ListarSolInspeccion>();

            OcultarSubmenu();
        }

        private void btnCertificadosAdmOI_Click(object sender, EventArgs e)
        {
            //..
            //codigo que muestre contenido al costado

            OcultarSubmenu();
        }

        private void btnListarSolInspeccionJefeOI_Click(object sender, EventArgs e)
        {
            //..
            AbrirFormulariosenPanel<ListarSolInspeccion>();

            OcultarSubmenu();
        }

        private void btnOrdenTrabajoJefeOI_Click(object sender, EventArgs e)
        {
            //..
            //codigo que muestre contenido al costado

            OcultarSubmenu();
        }

        private void btnInformesJefeOI_Click(object sender, EventArgs e)
        {
            //..
            //codigo que muestre contenido al costado

            OcultarSubmenu();
        }

        private void btnOrdenTrabajoInspectorOI_Click(object sender, EventArgs e)
        {
            //..
            //codigo que muestre contenido al costado

            OcultarSubmenu();
        }

        private void btnInformeEstatica_Click(object sender, EventArgs e)
        {
            //..
            //codigo que muestre contenido al costado

            OcultarSubmenu();
        }

        private void btnInformeErrores_Click(object sender, EventArgs e)
        {
            //..
            //codigo que muestre contenido al costado

            OcultarSubmenu();
        }

        private void btnListaOrdenTrabajoGerenteOI_Click(object sender, EventArgs e)
        {
            //..
            //codigo que muestre contenido al costado

            OcultarSubmenu();
        }

        private void btnListaInformesGerenteOI_Click(object sender, EventArgs e)
        {
            //..
            //codigo que muestre contenido al costado

            OcultarSubmenu();
        }

        private void btnListaCertificadosGerenteOI_Click(object sender, EventArgs e)
        {
            //..
            //codigo que muestre contenido al costado

            OcultarSubmenu();
        }

        private void btnListaMedidores_Click(object sender, EventArgs e)
        {
            //..
            //codigo que muestre contenido al costado

            OcultarSubmenu();
        }

        //private Form FormularioActivo = null;
        //private void AbrirFormularioPanelLateral(Form FormularioHijo)
        //{
        //    if (FormularioActivo != null)
        //        FormularioActivo.Close();
        //    FormularioActivo = FormularioHijo;
        //    FormularioHijo.TopLevel = false;
        //    FormularioHijo.FormBorderStyle = FormBorderStyle.None;
        //    FormularioHijo.Dock = DockStyle.Fill;
        //    panelFormularios.Controls.Add(FormularioHijo);
        //    panelFormularios.Tag = FormularioHijo;
        //    FormularioHijo.BringToFront();
        //    FormularioHijo.Show();
        //
        //}

        //METODO PARA VARIOS FORMULARIOS DENTRO DEL PANEL LATERAL
        public void AbrirFormulariosenPanel<MiForm>() where MiForm : Form, new()
        {
            Form formulario;
            formulario = panelFormularios.Controls.OfType<MiForm>().FirstOrDefault();//Busca formulario en la colección
            if (formulario == null)
            {
                formulario = new MiForm();
                formulario.TopLevel = false;
                panelFormularios.Controls.Add(formulario);
                panelFormularios.Tag = formulario;
                formulario.Show();
            }
            //si el formulario o instancia existe
            else
            {
                formulario.BringToFront();
            }

        }
        
        private void pbtnCerrar_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("¿Seguro que deseas Salir?",
                "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                Application.Exit();
        }

        private void panelSuperior_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void panelLogo_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void FormPrincipal_Load(object sender, EventArgs e)
        {
            LoadUserData();
            //Permisos por provilegios
            if (UserLoginCache.privilegio == Privilegios.Administrador)
            {
                //All
            }
            if (UserLoginCache.privilegio == Privilegios.Almacen)
            {
                btnAdministrativoOI.Enabled = false;
                btnJefeOI.Enabled = false;
                btnInspectorOI.Enabled = false;
                btnGerenteOI.Enabled = false;
            }
            if (UserLoginCache.privilegio == Privilegios.AdministrativoOI)
            {
                btnAlmacen.Enabled = false;
                btnJefeOI.Enabled = false;
                btnInspectorOI.Enabled = false;
                btnGerenteOI.Enabled = false;
            }
            if (UserLoginCache.privilegio == Privilegios.Inspector)
            {
                btnAlmacen.Enabled = false;
                btnJefeOI.Enabled = false;
                btnAdministrativoOI.Enabled = false;
                btnGerenteOI.Enabled = false;
            }
            if (UserLoginCache.privilegio == Privilegios.JefeOI)
            {
                btnAlmacen.Enabled = false;
                btnGerenteOI.Enabled = false;
            }
            if (UserLoginCache.privilegio == Privilegios.GerenteOI)
            {
                btnAlmacen.Enabled = false;
            }
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("¿Seguro que deseas Salir?",
                "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                this.Close();
            Logueo login = new Logueo();
            login.Show();
            this.Hide();
        }
    }
}
