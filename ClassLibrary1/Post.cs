﻿using Clases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using MySql.Data.MySqlClient;

namespace Clases
{
    public class Post
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

        public void Insertar(string titulo, string contenido, int categoria)
        {
            try
            {
                using (cn = new Conexion().IniciarConexion())
                {
                    MySqlCommand comando = new MySqlCommand($"INSERT INTO post (idPost,titulo,contenido,idCategoria,idEstado)  VALUES(null,'{titulo}' , '{contenido}', {categoria}, 1)", cn);
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

        public void Actualizar(string id, string titulo, string contenido, int idCategoria)
        {
            try
            {
                using (cn = new Conexion().IniciarConexion())
                {
                    MySqlCommand comando = new MySqlCommand($"UPDATE post set titulo='{titulo}', contenido='{contenido}', idCategoria={idCategoria} WHERE idPost='{id}' ", cn);

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
                    MySqlCommand comando = new MySqlCommand($"SELECT * FROM post WHERE idPost='{id}' ", cn);
                    MySqlDataReader reader = comando.ExecuteReader();

                    String[] datos = new string[5];

                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            datos[0] = reader.GetString(0);
                            datos[1] = reader.GetString(1);
                            datos[2] = "Hora de Publicacion: " + reader.GetString(2);
                            datos[3] = reader.GetString(3);
                            datos[4] = reader.GetString(4);
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
                    MySqlCommand comando = new MySqlCommand($"Delete From Post where idPost='{id}' ", cn);

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
    }
}