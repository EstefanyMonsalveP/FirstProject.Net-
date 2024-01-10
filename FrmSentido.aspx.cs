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
    public partial class FrmSentido : System.Web.UI.Page
    {
        protected Sentido[] arregloSentido = null;
        protected void Page_Load(object sender, EventArgs e)
        {
            ControlSentido objControlSentido = new ControlSentido(null);
            arregloSentido = objControlSentido.Listar();

        }

        protected void BtnGuardar(object sender, CommandEventArgs e)
        {
            string nombre = txtNombre3.Text;

            Sentido objSentido = new Sentido(nombre);
            ControlSentido objControlSentido = new ControlSentido(objSentido);
            string msg = objControlSentido.Guardar();
            Response.Redirect("FrmSentido.aspx");

        }

        protected void BtnConsultar(object sender, CommandEventArgs e)
        {
            int id = Convert.ToInt32(txtId3.Text);

            Sentido objSentido = new Sentido(id,"");
            ControlSentido objControlSentido = new ControlSentido(objSentido);
            objSentido = objControlSentido.Consultar();
            txtNombre3.Text = objSentido.Nombre;
        }

        protected void BtnModificar(object sender, CommandEventArgs e)
        {
            int id = Convert.ToInt32(txtId3.Text);
            string nom = txtNombre3.Text;
            Sentido objSentido = new Sentido(id, nom);
            ControlSentido objControlSentido = new ControlSentido(objSentido);
            objControlSentido.Modificar();


        }

        protected void BtnBorrar(object sender, CommandEventArgs e)
        {
            int id = Convert.ToInt32(txtId3.Text);
            Sentido objSentido = new Sentido(id, "");
            ControlSentido objControlSentido = new ControlSentido(objSentido);
            objControlSentido.Borrar();

        }
    }
}