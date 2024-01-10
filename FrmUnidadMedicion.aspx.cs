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
    public partial class FrmUnidadMedicion : System.Web.UI.Page
    {
        protected UnidadMedicion[] arregloUnidadMedicion = null;
        protected void Page_Load(object sender, EventArgs e)
        {
            ControlUnidadMedicion objControlUnidadMedicion = new ControlUnidadMedicion(null);
            arregloUnidadMedicion = objControlUnidadMedicion.Listar();

        }

        protected void BtnGuardar(object sender, CommandEventArgs e)
        {
            string Descripcion = txtDescripcion.Text;

            UnidadMedicion objUnidadMedicion = new UnidadMedicion(Descripcion);
            ControlUnidadMedicion objControlUnidadMedicion = new ControlUnidadMedicion(objUnidadMedicion);
            string msg = objControlUnidadMedicion.Guardar();
            Response.Redirect("FrmUnidadMedicion.aspx");

        }

        protected void BtnConsultar(object sender, CommandEventArgs e)
        {
            int id = Convert.ToInt32(txtId5.Text);

            UnidadMedicion objUnidadMedicion = new UnidadMedicion(id, "");
            ControlUnidadMedicion objControlUnidadMedicion = new ControlUnidadMedicion(objUnidadMedicion);
            objUnidadMedicion = objControlUnidadMedicion.Consultar();
            txtDescripcion.Text = objUnidadMedicion.Descripcion;
        }

        protected void BtnModificar(object sender, CommandEventArgs e)
        {
            int id = Convert.ToInt32(txtId5.Text);
            string nom = txtDescripcion.Text;
            UnidadMedicion objUnidadMedicion = new UnidadMedicion(id, nom);
            ControlUnidadMedicion objControlUnidadMedicion = new ControlUnidadMedicion(objUnidadMedicion);
            objControlUnidadMedicion.Modificar();


        }

        protected void BtnBorrar(object sender, CommandEventArgs e)
        {
            int id = Convert.ToInt32(txtId5.Text);
            UnidadMedicion objUnidadMedicion = new UnidadMedicion(id, "");
            ControlUnidadMedicion objControlUnidadMedicion = new ControlUnidadMedicion(objUnidadMedicion);
            objControlUnidadMedicion.Borrar();

        }
    }
}