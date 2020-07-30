using MySql.Data.MySqlClient;
using System;
using Clases;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clases
{
    public class Conexion
    {


        private MySqlConnection conexion = new MySqlConnection();

        public MySqlConnection IniciarConexion()
        {

            try
            {
                String con = "Server=127.0.0.1;Uid=root;pwd=;database=proyecto3unidad";
                conexion.ConnectionString = con;
                conexion.Open();
                    
                return conexion;
            }
            catch (MySqlException ex)
            {
                Console.WriteLine("NI");
                return null;
            }
        }

        public MySqlConnection CerrarConexion()
        {
            if (conexion.State == ConnectionState.Closed)
                conexion.Close();
            return conexion;
        }

    }



}
