using primeraEntrega.Controllers;
using primeraEntrega.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Configuration;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace primeraEntrega
{
    public partial class FrmUsuario : System.Web.UI.Page
    {
        protected Usuario[] arregloUsuarios = null;
        protected Rol[] arregloRoles = null;
        protected Rol[] arregloRolesDelUsuario = null;
        protected Rol[] listaRolesDelUsuario = null;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["email"] == null) Response.Redirect("FrmLogin.aspx");
            bool tienePermiso = false;
            listaRolesDelUsuario = (Rol[])Session["listaRolesDelUsuario"]; //cast
            //controlar listaRolesDelUsuario nulos
            for (int i = 0; i < listaRolesDelUsuario.Length; i++)
            {
                if (listaRolesDelUsuario[i].Nombre == "admin") tienePermiso = true;
            }
            if (!tienePermiso) Response.Redirect("FrmMenu.aspx");

            ControlUsuario objControlUsuario = new ControlUsuario(null);
            arregloUsuarios = objControlUsuario.Listar();
            if (!IsPostBack) //Si es la primera vez que carga la página
            {
                ControlRol objControlRol = new ControlRol(null);
                arregloRoles = objControlRol.Listar();
                for (int i = 0; i < arregloRoles.Length; i++)
                {
                    comboRoles.Items.Add(arregloRoles[i].Id.ToString() + ";" + arregloRoles[i].Nombre);
                }
            }

        }

        protected void BtnGuardar(object sender, CommandEventArgs e)
        {
            try
            {
                string ema = txtEmail.Text;
                string con = txtContrasena.Text;
                Usuario objUsuario = new Usuario(ema, con);
                ControlUsuario objControlUsuario = new ControlUsuario(objUsuario);
                string msg = objControlUsuario.Guardar();
                

                for (int i = 0; i < listRolesUsuario.Items.Count; i++)
                {
                    string[] idYNombre = listRolesUsuario.Items[i].Value.Split(';');
                    int id = Convert.ToInt32(idYNombre[0]);
                    RolUsuario objRolUsuario = new RolUsuario(ema, id);
                    ControlRolUsuario objControlRolUsuario = new ControlRolUsuario(objRolUsuario);
                    objControlRolUsuario.guardar();
                }

            }
            catch (Exception objException)
            {
                Session["MensajeError"] = $"Error al guardar: {objException.Message}"; 
            }
            Response.Redirect("FrmUsuario.aspx");

        }

        protected void BtnConsultar(object sender, CommandEventArgs e)
        {
            try
            {
                string ema = txtEmail.Text;
                Usuario objUsuario = new Usuario(ema, "");
                ControlUsuario objControlUsuario = new ControlUsuario(objUsuario);
                objUsuario = objControlUsuario.consultar();
                txtContrasena.Text = objUsuario.Contrasena;
                ControlRolUsuario objControlRolUsuario = new ControlRolUsuario(null);
                arregloRolesDelUsuario = objControlRolUsuario.buscarIdNombrePorEmail(ema);
                listRolesUsuario.Items.Clear();
                if (arregloRolesDelUsuario != null)
                {
                    for (int i = 0; i < arregloRolesDelUsuario.Length; i++)
                    {
                        listRolesUsuario.Items.Add(arregloRolesDelUsuario[i].Id + ";" + arregloRolesDelUsuario[i].Nombre);
                    }
                }

            }
            catch (Exception objException)
            {

                Session["MensajeError"] = $"Error al guardar: {objException.Message}"; ;
            }
            
        }

        protected void BtnModificar(object sender, CommandEventArgs e)
        {
            try
            {
                string ema = txtEmail.Text;
                string con = txtContrasena.Text;
                Usuario objUsuario = new Usuario(ema, con);
                ControlUsuario objControlUsuario = new ControlUsuario(objUsuario);
                string msg = objControlUsuario.Modificar();

                //2. borrar en la tabla rol_usuario Tabla Intermedia
                ControlRolUsuario objControlRolUsuario = new ControlRolUsuario(null);
                objControlRolUsuario.borrarRolesDelUsuario(ema);

                //3. Guardar en la tabla rol_usuario
                for (int i = 0; i < listRolesUsuario.Items.Count; i++)
                {
                    string[] idYNombre = listRolesUsuario.Items[i].Value.Split(';');
                    int id = Convert.ToInt32(idYNombre[0]);
                    RolUsuario objRolUsuario = new RolUsuario(ema, id);
                    objControlRolUsuario = new ControlRolUsuario(objRolUsuario);
                    objControlRolUsuario.guardar();
                }
                Response.Redirect("FrmUsuario.aspx");

            }
            catch (Exception objException)
            {

                Session["MensajeError"] = $"Error al guardar: {objException.Message}"; ;
            }

        }

        protected void BtnBorrar(object sender, CommandEventArgs e)
        {
            try
            {
                string ema = txtEmail.Text;
                Usuario objUsuario = new Usuario(ema, "");
                ControlUsuario objControlUsuario = new ControlUsuario(objUsuario);
                string msg = objControlUsuario.Borrar();
                Response.Redirect("FrmUsuario.aspx");

            }
            catch (Exception objException)
            {

                Session["MensajeError"] = $"Error al guardar: {objException.Message}"; ;
            }

        }

        protected void btnAgregarRol(object sender, EventArgs e)
        {
            listRolesUsuario.Items.Add(comboRoles.Text);
            comboRoles.Items.Remove(comboRoles.Text);

        }

        protected void btnRemoverRol(object sender, EventArgs e)
        {
            listRolesUsuario.Items.Remove(listRolesUsuario.Text);
        }
    }
}