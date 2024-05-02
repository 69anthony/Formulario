using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using MySql.Data.MySqlClient;
using System.Windows.Forms;


namespace Modelo
{
    public class conexionBD
    {
        private string cadena = "server=localhost; database=bd_empresa; user=root; password=";
        public MySqlConnection conectar = new MySqlConnection();


        public void AbrirConexion()
        {
            try
            {
                conectar.ConnectionString = cadena;
                conectar.Open();
                //MessageBox.Show("Conectado");
            }
            catch (Exception ex)
            {
                //System.Diagnostics.Debug.WriteLine(ex.Message);
                MessageBox.Show("Error");
                Console.WriteLine(ex.StackTrace);

            }

        }
        public void CerarConexion()
        {

            if (conectar.State == ConnectionState.Open)
            {
                conectar.Close();
                //MessageBox.Show("Desconectado");
            }

        }
    }
}

