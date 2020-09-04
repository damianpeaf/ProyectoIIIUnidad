using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1.CorreoServicio
{
    class configuracionCorreo:Correo
    {
        public configuracionCorreo()
        {
            correo = "soporteJuventudDB@gmail.com";
            pass = "juventud123";
            host = "smtp.gmail.com";
            puerto = 587;
            ssl = true;
            InicioCliente();

        }
    }
}
