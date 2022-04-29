using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess;
using Common.Cache;

namespace Domain
{
    public class UserModel
    {
        UserDao userDao = new UserDao();

        public bool LoginUser(string user, string pass)
        {
            return userDao.Login(user, pass);
        }
        public bool LoguearUser(string usuario, string contraseña)
        {
            return userDao.Loguear(usuario, contraseña);
        }

        public string recoverPassword(string userRequesting)
        {
            return userDao.recoverPassword(userRequesting);
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
    }
}
