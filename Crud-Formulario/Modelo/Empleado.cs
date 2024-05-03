using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Web.UI.WebControls;
using System.Data;


namespace Modelo
{
    public class Empleado
    {
        //SELECT e.id_empleado AS id, e.codigo, e.nombres, e.apellidos, e.direccion, e.telefonos,
        //e.fecha_nacimiento, p.puesto, e.id_puesto FROM empleados as e INNER JOIN puesto as p on e.id_puesto = p.id_puesto;
        //SELECT id_puesto as id, puesto FROM puesto; 
        conexionBD conectar;
        
        private DataTable drop_puesto()
        {
            DataTable dt = new DataTable();
            conectar = new conexionBD();
            conectar.AbrirConexion();
            string consulta = string.Format("SELECT id_puesto as id, puesto FROM puesto;");
            //Para ejecutar la consulta
            MySqlDataAdapter query = new MySqlDataAdapter(consulta, conectar.conectar);
            //Para ejecutar el Query
            query.Fill(dt);
            conectar.CerarConexion();
            return dt;
        }

        private DataTable grid_empleado() 
        {
            DataTable dt = new DataTable();
            conectar = new conexionBD();
            conectar.AbrirConexion();
            string consulta = string.Format("SELECT e.id_empleado AS id, e.codigo, e.nombres, e.apellidos, e.direccion, e.telefonos," +
                "e.fecha_nacimiento, p.puesto, e.id_puesto FROM empleados as e INNER JOIN puesto as p on e.id_puesto = p.id_puesto;");
            MySqlDataAdapter query = new MySqlDataAdapter(consulta, conectar.conectar);
            query.Fill(dt);
            conectar.CerarConexion();
            return dt;
        }

        public void grid_empleados(GridView grid)
        {
            grid.DataSource = grid_empleado();
            grid.DataBind();
        }

    }
}