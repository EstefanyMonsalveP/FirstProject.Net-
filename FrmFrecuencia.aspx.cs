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
    public partial class FrmFrecuencia : System.Web.UI.Page
    {
        protected Frecuencia[] arregloFrecuencia = null;
        protected void Page_Load(object sender, EventArgs e)
        {
            ControlFrecuencia objControlFrecuencia = new ControlFrecuencia(null);
            arregloFrecuencia = objControlFrecuencia.Listar();

        }
        protected void BtnGuardar(object sender, CommandEventArgs e)
        {
            int id = Convert.ToInt32(txtId5.Text);
            string Descripcion = txtDescripcion.Text;

            Frecuencia objFrecuencia = new Frecuencia(id,Descripcion);
            ControlFrecuencia objControlFrecuencia = new ControlFrecuencia(objFrecuencia);
            string msg = objControlFrecuencia.Guardar();
            Response.Redirect("FrmFrecuencia.aspx");

        }

        protected void BtnConsultar(object sender, CommandEventArgs e)
        {
            int id = Convert.ToInt32(txtId5.Text);

            Frecuencia objFrecuencia = new Frecuencia(id, "");
            ControlFrecuencia objControlFrecuencia = new ControlFrecuencia(objFrecuencia);
            objFrecuencia = objControlFrecuencia.Consultar();
            txtDescripcion.Text = objFrecuencia.Descripcion;
        }

        protected void BtnModificar(object sender, CommandEventArgs e)
        {
            int id = Convert.ToInt32(txtId5.Text);
            string nom = txtDescripcion.Text;
            Frecuencia objFrecuencia = new Frecuencia(id, nom);
            ControlFrecuencia objControlFrecuencia = new ControlFrecuencia(objFrecuencia);
            objControlFrecuencia.Modificar();
            Response.Redirect("FrmFrecuencia.aspx");


        }

        protected void BtnBorrar(object sender, CommandEventArgs e)
        {
            int id = Convert.ToInt32(txtId5.Text);
            Frecuencia objFrecuencia = new Frecuencia(id, "");
            ControlFrecuencia objControlFrecuencia = new ControlFrecuencia(objFrecuencia);
            objControlFrecuencia.Borrar();
            Response.Redirect("FrmFrecuencia.aspx");

        }

    }
}