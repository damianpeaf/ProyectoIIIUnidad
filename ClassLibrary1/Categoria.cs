using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Clases;
using MySql.Data.MySqlClient;

namespace Clases
{
    public class Categoria
    {

        MySqlConnection cn;

        public String BuscarCategoria(string id)
        {
            string nombreCategoria = "";


            try
            {

                using (cn = new Conexion().IniciarConexion())
                {
                    MySqlCommand comando = new MySqlCommand($"SELECT nombre From Categoria where idCategoria='{id}'", cn);
                    MySqlDataReader reader = comando.ExecuteReader();

                    while (reader.Read())
                    {
                        nombreCategoria= reader.GetString(0);

                    }

                    reader.Close();
                    return nombreCategoria;

                }


            }
            catch (MySqlException ex)
            {
                Console.WriteLine("NI");
                return null; 
            }
            finally
            {
                cn.Close();
            }

        }

        public List<string> ObtenerCategoria()
        {
            try
            {

                using (cn = new Conexion().IniciarConexion())
                {

                    List<string> categorias = new List<string>();

                    MySqlCommand comando = new MySqlCommand("SELECT nombre, idCategoria From Categoria order by idCategoria asc", cn);
                    MySqlDataReader reader = comando.ExecuteReader();

                    while (reader.Read())
                    {
                        categorias.Add(reader.GetString(0).ToString());
                    }

                    reader.Close();

                    return categorias;

                }
            }
            catch (MySqlException ex)
            {

                return null;
                Console.WriteLine("NI");
            }

        }

    }
}
