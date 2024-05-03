using Modelo;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Windows.Forms;

namespace Crud_Formulario
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        Empleado empleado;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                empleado = new Empleado();
                empleado.grid_empleados(grid_empleado);
            }

        }

        protected void btn_crear_Click(object sender, EventArgs e)
        {
            conexionBD cn = new conexionBD();
            cn.AbrirConexion();
            cn.CerarConexion();
            //MessageBox.Show("Hello, world.");

        }
    }
}