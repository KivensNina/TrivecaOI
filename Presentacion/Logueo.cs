using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using Domain;
using System.Data.SqlClient;
using Presentacion;
using Common.Cache;

namespace Presentacion
{
    public partial class Logueo : Form
    {
        public Logueo()
        {
            InitializeComponent();
        }
        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hwnd, int wmsg, int wparam, int lparam);


        private void txtPassword_Enter(object sender, EventArgs e)
        {
            txtPassword.UseSystemPasswordChar = true;
        }

        private void txtPassword_Leave(object sender, EventArgs e)
        {
            txtPassword.UseSystemPasswordChar = true;
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Logueo_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void panelLogo_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }
        


        private void btnAcceder_Click(object sender, EventArgs e)
        {
            if (txtUsuario.Text != "")
            {
                if (txtPassword.Text != "")
                {
                    UserModel user = new UserModel();
                    var validLogin = user.LoginUser(txtUsuario.Text, txtPassword.Text);
                    
                    if(validLogin == true)
                    {
                        UserModel user1 = new UserModel();
                        var validLogin1 = user1.LoguearUser(txtUsuario.Text, txtPassword.Text);
                       
                        if (validLogin1 == true)
                      {
                          FormPrincipal menu = new FormPrincipal();
                          //MessageBox.Show("Bienvenido" + UserLoginCache.nombre);
                          menu.Show();
                          this.Hide();
                      }
                        else
                        {
                            MessageBox.Show("Usuario inactivo, intenta nuevamente");
                            txtUsuario.Clear();
                            txtPassword.Clear();
                            txtUsuario.Focus();
                        }
                    }
                    else
                    {
                        MessageBox.Show("Usuario o contraseña incorrecto, intenta nuevamente");
                        txtPassword.Clear();
                        txtUsuario.Focus();
                    }

                }
                else
                {
                    MessageBox.Show("Por favor ingrese una contraseña");
                    txtPassword.Focus();
                }
               
            }
            else
            {
                MessageBox.Show("Por favor ingrese un usuario");
                txtUsuario.Focus();
            }

        }

        private void lklblRestablecer_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            var recoverPassword = new FormRecoverPassword();
            recoverPassword.ShowDialog();
        }
    }
        

}

