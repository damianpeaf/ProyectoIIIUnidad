using Comun;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClassLibrary1.CorreoServicio;

namespace Clases
{
    public class Usuario 
    {

        MySqlConnection cn;

        public String[] validarUsuario(string user, string pass)
        {
            try
            {
                String[] datosUsuario = new string[4];

                using (cn = new Conexion().IniciarConexion())
                {
                    MySqlCommand comando = new MySqlCommand($"SELECT * FROM usuario where usuario='{user}' and contraseña='{pass}' ", cn);
                    MySqlDataReader reader = comando.ExecuteReader();

                    if (reader.HasRows)
                    {

                        while (reader.Read())
                        {
                            info_usuario.idUsuario =  datosUsuario[0] = reader.GetString(0);
                            info_usuario.nombre = datosUsuario[1] = reader.GetString(1);
                            info_usuario.apellido = datosUsuario[2] = reader.GetString(2);
                            info_usuario.idTipoUsuario =datosUsuario[3] = reader.GetString(5);

                        }

                        reader.Close();


                        return datosUsuario;

                    }
                    else
                    {
                        Console.WriteLine("no devolvio nada el where");
                        return null;
                    }
                }
            }
            catch (MySqlException ex)
            {
                Console.WriteLine(ex);
                return null;
            }
        }

        public String recuperarContraseña(string correo)
        {
            using (cn = new Conexion().IniciarConexion())
            {
                MySqlCommand comando = new MySqlCommand($"SELECT * FROM usuario WHERE correo='{correo}' ", cn);
                MySqlDataReader datos = comando.ExecuteReader();

                if (datos.HasRows)
                {
                    string correoUsuario = "";
                    string nombreUsuario = "";
                    string contraseñaUsuario = "";

                    if (datos.Read())
                    {
                        nombreUsuario = datos.GetString(1);
                        correoUsuario = datos.GetString(2);
                        contraseñaUsuario = datos.GetString(4);


                        var servicio = new configuracionCorreo();

                        servicio.EnviarMensaje("Recuperacion Contraseña - Juventud APP", $"Estimado {nombreUsuario}, su solicitud para recuperar su contraseña ha sido procesada. Su Contraseña es: {contraseñaUsuario}", correoUsuario);
                    
                        
                    }

                    return $"Te hemos enviado un mensaje, chequea tu correo electronico {correoUsuario}";


                }
                else
                {
                    return "Correo Incorrecto o no registrado";
                }

            }
        }

    }
}
