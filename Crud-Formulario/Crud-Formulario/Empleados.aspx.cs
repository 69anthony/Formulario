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
                empleado.drop_puesto(drop_puesto);
                empleado.grid_empleados(grid_empleado);
            }

        }

        protected void btn_crear_Click(object sender, EventArgs e)
        {
            empleado = new Empleado();
            if (empleado.crear(txt_codigo.Text,txt_nombre.Text,txt_apellido.Text,txt_direccion.Text,txt_telefono.Text,txt_fn.Text,Convert.ToInt32(drop_puesto.SelectedValue)) > 0)
            { 
                lbl_mensaje.Text = "Ingreso Exitoso";
                empleado.grid_empleados(grid_empleado);
             
            }

        }

        protected void grid_empleado_SelectedIndexChanged(object sender, EventArgs e)
        {
            grid_empleado_SelectedIndexChanged(sender, e, txt_fn);
        }

        protected void grid_empleado_SelectedIndexChanged(object sender, EventArgs e, System.Web.UI.WebControls.TextBox txt_fn)
        {
            txt_codigo.Text = grid_empleado.SelectedRow.Cells[0].Text;
            txt_nombre.Text = grid_empleado.SelectedRow.Cells[1].Text;
            txt_apellido.Text = grid_empleado.SelectedRow.Cells[2].Text;
            txt_direccion.Text = grid_empleado.SelectedRow.Cells[3].Text;
            txt_telefono.Text = grid_empleado.SelectedRow.Cells[4].Text;
            DateTime fecha = Convert.ToDateTime(grid_empleado.SelectedRow.Cells[5].Text);
            txt_fn.Text = fecha.ToString("yyyy-MM-dd");
            int indice = grid_empleado.SelectedRow.RowIndex;
            drop_puesto.SelectedValue = grid_empleado.DataKeys[indice].Values["id_puesto"].ToString();
            btn_actualizar.Visible = true;
        }

        protected void grid_empleados_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            empleado = new Empleado();
            if (empleado.borrar(Convert.ToInt32(e.Keys["id"])) > 0)
            {
                lbl_mensaje.Text = "Eliminado Exitoso";
                empleado.grid_empleados(grid_empleado);

            }
        }

        protected void drop_puesto_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void btn_actualizar_Click(object sender, EventArgs e)
        {
            empleado = new Empleado();
            if (empleado.actualizar(Convert.ToInt32(grid_empleado.SelectedValue), txt_codigo.Text, txt_nombre.Text, txt_apellido.Text, txt_direccion.Text, txt_telefono.Text, txt_fn.Text, Convert.ToInt32(drop_puesto.SelectedValue)) > 0)
            {
                lbl_mensaje.Text = "Modificado Exitoso";
                empleado.grid_empleados(grid_empleado);

            }
        }
    }
}