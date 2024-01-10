using primeraEntrega.Controllers;
using primeraEntrega.Models;
using System;
using System.Web.UI.WebControls;


namespace primeraEntrega
{
    public partial class FrmLiteral : System.Web.UI.Page
    {
        protected Models.Literal[] arregloLiteral = null;
        protected void Page_Load(object sender, EventArgs e)
        { 
           ControlLiteral objControlliteral = new ControlLiteral(null);
           arregloLiteral = objControlliteral.Listar();
        }
    }
}