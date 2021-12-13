using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess
{
    public class User
    {
        public string Rut { get; set; }
        public string Nombre { get; set; }

        public string Apellido { get; set; }

        public string Contraseña { get; set; }

        public string Supervisor { get; set; }

        public int Rol { get; set; }
    }
}
