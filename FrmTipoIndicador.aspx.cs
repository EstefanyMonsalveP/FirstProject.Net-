using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using primeraEntrega.Controllers;
using primeraEntrega.Models;

namespace primeraEntrega
{
    public partial class FrmTipoIndicador : System.Web.UI.Page
    {
        protected TipoIndicador[] arregloTipoIndicador = null;

        protected void Page_Load(object sender, EventArgs e)
        {
            ControlTipoIndicador objControlTipoIndicador = new ControlTipoIndicador(null);
            arregloTipoIndicador = objControlTipoIndicador.Listar();


        }

        protected void BtnGuardar(object sender, CommandEventArgs e)
        {

                 string nombre = txtNombre.Text;
 
                TipoIndicador objTipoIndicador = new TipoIndicador(nombre);
                ControlTipoIndicador objControlTipoIndicador = new ControlTipoIndicador(objTipoIndicador);
                string msg = objControlTipoIndicador.Guardar();
                Response.Redirect("FrmTipoIndicador.aspx");
        }

        protected void BtnConsultar(object sender, CommandEventArgs e)
        {
            int id = Convert.ToInt32(txtId.Text);

            TipoIndicador objTipoIndicador = new TipoIndicador(id, "");
            ControlTipoIndicador objControlTipoIndicador = new ControlTipoIndicador(objTipoIndicador);
            objTipoIndicador =objControlTipoIndicador.Consultar();
            txtNombre.Text = objTipoIndicador.Nombre;

        }

        protected void BtnBorrar(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(txtId.Text);

            TipoIndicador objTipoIndicador = new TipoIndicador(id, "");
            ControlTipoIndicador objControlTipoIndicador = new ControlTipoIndicador(objTipoIndicador);
            objControlTipoIndicador.Borrar();


        }

        protected void BtnModificar(object sender, CommandEventArgs e)
        {
            int id = Convert.ToInt32(txtId.Text);
            string nombre = txtNombre.Text;

            TipoIndicador objTipoIndicador = new TipoIndicador(id, nombre);
            ControlTipoIndicador objControlTipoIndicador = new ControlTipoIndicador(objTipoIndicador);
            objControlTipoIndicador.Modificar();

        }
    }
}