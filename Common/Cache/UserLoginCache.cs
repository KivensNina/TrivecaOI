using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Cache
{
    public static class UserLoginCache
    {
        public static int IdUser { get; set; }
        public static string nombre { get; set; }
        public static string cargo { get; set; }
        public static string privilegio { get; set; }
        public static string correo { get; set; }
    }
}
