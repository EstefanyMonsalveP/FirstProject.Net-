using primeraEntrega.Controllers;
using primeraEntrega.Models;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.Http.Routing.Constraints;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace primeraEntrega
{
    public partial class FrmResultadoIndicador : System.Web.UI.Page
    {
        protected ResultadoIndicador[] arregloResultadoIndicador = null;
        protected Indicador[] arregloIndicador = null;
        protected void Page_Load(object sender, EventArgs e)
        {
            ControlResultadoIndicador objControlResultadoIndicador = new ControlResultadoIndicador(null);
            arregloResultadoIndicador = objControlResultadoIndicador.Listar();

            ControlIndicador objControlIndicador = new ControlIndicador(null);
            arregloIndicador = objControlIndicador.Listar();

            if (! IsPostBack)
            {
                for (int i = 0; i < arregloIndicador.Length; i++)
                {
                    ddlIdIndicador.Items.Add(arregloIndicador[i].Id.ToString() + ":" + arregloIndicador[i].Nombre);
                }

                DateTime Fecha = DateTime.Now;
                string formatoFecha = Fecha.ToString("yyyy-MM-dd HH:mm:ss");
                txtFechaCalculo.Text = formatoFecha;

                ddlIdIndicador.Items.Clear();

                foreach (Indicador resultadoIndicador in arregloIndicador)
                {
                    ListItem listItem = new ListItem();
                    listItem.Value = resultadoIndicador.Id.ToString();
                    listItem.Text = resultadoIndicador.Id.ToString() + ":" + resultadoIndicador.Nombre;

                    ddlIdIndicador.Items.Add(listItem);
                }

            }
            
        }

        protected void BtnGuardar(object sender, CommandEventArgs e)
        {
            double resultado = Convert.ToDouble(txtResultado.Text);
            DateTime fecha = Convert.ToDateTime(txtFechaCalculo.Text);
            string fechaCalculo = fecha.ToString("yyyy-MM-dd HH:mm:ss");
            string[] idIndicador = ddlIdIndicador.SelectedValue.Split(':');
            int fkIdIndicador = Convert.ToInt32(idIndicador[0]);
            ResultadoIndicador objResultadoIndicador = new ResultadoIndicador(0,resultado,fechaCalculo,fkIdIndicador);
            ControlResultadoIndicador objControlResultadoIndicador = new ControlResultadoIndicador(objResultadoIndicador);
            objControlResultadoIndicador.Guardar();

            Response.Redirect("FrmResultadoIndicador.aspx");

        }

        protected void BtnConsultar(object sender, CommandEventArgs e)
        {
            int id = Convert.ToInt32(txtId5.Text);
            ResultadoIndicador objResultadoIndicador = new ResultadoIndicador(id);
            ControlResultadoIndicador objControlResultadoIndicador = new ControlResultadoIndicador(objResultadoIndicador);
            objControlResultadoIndicador.Consultar();

            txtResultado.Text = objResultadoIndicador.Resultado.ToString();
            txtFechaCalculo.Text = objResultadoIndicador.FechaCalculo;
            ddlIdIndicador.SelectedValue = objResultadoIndicador.FkIdIndicador.ToString();
        }

        protected void BtnModificar(object sender, CommandEventArgs e)
        {
            int id = Convert.ToInt32(txtId5.Text);
            double resultado = Convert.ToDouble(txtResultado.Text);
            DateTime fecha = Convert.ToDateTime(txtFechaCalculo.Text);
            string fechaCalculo = fecha.ToString("yyyy-MM-dd HH:mm:ss");
            string[] idIndicador = ddlIdIndicador.SelectedValue.Split(':');
            int fkIdIndicador = Convert.ToInt32(idIndicador[0]);
            ResultadoIndicador objResultadoIndicador = new ResultadoIndicador(id, resultado, fechaCalculo, fkIdIndicador);
            ControlResultadoIndicador objControlResultadoIndicador = new ControlResultadoIndicador(objResultadoIndicador);
            objControlResultadoIndicador.Modificar();
            Response.Redirect("FrmResultadoIndicador.aspx");

        }

        protected void BtnBorrar(object sender, CommandEventArgs e)
        {
            int id = Convert.ToInt32(txtId5.Text);
            ResultadoIndicador objResultadoIndicador = new ResultadoIndicador(id);
            ControlResultadoIndicador objControlResultadoIndicador = new ControlResultadoIndicador(objResultadoIndicador);
            objControlResultadoIndicador.Borrar();
            Response.Redirect("FrmResultadoIndicador.aspx");
        }
    }
}