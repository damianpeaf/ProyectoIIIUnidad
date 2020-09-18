using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Clases
{
    public class Evento
    {

        DataSet ds;
        MySqlConnection cn;


        public DataSet Mostrar(int tabla, string id)
        {

            try
            {
                using (cn = new Conexion().IniciarConexion())
                {
                    string comando;

                    switch (tabla)
                    {
                        case 0:
                            comando = "SELECT * FROM evento";

                            break;

                        case 1:
                            comando = "SELECT * FROM post";
                            break;

                        default:
                            comando = "SELECT * FROM evento";
                            break;

                    }


                    if (id == "")
                    {
                        comando = comando + "";
                    }
                    else
                    {
                        if (tabla == 0)
                        {
                            comando = comando + $" where idEvento = '{id}'";
                        }
                        else if (tabla == 1)
                        {
                            comando = comando + $" where idPost = '{id}'";

                        }
                    }


                    MySqlCommand datos = new MySqlCommand(comando, cn);

                    MySqlDataAdapter m_datos = new MySqlDataAdapter(datos);
                    ds = new DataSet();
                    m_datos.Fill(ds);
                }
            }
            catch (MySqlException ex)
            {
                Console.WriteLine("" + ex);
                return null;
            }
            finally
            {
                cn.Close();
            }




            return ds;

        }

        public void Insertar(string inicia, string termina, string titulo, string descripcion,int categoria, string idUsuario)
        {
            try
            {
                using (cn = new Conexion().IniciarConexion())
                {
                    MySqlCommand comando = new MySqlCommand($"INSERT INTO evento (idEvento,inicia,termina,titulo,descripcion,idCategoria, idEstado, idUsuario)  VALUES(null,'{inicia}' , '{termina}', '{titulo}', '{descripcion}', {categoria}, 1, {idUsuario})", cn);
                    comando.ExecuteNonQuery();
                }

            }
            catch (MySqlException ex)
            {
                Console.WriteLine("" + ex);
            }
            finally
            {
                cn.Close();
            }
        }

        public void Actualizar(string id, string inicia, string termina, string titulo, string descripcion, int categoria)
        {
            try
            {
                using (cn = new Conexion().IniciarConexion())
                {
                    MySqlCommand comando = new MySqlCommand($"UPDATE evento set inicia='{inicia}', termina='{termina}', titulo='{titulo}',descripcion='{descripcion}', idCategoria={categoria} WHERE idEvento='{id}' ", cn);

                    comando.ExecuteNonQuery();
                }
            }
            catch (MySqlException ex)
            {
                Console.WriteLine("" + ex);

            }
            finally
            {
                cn.Close();
            }
        }

        public String[] Buscar(string id)
        {
            try
            {

                using (cn = new Conexion().IniciarConexion())
                {
                    MySqlCommand comando = new MySqlCommand($"SELECT * FROM evento WHERE idEvento='{id}' ", cn);
                    MySqlDataReader reader = comando.ExecuteReader();

                    String[] datos = new string[7];

                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            datos[0] = reader.GetString(0);
                            datos[1] = reader.GetString(1);
                            datos[2] = reader.GetString(2);
                            datos[3] = "Hora de publicacion: " + reader.GetString(3);
                            datos[4] = reader.GetString(4);
                            datos[5] = reader.GetString(5);
                            datos[6] = reader.GetString(6);

                        }

                        reader.Close();
                    }

                    return datos;

                }

            }
            catch (MySqlException ex)
            {
                Console.WriteLine("" + ex);
                return null;
            }
            finally
            {
                cn.Close();
            }
        }

        public void Eliminar(string id)
        {
            try
            {
                using (cn = new Conexion().IniciarConexion())
                {
                    MySqlCommand comando = new MySqlCommand($"Delete From evento where idEvento='{id}' ", cn);

                    comando.ExecuteNonQuery();
                }

            }
            catch (MySqlException ex)
            {
                Console.WriteLine("" + ex);

            }
            finally
            {
                cn.Close();
            }
        }

        public DataTable Informe()
        {

            try
            {
                using (cn = new Conexion().IniciarConexion())
                {
                    string query = "SELECT E.idEvento, E.inicia, E.termina, E.fechaDePublicacion, E.titulo, E.descripcion, C.nombre as 'Categoria', Es.nombre as 'Estado', U.nombre as 'creador' FROM  evento E INNER JOIN categoria C on E.idCategoria=C.idCategoria inner join estado Es on E.idEstado = Es.idEstado inner join Usuario U on E.idUsuario = U.idUsuario";

                    MySqlCommand comando = new MySqlCommand(query, cn);

                    MySqlDataAdapter datos = new MySqlDataAdapter(comando);
                    DataTable dt = new DataTable();
                    datos.Fill(dt);

                    return dt;

                }
            }
            catch (MySqlException ex)
            {
                Console.WriteLine("" + ex);
                return null;
            }
            finally
            {
                cn.Close();
            }


        }


    }
}
