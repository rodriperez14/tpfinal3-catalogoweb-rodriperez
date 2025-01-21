using dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace negocio
{
    public static class Seguridad
    {
        public static bool sesionActiva(object userr)
        {

            User user = userr != null ? (User)userr : null;
            if (user != null && user.Id != 0)
                return true;
            else
                return false;
        }

        public static bool esAdmin(object userr)
        {
            User user = userr != null ? (User)userr : null;
            return user != null ? user.Admin : false;
        }
    }
}
