using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using Common.Cache;

namespace DataAccess
{
    public class UserDao:coneccionSQL
    {
        //public void editarUsuario()
        //{
        //
        //}

        public bool Login(string user, string pass)
        {
            using (var connection = GetConnection())
            {
                connection.Open();
                using (var command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "iniciar_sesion";
                    command.Parameters.AddWithValue("@user_login", user);
                    command.Parameters.AddWithValue("@pass_login", pass);
                    command.CommandType = CommandType.StoredProcedure;
                    SqlDataReader reader = command.ExecuteReader();
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            UserLoginCache.IdUser = reader.GetInt32(0);
                            UserLoginCache.nombre = reader.GetString(1);
                            UserLoginCache.cargo = reader.GetString(2);
                            UserLoginCache.privilegio = reader.GetString(5);
                            UserLoginCache.correo = reader.GetString(6);

                        }
                        return true;
                    }
                    else

                        return false;

                }
            }

        }

        public void Permisos()
        {
            if (UserLoginCache.privilegio == Privilegios.Administrador)
            {
                //Code
            }
            if (UserLoginCache.privilegio == Privilegios.Almacen)
            {
                //Code
            }
            if (UserLoginCache.privilegio == Privilegios.AdministrativoOI)
            {
                //Code
            }
            if (UserLoginCache.privilegio == Privilegios.Inspector)
            {
                //Code
            }
            if (UserLoginCache.privilegio == Privilegios.JefeOI)
            {
                //Code
            }
            if (UserLoginCache.privilegio == Privilegios.GerenteOI)
            {
                //Code
            }
        }

        public string recoverPassword(string usuarioRequerido)
        {
            using (var connection = GetConnection())
            {
                connection.Open();
                using (var command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "recover_password";
                    command.Parameters.AddWithValue("@user_login", usuarioRequerido);
                    command.Parameters.AddWithValue("@correo", usuarioRequerido);
                    command.CommandType = CommandType.StoredProcedure;
                    SqlDataReader reader = command.ExecuteReader();

                    if (reader.Read() == true)
                    {
                        string nombre = reader.GetString(1);
                        string correo = reader.GetString(6);
                        string claveusuario = reader.GetString(4);

                        var mailService = new MailServices.SystemSupportMail();
                        mailService.sendMail(
                                        subject: "Recuperar contraseña Sistema OI",
                                        body: "Hola, " + nombre + "\nHas requerido la recuperación de tu contraseña." +
                                        "\n\nTu contraseña es: " + claveusuario +
                                        "\n\nSin embargo, le recomendamos actualizar su contraseña",

                                        recipientMail: new List<string> { correo }
                                             );
                        return "Hola, " + nombre + "\nHas Solicitado la recuperación de tu contraseña." +
                                        "\nVerifica tu bandeja de correo: " + correo + 
                                        "\nAsunto: Recuperar contraseña Sistema OI" +
                                        "\n\nLe recomendamos cambiar su contraseña";
                    }
                    else
                        return "Lo sentimos, usted no tiene una cuenta con este usuario o correo electrónico";
                }
            }
        }

        public bool Loguear(string usuario, string contraseña)
        {
            using (var connection = GetConnection())
            {
                connection.Open();
                using (var command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "select nombre, estado.descripcion, privilegio from usuario join estado on usuario.id_estado = estado.id_estado " +
                        "WHERE @user_login = user_login and @pass_login = pass_login";

                    command.Parameters.AddWithValue("@user_login", usuario);
                    command.Parameters.AddWithValue("@pass_login", contraseña);
                    SqlDataAdapter sda = new SqlDataAdapter(command);
                    DataTable dt = new DataTable();
                    sda.Fill(dt);

                    if (dt.Rows.Count == 1 && dt.Rows[0][1].ToString() == "activo")
                    {

                        return true;
                    }

                    else

                        return false;


                }
            }
        }

    }
}
