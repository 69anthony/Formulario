using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Web.UI.WebControls;
using System.Data;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;


namespace Modelo
{
    public class Empleado
    {
        //SELECT e.id_empleado AS id, e.codigo, e.nombres, e.apellidos, e.direccion, e.telefonos,
        //e.fecha_nacimiento, p.puesto, e.id_puesto FROM empleados as e INNER JOIN puesto as p on e.id_puesto = p.id_puesto;
        //SELECT id_puesto as id, puesto FROM puesto; 
        //INSERT INTO empleados(codigo, nombres, apellidos, dirreccion, telefonos, fecha_nacimiento, id_puesto) VALUES (,,,,,,,);
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


        public void drop_puesto(DropDownList drop)
        {
            drop.ClearSelection();
            drop.Items.Clear();
            drop.AppendDataBoundItems = true;
            drop.Items.Add("<< Elige Puesto >>");
            drop.Items[0].Value = "0";
            drop.DataSource = drop_puesto();
            drop.DataTextField = "puesto";
            drop.DataValueField = "id";
            drop.DataBind();
        }

        public void grid_empleados(GridView grid)
        {
            grid.DataSource = grid_empleado();
            grid.DataBind();
        }


        public int crear(string codigo, string nombres, string apellidos, string direccion, string telefono, string fecha, int id_puesto)
        {
            int no = 0;
            conectar = new conexionBD();
            conectar.AbrirConexion();
            string consulta = string.Format("insert into empleados(codigo,nombres,apellidos,direccion,telefonos,fecha_nacimiento,id_puesto) values('{0}','{1}','{2}','{3}','{4}','{5}',{6});", codigo, nombres, apellidos, direccion, telefono, fecha, id_puesto);
            MySqlCommand query = new MySqlCommand(consulta, conectar.conectar);
            query.Connection = conectar.conectar;
            no = query.ExecuteNonQuery();
            conectar.CerarConexion();
            return no;
        }

        public int actualizar(int id, string codigo, string nombres, string apellidos, string direccion, string telefono, string fecha, int id_puesto)
        {
            int no = 0;
            conectar = new conexionBD();
            conectar.AbrirConexion();
            string consulta = string.Format("update empleados set codigo = '{0}',nombres = '{1}',apellidos = '{2}',direccion='{3}',telefonos='{4}',fecha_nacimiento='{5}',id_puesto = {6} where id_empleado = {7};", codigo, nombres, apellidos, direccion, telefono, fecha, id_puesto, id);
            MySqlCommand query = new MySqlCommand(consulta, conectar.conectar);
            query.Connection = conectar.conectar;
            no = query.ExecuteNonQuery();
            conectar.CerarConexion();
            return no;
        }

        public int borrar(int id)
        {
            int no = 0;
            conectar = new conexionBD();
            conectar.AbrirConexion();
            string consulta = string.Format("delete from empleados  where id_empleado = {0};", id);
            MySqlCommand query = new MySqlCommand(consulta, conectar.conectar);
            query.Connection = conectar.conectar;
            no = query.ExecuteNonQuery();
            conectar.CerarConexion();
            return no;
        }
    }


}