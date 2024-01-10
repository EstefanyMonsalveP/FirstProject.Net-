using primeraEntrega.Controllers;
using primeraEntrega.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace primeraEntrega
{
    public partial class FrmRepresenVisual : System.Web.UI.Page
    {
        protected RepresenVisual[] arregloRepresenVisual = null;
        protected void Page_Load(object sender, EventArgs e)
        {
            ControlRepresenVisual objControlRepresenVisual = new ControlRepresenVisual(null);
            arregloRepresenVisual = objControlRepresenVisual.Listar();

        }

        protected void BtnGuardar(object sender, CommandEventArgs e)
        {
            string nombre = txtNombre2.Text;

            RepresenVisual objRepresenVisual = new RepresenVisual(nombre);
            ControlRepresenVisual objControlRepresenVisual = new ControlRepresenVisual(objRepresenVisual);
            string msg = objControlRepresenVisual.Guardar();
            Response.Redirect("FrmRepresenVisual.aspx");

        }

        protected void BtnConsultar(object sender, CommandEventArgs e)
        {
            int id = Convert.ToInt32(txtId2.Text);

            RepresenVisual objRepresenVisual = new RepresenVisual(id, "");
            ControlRepresenVisual objControlRepresenVisual = new ControlRepresenVisual(objRepresenVisual);
            objRepresenVisual = objControlRepresenVisual.Consultar();
            txtNombre2.Text = objRepresenVisual.Nombre;
        }

        protected void BtnModificar(object sender, CommandEventArgs e)
        {
            int id = Convert.ToInt32(txtId2.Text);
            string nom = txtNombre2.Text;
            RepresenVisual objRepresenVisual = new RepresenVisual(id, nom);
            ControlRepresenVisual objControlRepresenVisual = new ControlRepresenVisual(objRepresenVisual);
            objControlRepresenVisual.Modificar();


        }

        protected void BtnBorrar(object sender, CommandEventArgs e)
        {
            int id = Convert.ToInt32(txtId2.Text);
            RepresenVisual objRepresenVisual = new RepresenVisual(id, "");
            ControlRepresenVisual objControlRepresenVisual = new ControlRepresenVisual(objRepresenVisual);
            objControlRepresenVisual.Borrar();

        }
    }
}