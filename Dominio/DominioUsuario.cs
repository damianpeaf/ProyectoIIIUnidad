using Clases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class DominioUsuario
    {

        Usuario usuario = new Usuario();


        public String[] validarUsuario(string user, string pass)
        {
            return usuario.validarUsuario(user, pass);
        }
    }
}
