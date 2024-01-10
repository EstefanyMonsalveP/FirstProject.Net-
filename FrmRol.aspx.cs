using primeraEntrega.Controllers;
using primeraEntrega.Models;
using System;
using System.Web.UI.WebControls;

namespace primeraEntrega
{
    public partial class FrmRol : System.Web.UI.Page
    {
        protected Rol[] arregloRoles = null;
        protected Rol[] listaRolesDelUsuario = null;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["email"] == null) Response.Redirect("FrmLogin.aspx");
            bool tienePermiso = false;
            listaRolesDelUsuario = (Rol[])Session["listaRolesDelUsuario"]; //cast
            //controlar listaRolesDelUsuario nulos
            for (int i = 0; i < listaRolesDelUsuario.Length; i++)
            {
                if (listaRolesDelUsuario[i].Nombre == "admin" || listaRolesDelUsuario[i].Nombre == "verificador") tienePermiso = true;
            }
            if (!tienePermiso) Response.Redirect("FrmMenu.aspx");

            ControlRol objControlRol = new ControlRol(null);
            arregloRoles = objControlRol.Listar();

        }

        protected void BtnGuardar(object sender, CommandEventArgs e)
        {
            string nom = txtNombre.Text;
            Rol objRol = new Rol(0, nom);
            ControlRol objControlRol = new ControlRol(objRol);
            string msg = objControlRol.Guardar();

            Response.Redirect("FrmRol.aspx");

        }

        protected void BtnConsultar(object sender, CommandEventArgs e)
        {
            int id = Convert.ToInt32(txtId.Text);
            string nom = txtNombre.Text;
            Rol objRol = new Rol(id, nom);
            ControlRol objControlRol = new ControlRol(objRol);
            objRol = objControlRol.Consultar();
            txtNombre.Text = objRol.Nombre;

        }

        protected void BtnModificar(object sender, CommandEventArgs e)
        {
            int id = Convert.ToInt32(txtId.Text);
            string nom = txtNombre.Text;
            Rol objRol = new Rol(id, nom);
            ControlRol objControlRol = new ControlRol(objRol);
            objControlRol.Modificar();
            Response.Redirect("FrmRol.aspx");
        }

        protected void BtnBorrar(object sender, CommandEventArgs e)
        {
            int id = Convert.ToInt32(txtId.Text);
            Rol objRol = new Rol(id, "");
            ControlRol objControlRol = new ControlRol(objRol);
            objControlRol.Borrar();
            Response.Redirect("FrmRol.aspx");
        }
    }
}