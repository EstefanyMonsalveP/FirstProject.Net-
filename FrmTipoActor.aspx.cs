using primeraEntrega.Controllers;
using primeraEntrega.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization.Formatters;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace primeraEntrega
{
    public partial class FrmTipoActor : System.Web.UI.Page
    {
        protected TipoActor[] arregloTipoActor = null;
        protected void Page_Load(object sender, EventArgs e)
        {
            ControlTipoActor objControlTipoActor = new ControlTipoActor(null);
            arregloTipoActor = objControlTipoActor.Listar();
             
        }

        protected void BtnGuardar(object sender, CommandEventArgs e)
        {
            
            string nom = txtNombre4.Text;
            TipoActor objTipoActor = new TipoActor( nom);
            ControlTipoActor objControTipolActor = new ControlTipoActor(objTipoActor);
            objControTipolActor.Guardar();
                
            
            Response.Redirect("FrmTipoActor.aspx");
        }
                

        protected void BtnConsultar(object sender, CommandEventArgs e)
        {
            int id = Convert.ToInt32(txtId4.Text);
            TipoActor objTipoActor = new TipoActor(id);
            ControlTipoActor objControTipolActor = new ControlTipoActor(objTipoActor);
            objTipoActor = objControTipolActor.Consultar();
            txtNombre4.Text = objTipoActor.Nombre;
        }

        protected void BtnModificar(object sender, CommandEventArgs e)
        {
            int id = Convert.ToInt32(txtId4.Text);
            string nom = txtNombre4.Text;
            TipoActor objTipoActor = new TipoActor(id, nom);
            ControlTipoActor objControTipolActor = new ControlTipoActor(objTipoActor);
            objControTipolActor.Modificar();

            Response.Redirect("FrmTipoActor.aspx");
        }

        protected void BtnBorrar(object sender, CommandEventArgs e)
        { 
                int id = Convert.ToInt32(txtId4.Text);
                TipoActor objTipoActor = new TipoActor(id, "");
                ControlTipoActor objControlTipoActor = new ControlTipoActor(objTipoActor);
                objControlTipoActor.Borrar();
                
            Response.Redirect("FrmTipoActor.aspx");
        }  
    }
}