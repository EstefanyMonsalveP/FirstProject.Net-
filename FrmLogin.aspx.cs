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
    public partial class FrmLogin : System.Web.UI.Page
    {
        protected Rol[] listaRolesDelUsuario = null;
        protected void Page_Load(object sender, EventArgs e)
        {


        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            string msg = "ok";
            bool validar = false;
            try
            {
                string email = txtEmail.Text;
                string contrasena = txtContrasena.Text;
                Usuario objUsuario = new Usuario(email, contrasena);
                ControlUsuario objControlUsuario = new ControlUsuario(objUsuario);
                validar = objControlUsuario.ValidarIngreso();
                if (validar)
                {
                    Session["email"] = email;
                    ControlRolUsuario objControlRolUsuario = new ControlRolUsuario(null);
                    listaRolesDelUsuario = objControlRolUsuario.buscarIdNombrePorEmail(email);
                    Session["listaRolesDelUsuario"] = listaRolesDelUsuario;
                    Response.Redirect("FrmMenu.aspx");
                }
                else
                {
                    Response.Write("<h3>Usuario ó Contraseña no es válido</h3>");
                }
            }
            catch (Exception objException)
            {
                msg = objException.Message;
            }
        }
    }
}