using primeraEntrega.Controllers;
using primeraEntrega.Models;
using System;
using System.Web.UI.WebControls;

namespace primeraEntrega
{
    public partial class FrmActor : System.Web.UI.Page
    {
        protected Actor[] arregloActor = null;
        protected TipoActor[] arregloTipoActor= null;
        protected void Page_Load(object sender, EventArgs e)
        {
            ControlActor objControlActor = new ControlActor(null);
            arregloActor = objControlActor.Listar();

            ControlTipoActor objControlTipoActor = new ControlTipoActor(null);
            arregloTipoActor = objControlTipoActor.Listar();

            for (int i = 0; i < arregloTipoActor.Length; i++)
            {
                ddlTipoActor.Items.Add(arregloTipoActor[i].Id.ToString() + ":" + arregloTipoActor[i].Nombre);
            }

            foreach (TipoActor tipoActor in arregloTipoActor)
            {
                ListItem objList = new ListItem();
                objList.Value = tipoActor.Id.ToString();
                objList.Text = tipoActor.Id.ToString() + ":" + tipoActor.Nombre;

                ddlTipoActor.Items.Add(objList);
            }
        }

        protected void BtnGuardar(object sender, CommandEventArgs e)
        {
            string id = txtId.Text;
            string nombre = txtNombre.Text;
            string[] tipoActor = ddlTipoActor.SelectedValue.Split(':');
            int idTipoActor = Convert.ToInt32(tipoActor[0]);

            Actor objActor = new Actor(id, nombre, idTipoActor);
            ControlActor objControlActor = new ControlActor(objActor);
            objControlActor.Guardar();

            Response.Redirect("FrmActor.aspx");

        }

        protected void BtnConsultar(object sender, CommandEventArgs e)
        {
            string id = txtId.Text;

            Actor objActor = new Actor(id) ;
            ControlActor objControlActor = new ControlActor(objActor);
            objActor = objControlActor.Consultar();
            txtNombre.Text = objActor.Nombre;
            ddlTipoActor.SelectedValue = objActor.FkIdTipoActor.ToString();
        }

        protected void BtnModificar(object sender, CommandEventArgs e)
        {
            string id = txtId.Text;
            string nombre = txtNombre.Text;
            string[] tipoActor = ddlTipoActor.SelectedValue.Split(':');
            int idTipoActor = Convert.ToInt32(tipoActor[0]);

            Actor objActor = new Actor(id, nombre, idTipoActor);
            ControlActor objControlActor = new ControlActor(objActor);
            objControlActor.Modificar();

            Response.Redirect("FrmActor.aspx");
        }

        protected void BtnBorrar(object sender, CommandEventArgs e)
        {
            string id = txtId.Text;

            Actor objActor = new Actor(id);
            ControlActor objControlActor = new ControlActor(objActor);
            objControlActor.Borrar();

            Response.Redirect("FrmActor.aspx");
        }
    }
}