using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using primeraEntrega.Controllers;
using primeraEntrega.Models;

namespace primeraEntrega
{  
    public partial class FrmVariable : System.Web.UI.Page
    {
        protected Variable[] arregloVariable = null;
        protected Usuario[] arregloUsuario = null;
        protected void Page_Load(object sender, EventArgs e)
        {
            ControlVariable objControlVariable = new ControlVariable(null);
            arregloVariable = objControlVariable.Listar();

            ControlUsuario objControlUsuario = new ControlUsuario(null);
            arregloUsuario = objControlUsuario.Listar();
            for (int i = 0; i < arregloUsuario.Length; i++)
            {
                ddlEmail.Items.Add(arregloUsuario[i].Email);
            }

            DateTime fechaActual = DateTime.Now;
            string FechaFormato = fechaActual.ToString("dd/MM/yyyy HH:mm:ss");
            txtFechaCreacion.Text = FechaFormato;

            foreach (Usuario tipoUsuario in arregloUsuario)
            {
                ListItem listItem = new ListItem();
                listItem.Value = tipoUsuario.Email;
                listItem.Text = tipoUsuario.Email;

                ddlEmail.Items.Add(listItem);
            }
        }

        protected void BtnGuardar(object sender, CommandEventArgs e)
        {
            string nombre = txtNombre.Text;
            DateTime fecha = Convert.ToDateTime(txtFechaCreacion.Text);
            string fechaCreacion = fecha.ToString("yyyy-MM-dd HH:mm:ss");
            string fkEmailUsuario= ddlEmail.SelectedValue;
            Variable objVariable = new Variable(0,nombre, fechaCreacion, fkEmailUsuario);
            ControlVariable objControlVariable = new ControlVariable(objVariable);
            objControlVariable.Guardar();

            Response.Redirect("FrmVariable.aspx");

        }

        protected void BtnModificar(object sender, CommandEventArgs e)
        {
            int id = Convert.ToInt32(txtId.Text);
            string nombre = txtNombre.Text;
            DateTime fecha = Convert.ToDateTime(txtFechaCreacion.Text);
            string fechaCreacion = fecha.ToString("yyyy-MM-dd HH:mm:ss");
            string fkEmailUsuario = ddlEmail.SelectedValue;
            Variable objVariable = new Variable(id, nombre, fechaCreacion, fkEmailUsuario);
            ControlVariable objControlVariable = new ControlVariable(objVariable);
            objControlVariable.Modificar();

            Response.Redirect("FrmVariable.aspx");

        }

        protected void BtnBorrar(object sender, CommandEventArgs e)
        {
            int id = Convert.ToInt32(txtId.Text);
            Variable objVariable = new Variable(id);
            ControlVariable objControlVariable = new ControlVariable(objVariable);
            objControlVariable.Borrar();

            Response.Redirect("FrmVariable.aspx");

        }

        protected void BtnConsultar(object sender, CommandEventArgs e)
        {
            int id = Convert.ToInt32(txtId.Text);
            Variable objVariable = new Variable(id);
            ControlVariable objControlVariable = new ControlVariable(objVariable);
            objControlVariable.Consultar();
            txtNombre.Text = objVariable.Nombre;
            txtFechaCreacion.Text = objVariable.FechaCreacion.ToString();
            ddlEmail.SelectedValue = objVariable.FkEmailUsuario;
        }
    }
}