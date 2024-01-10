using primeraEntrega.Controllers;
using primeraEntrega.Models;
using System;
using System.Web.UI.WebControls;

namespace primeraEntrega
{
    public partial class FrmFuente : System.Web.UI.Page
    {
        protected Fuente[] arregloFuente = null;
        protected void Page_Load(object sender, EventArgs e)
        {
            ControlFuente objControlFuente = new ControlFuente(null);
            arregloFuente = objControlFuente.Listar();

        }

        protected void BtnGuardar(object sender, CommandEventArgs e)
        {
            string nombre = txtNombre1.Text;

            Fuente objFuente = new Fuente(nombre);
            ControlFuente objControlFuente = new ControlFuente(objFuente);
            string msg = objControlFuente.Guardar();
            Response.Redirect("FrmFuente.aspx");

        }

        protected void BtnConsultar(object sender, CommandEventArgs e)
        {
            int id = Convert.ToInt32(txtId1.Text);

            Fuente objFuente = new Fuente(id, "");
            ControlFuente objControlFuente = new ControlFuente(objFuente);
            objFuente = objControlFuente.Consultar();
            txtNombre1.Text = objFuente.Nombre;
        }

        protected void BtnModificar(object sender, CommandEventArgs e)
        {
            int id = Convert.ToInt32(txtId1.Text);
            string nom = txtNombre1.Text;
            Fuente objFuente = new Fuente(id, nom);
            ControlFuente objControlFuente = new ControlFuente(objFuente);
            objControlFuente.Modificar();
            Response.Redirect("FrmFuente.aspx");

        }

        protected void BtnBorrar(object sender, CommandEventArgs e)
        {
            int id = Convert.ToInt32(txtId1.Text);
            Fuente objFuente = new Fuente(id, "");
            ControlFuente objControlFuente = new ControlFuente(objFuente);
            objControlFuente.Borrar();
            Response.Redirect("FrmFuente.aspx");

        }
    }
}