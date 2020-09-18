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

        public string recuperarContraseña(string correo)
        {
            return usuario.recuperarContraseña(correo);
        }

        public void crearUsuario(string nombre, string correo, string usuarioP, string contraseña, int tipo) 
        {

            usuario.crearUsuario(nombre, correo, usuarioP, contraseña, tipo);
        
        }

        public List<String> tipoUsuario()
        {
            return usuario.obtenerTipo();
        }

    }
}
