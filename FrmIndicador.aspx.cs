using Microsoft.Ajax.Utilities;
using primeraEntrega.Controllers;
using primeraEntrega.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web.Http.ModelBinding.Binders;
using System.Web.UI.WebControls;

namespace primeraEntrega
{
    public partial class FrmIndicador : System.Web.UI.Page
    {
        protected Indicador[] arregloIndicador = null;
        protected Fuente[] arregloFuente = null;
        protected TipoIndicador[] arregloTipoindicador = null;
        protected UnidadMedicion[] arregloUnidadMedicion = null;
        protected Fuente[] arregloFuentesIndicador = null;
        protected Sentido[] arregloSentido = null;
        protected Frecuencia[] arregloFrecuencia = null;
        protected Articulo[] arregloArticulo = null;
        protected Models.Literal[] arregloLiteral = null;
        protected Numeral[] arregloNumeral = null;
        protected Paragrafo[] arregloParagrafo = null;
        protected Actor[] arregloActores = null;
        protected Actor[] arregloResponsablesIndicador = null;
        protected DateTime fechaSeleccionada;
        protected RepresenVisual[] arregloRepresenVisual = null;
        protected RepresenVisual[] arregloRepresenVisualindicador = null;
        protected Variable[] arregloVariable = null;
        protected VariablesPorIndicador[] arregloVariableIndicador = null;
        protected Usuario[] arregloUsuario = null;
        protected Rol[] listaRolesDelUsuario = null;
        protected void Page_Load(object sender, EventArgs e)
        {
            ControlIndicador objControlIndicador = new ControlIndicador(null);
            arregloIndicador = objControlIndicador.Listar();

            if (Session["email"] == null) Response.Redirect("FrmLogin.aspx");
            bool tienePermiso = false;
            listaRolesDelUsuario = (Rol[])Session["listaRolesDelUsuario"]; //cast
            //controlar listaRolesDelUsuario nulos
            for (int i = 0; i < listaRolesDelUsuario.Length; i++)
            {
                if (listaRolesDelUsuario[i].Nombre == "admin" || listaRolesDelUsuario[i].Nombre == "administrativo" || listaRolesDelUsuario[i].Nombre == "validador" || listaRolesDelUsuario[i].Nombre == "verificador") tienePermiso = true;
            }
            if (!tienePermiso) Response.Redirect("FrmMenu.aspx");

            if (!IsPostBack) //Si es la primera vez que carga la página
            {
               
                
                ControlRepresenVisual objControlRepresenVisual = new ControlRepresenVisual(null);
                arregloRepresenVisual = objControlRepresenVisual.Listar();
                for (int i = 0; i < arregloRepresenVisual.Length; i++)
                {
                    ddlRepresenVisualindicador.Items.Add(arregloRepresenVisual[i].Id.ToString() + ":" + arregloRepresenVisual[i].Nombre);
                }

                ControlFuente objControlFuente = new ControlFuente(null);
                arregloFuente = objControlFuente.Listar();
                for (int i = 0; i < arregloFuente.Length; i++)
                {
                    ddlFuentes.Items.Add(arregloFuente[i].Id.ToString() + ":" + arregloFuente[i].Nombre);
                }

                
                ControlTipoIndicador objControlTipoIndicador = new ControlTipoIndicador(null);
                arregloTipoindicador = objControlTipoIndicador.Listar();
                ddlIdIndicador.SelectedIndex = -1;

                for (int i=0; i< arregloTipoindicador.Length;i++)
                {
                    ddlIdIndicador.Items.Add(arregloTipoindicador[i].Id.ToString() + ":" + arregloTipoindicador
                        [i].Nombre);
                }
                
                ControlUnidadMedicion objControlUnidadMedicion = new ControlUnidadMedicion(null);
                arregloUnidadMedicion = objControlUnidadMedicion.Listar();
                for (int i = 0; i < arregloUnidadMedicion.Length; i++)
                {
                    ddlIdUnidadM.Items.Add(arregloUnidadMedicion[i].Id.ToString() + ":" + arregloUnidadMedicion
                        [i].Descripcion);
                }

                ControlSentido objControlSentido = new ControlSentido(null);
                arregloSentido = objControlSentido.Listar();
                for (int i = 0; i < arregloSentido.Length; i++)
                {
                    ddlIdSentido.Items.Add(arregloSentido[i].Id.ToString() + ":" + arregloSentido
                        [i].Nombre);
                }

                ControlFrecuencia objControlFrecuencia = new ControlFrecuencia(null);
                arregloFrecuencia = objControlFrecuencia.Listar();
                for (int i = 0; i < arregloFrecuencia.Length; i++)
                {
                    ddlIdFrecuencia.Items.Add(arregloFrecuencia[i].Id.ToString() + ":" + arregloFrecuencia
                        [i].Descripcion);
                }

                ControlArticulo objControlArticulo = new ControlArticulo(null);
                arregloArticulo = objControlArticulo.Listar();
                for (int i = 0; i < arregloFrecuencia.Length; i++)
                {
                    ddlIdArticulo.Items.Add(arregloArticulo[i].Id.ToString() + ":" + arregloArticulo
                        [i].Nombre);
                }

                ControlLiteral objControlLiteral = new ControlLiteral(null);
                arregloLiteral = objControlLiteral.Listar();
                for (int i = 0; i < arregloLiteral.Length; i++)
                {
                    ddlIdLiteral.Items.Add(arregloLiteral[i].Id.ToString() + ":" + arregloLiteral
                        [i].Descripcion);
                }

                ControlNumeral objControlNumeral = new ControlNumeral(null);
                arregloNumeral = objControlNumeral.Listar();
                for (int i = 0; i < arregloNumeral.Length; i++)
                {
                    ddlIdNumeral.Items.Add(arregloNumeral[i].Id.ToString() + ":" + arregloNumeral
                        [i].Descripcion);
                }

                ControlParagrafo objControlParagrafo = new ControlParagrafo(null);
                arregloParagrafo = objControlParagrafo.Listar();
                for (int i = 0; i < arregloParagrafo.Length; i++)
                {
                    ddlIdParagrafo.Items.Add(arregloParagrafo[i].Id.ToString() + ":" + arregloParagrafo
                        [i].Descripcion);
                }

                ControlActor objControlActor = new ControlActor(null);
                arregloActores = objControlActor.Listar();
                for (int i = 0; i < arregloActores.Length; i++)
                {
                    ddlResponsables.Items.Add(arregloActores[i].Id.ToString() + ":" + arregloActores
                        [i].Nombre);
                }

                ControlUsuario objControlUsuario = new ControlUsuario(null);
                arregloUsuario = objControlUsuario.Listar();
                for (int i = 0; i < arregloUsuario.Length; i++)
                {
                    ddlEmail.Items.Add(arregloUsuario[i].Email);
                        
                }

                ddlIdIndicador.Items.Clear();
                    ddlIdUnidadM.Items.Clear();
                    ddlIdSentido.Items.Clear();
                    ddlIdFrecuencia.Items.Clear();
                    ddlIdArticulo.Items.Clear();
                    ddlIdLiteral.Items.Clear();
                    ddlIdNumeral.Items.Clear();
                    ddlIdParagrafo.Items.Clear();
                    ddlEmail.Items.Clear();

                foreach (TipoIndicador tipoIndicador in arregloTipoindicador)
                {
                    ListItem listItem = new ListItem();
                    listItem.Value = tipoIndicador.Id.ToString();
                    listItem.Text = tipoIndicador.Id + ":" + tipoIndicador.Nombre;

                    ddlIdIndicador.Items.Add(listItem);
                }

                foreach (UnidadMedicion tipoUnidadMedicion in arregloUnidadMedicion)
                {
                    ListItem listItem = new ListItem();
                    listItem.Value = tipoUnidadMedicion.Id.ToString();
                    listItem.Text = tipoUnidadMedicion.Id + ":" + tipoUnidadMedicion.Descripcion;

                    ddlIdUnidadM.Items.Add(listItem);
                }

                foreach (Sentido tipoSentido in arregloSentido)
                {
                    ListItem listItem = new ListItem();
                    listItem.Value = tipoSentido.Id.ToString();
                    listItem.Text = tipoSentido.Id + ":" + tipoSentido.Nombre;

                    ddlIdSentido.Items.Add(listItem);
                }

                foreach (Frecuencia tipoFrecuencia in arregloFrecuencia)
                {
                    ListItem listItem = new ListItem();
                    listItem.Value = tipoFrecuencia.Id.ToString();
                    listItem.Text = tipoFrecuencia.Id + ":" + tipoFrecuencia.Descripcion;

                    ddlIdFrecuencia.Items.Add(listItem);
                }

                foreach (Articulo tipoArticulo in arregloArticulo)
                {
                    ListItem listItem = new ListItem();
                    listItem.Value = tipoArticulo.Id.ToString();
                    listItem.Text = tipoArticulo.Id + ":" + tipoArticulo.Descripcion;

                    ddlIdArticulo.Items.Add(listItem);
                }

                foreach (Models.Literal tipoLiteral in arregloLiteral)
                {
                    ListItem listItem = new ListItem();
                    listItem.Value = tipoLiteral.Id.ToString();
                    listItem.Text = tipoLiteral.Id + ":" + tipoLiteral.Descripcion;

                    ddlIdLiteral.Items.Add(listItem);
                }

                foreach (Numeral tipoNumeral in arregloNumeral)
                {
                    ListItem listItem = new ListItem();
                    listItem.Value = tipoNumeral.Id.ToString();
                    listItem.Text = tipoNumeral.Id + ":" + tipoNumeral.Descripcion;

                    ddlIdNumeral.Items.Add(listItem);
                }

                foreach (Paragrafo tipoParagrafo in arregloParagrafo)
                {
                    ListItem listItem = new ListItem();
                    listItem.Value = tipoParagrafo.Id.ToString();
                    listItem.Text = tipoParagrafo.Id + ":" + tipoParagrafo.Descripcion;

                    ddlIdParagrafo.Items.Add(listItem);
                }

                DateTime fechaActual = DateTime.Now;
                string FechaFormato = fechaActual.ToString("yyyy-MM-dd HH:mm:ss");
                txtFechaAsignacion.Text = FechaFormato;
                txtFechaDato.Text = FechaFormato;

                ControlVariable objControlVariable = new ControlVariable(null);
                arregloVariable = objControlVariable.Listar();

                for (int i=0; i < arregloVariable.Length; i++)
                {
                    ddlVariables.Items.Add(arregloVariable[i].Id.ToString() + ":" + arregloVariable[i].Nombre);
                }


                foreach (Usuario email in arregloUsuario)
                {
                    ListItem listItem = new ListItem();
                    listItem.Value = email.Email;
                    listItem.Text = email.Email;

                    ddlEmail.Items.Add(listItem);
                }

            }
        }

        protected void BtnGuardar(object sender, CommandEventArgs e)
        {
            int fkIdIndicador = Convert.ToInt32(txtId1.Text);
            string codigo = txtCodigo.Text;
            string nombre = txtNombre.Text;
            string objetivo = txtObjetivo.Text;
            string alcance = txtAlcance.Text;
            string formula = txtFormula.Text;
            string meta = txtMeta.Text;

            string[] idIndicador = ddlIdIndicador.SelectedValue.Split(':');
            string[] idUnidadMedicion = ddlIdUnidadM.SelectedValue.Split(':');
            string[] idSentido = ddlIdSentido.SelectedValue.Split(':');
            string[] idFrecuencia = ddlIdFrecuencia.SelectedValue.Split(':');
            string[] idArticulo = ddlIdArticulo.SelectedValue.Split(':');
            string[] idLiteral = ddlIdLiteral.SelectedValue.Split(':');
            string[] idNumeral = ddlIdNumeral.SelectedValue.Split(':');
            string[] idParagrafo = ddlIdParagrafo.SelectedValue.Split(':');

            if (idIndicador.Length >= 1 && idUnidadMedicion.Length >= 1 && idSentido.Length >= 1 && idFrecuencia.Length >= 1 && idArticulo.Length >= 1 && idLiteral.Length >= 1 && idNumeral.Length >= 1 && idParagrafo.Length >= 1)
            {
                int fkIdTipoIndicador = Convert.ToInt32(idIndicador[0]);
                int fkIdUnidadMedicion = Convert.ToInt32(idUnidadMedicion[0]);
                int fkIdSentido = Convert.ToInt32(idSentido[0]);
                int fkIdFrecuencia = Convert.ToInt32(idFrecuencia[0]);
                string fkIdArticulo = idArticulo[0];
                string fkIdLiteral = idLiteral[0];
                string fkIdNumeral = idNumeral[0];
                string fkIdParagrafo = idParagrafo[0];

                Indicador objIndicador = new Indicador(fkIdIndicador, codigo, nombre, objetivo, alcance, formula, fkIdTipoIndicador, fkIdUnidadMedicion, meta, fkIdSentido, fkIdFrecuencia, fkIdArticulo, fkIdLiteral, fkIdNumeral, fkIdParagrafo);
                ControlIndicador objControlIndicador = new ControlIndicador(objIndicador);
                string msg = objControlIndicador.Guardar();
            }

            for (int i = 0; i < lbFuentes.Items.Count; i++)
            {
                //int fkIdIndicador = Convert.ToInt32(txtId1.Text);
                string[] idNombreFuentesIndicador = lbFuentes.Items[i].Text.Split(':');

                int fkIdFuente = Convert.ToInt32(idNombreFuentesIndicador[0]);
                FuentesPorIndicador objFuentesPorIndicador = new FuentesPorIndicador(fkIdFuente, fkIdIndicador);
                ControlFuentesPorIndicador objControlFuentesPorIndicador = new ControlFuentesPorIndicador(objFuentesPorIndicador);
                objControlFuentesPorIndicador.Guardar();

            }

            for (int i = 0; i < lbResponsables.Items.Count; i++)
            {
                string[] arregloActores = lbResponsables.Items[i].Text.Split(':');
                string fkIdResponsables = arregloActores[0];
                DateTime fechaIngresada = Convert.ToDateTime(txtFechaAsignacion.Text);
                string fechaFormateada = fechaIngresada.ToString("yyyy-MM-dd HH:mm:ss");
                

                // La fecha ingresada cumple con el formato esperado y se almacena en 'fechaSeleccionada'
                ResponsableIndicador objResponsableIndicador = new ResponsableIndicador(fkIdResponsables, fkIdIndicador, fechaFormateada);
                ControlResponsableIndicador objControlResponsableIndicador = new ControlResponsableIndicador(objResponsableIndicador);
                objControlResponsableIndicador.Guardar();
                        
            }

            for (int i = 0; i < lbRepresenVisualIndicador.Items.Count; i++)
            {

                //int fkIdIndicador = Convert.ToInt32(txtId1.Text);
                string[] idNombreRepresenVisual = lbRepresenVisualIndicador.Items[i].Text.Split(':');
                int fkIdRepresenVisual = Convert.ToInt32(idNombreRepresenVisual[0]);
                RepresenVisualIndicador objRepresenVisualIndicador = new RepresenVisualIndicador(fkIdIndicador, fkIdRepresenVisual);
                ControlRepresenVisualIndicador objControlRepresenVisualIndicador = new ControlRepresenVisualIndicador(objRepresenVisualIndicador);
                objControlRepresenVisualIndicador.Guardar();

            }



            for (int i = 0; i < lbVariablesIndicador.Items.Count; i++)
            { 
                string[] idNombreVariables = lbVariablesIndicador.Items[i].Text.Split(':');
                string[] guardarVariables = lbVariablesIndicador.Items[i].Text.Split(';');
                int fkIdVariable = Convert.ToInt32(idNombreVariables[0]);
                float dato = Convert.ToSingle(guardarVariables[1]);
                string fkEmailUsuario = guardarVariables[2];
                DateTime fecha = Convert.ToDateTime(guardarVariables[3]);
                string fechaDato = fecha.ToString("yyyy-MM-dd HH:mm:ss");
                VariablesPorIndicador objVariablesPorIndicador = new VariablesPorIndicador(0, fkIdVariable,fkIdIndicador,dato,fkEmailUsuario,fechaDato );
                ControlVariablesIndicador objControlVariablesPorIndicador = new ControlVariablesIndicador(objVariablesPorIndicador);
                objControlVariablesPorIndicador.Guardar();
            }

            Response.Redirect("FrmIndicador.aspx");
        }

        protected void BtnConsultar(object sender, CommandEventArgs e)
        {
            int id = Convert.ToInt32(txtId1.Text);

            Indicador objIndicador = new Indicador(id);
            ControlIndicador objControlIndicador = new ControlIndicador(objIndicador);
            objControlIndicador.Consultar();

            txtId1.Text = Convert.ToString(objIndicador.Id);
            txtCodigo.Text = objIndicador.Codigo;
            txtNombre.Text = objIndicador.Nombre;
            txtObjetivo.Text = objIndicador.Objetivo;
            txtAlcance.Text = objIndicador.Alcance;
            txtFormula.Text = objIndicador.Formula;
            txtMeta.Text = objIndicador.Meta;

            if (objIndicador.FkIdTipoIndicador != 0)
            {
                ddlIdIndicador.SelectedValue = objIndicador.FkIdTipoIndicador.ToString();
            }

            if (objIndicador.FkIdUnidadMedicion != 0)
            {
                ddlIdUnidadM.SelectedValue = objIndicador.FkIdUnidadMedicion.ToString();
            }

            if (objIndicador.FkIdSentido != 0)
            {
                ddlIdSentido.SelectedValue = objIndicador.FkIdSentido.ToString();
            }

            if (objIndicador.FkIdFrecuencia != 0)
            {
                ddlIdFrecuencia.SelectedValue = objIndicador.FkIdFrecuencia.ToString();
            }

            if (objIndicador.FkIdArticulo != null)
            {
                ddlIdArticulo.SelectedValue = objIndicador.FkIdArticulo;
            }

            if (objIndicador.FkIdLiteral != null)
            {
                ddlIdLiteral.SelectedValue = objIndicador.FkIdLiteral;
            }

            if (objIndicador.FkIdNumeral != null)
            {
                ddlIdNumeral.SelectedValue = objIndicador.FkIdNumeral;
            }

            if (objIndicador.FkIdParagrafo != null)
            {
                ddlIdParagrafo.SelectedValue = objIndicador.FkIdParagrafo;
            }

            ControlFuentesPorIndicador objControlFuentesPorIndicador = new ControlFuentesPorIndicador(null);
            arregloFuentesIndicador = objControlFuentesPorIndicador.Consultar(id);
            lbFuentes.Items.Clear();
            if (arregloFuentesIndicador != null)
            {
                for (int i = 0; i < arregloFuentesIndicador.Length; i++)
                {
                    lbFuentes.Items.Add(arregloFuentesIndicador[i].Id + ":" + arregloFuentesIndicador[i].Nombre);
                }
            }

            ControlRepresenVisualIndicador objControlRepresenVisualIndicador = new ControlRepresenVisualIndicador(null);
            arregloRepresenVisualindicador = objControlRepresenVisualIndicador.Consultar(id);
            lbRepresenVisualIndicador.Items.Clear();

            if (arregloRepresenVisualindicador != null)
            {
                for (int i = 0; i < arregloRepresenVisualindicador.Length; i++)
                {
                    lbRepresenVisualIndicador.Items.Add(arregloRepresenVisualindicador[i].Id + ":" + arregloRepresenVisualindicador[i].Nombre);
                }

            }

            ControlResponsableIndicador objControlResponsableIndicador = new ControlResponsableIndicador(null);
            arregloResponsablesIndicador = objControlResponsableIndicador.Consultar(id);
            lbResponsables.Items.Clear();

            if (arregloResponsablesIndicador != null)
            {
                for (int i = 0; i < arregloResponsablesIndicador.Length; i++)
                {
                    lbResponsables.Items.Add(arregloResponsablesIndicador[i].Id + ":" + arregloResponsablesIndicador[i].Nombre);
                }
            }

            ControlVariablesIndicador objControlVariablesIndicador = new ControlVariablesIndicador(null);
            arregloVariable = objControlVariablesIndicador.ConsultarVariable(id);
            arregloVariableIndicador = objControlVariablesIndicador.ConsultarVariablesIndicador(id);

                if (arregloVariable != null && arregloVariableIndicador != null)
                {
                    int length = Math.Min(arregloVariable.Length, arregloVariableIndicador.Length);

                    for (int i = 0; i < length; i++)
                    {
                        lbVariablesIndicador.Items.Add(arregloVariable[i].Id.ToString() + ":" + arregloVariable[i].Nombre + ";"  + arregloVariableIndicador[i].Dato + ";"+ arregloVariableIndicador[i].FkEmailUsuario + " ; " + arregloVariableIndicador[i].FechaDato);

                    }
                    
                }
        }
        protected void BtnModificar(object sender, CommandEventArgs e)
        {
            int id = Convert.ToInt32(txtId1.Text);
            
            string codigo = txtCodigo.Text;
            string nombre = txtNombre.Text;
            string objetivo = txtObjetivo.Text;
            string alcance = txtAlcance.Text;
            string formula = txtFormula.Text;
            string meta = txtMeta.Text;
            string[] idIndicador = ddlIdIndicador.SelectedValue.Split(':');
            string[] idUnidadMedicion = ddlIdUnidadM.SelectedValue.Split(':');
            string[] idSentido = ddlIdSentido.SelectedValue.Split(':');
            string[] idFrecuencia = ddlIdFrecuencia.SelectedValue.Split(':');
            string[] idArticulo = ddlIdArticulo.SelectedValue.Split(':');
            string[] idLiteral = ddlIdLiteral.SelectedValue.Split(':');
            string[] idNumeral = ddlIdNumeral.SelectedValue.Split(':');
            string[] idParagrafo = ddlIdParagrafo.SelectedValue.Split(':');      
            int fkIdTipoIndicador = Convert.ToInt32(idIndicador[0]);
            int fkIdUnidadMedicion = Convert.ToInt32(idUnidadMedicion[0]);
            int fkIdSentido = Convert.ToInt32(idSentido[0]);
            int fkIdFrecuencia = Convert.ToInt32(idFrecuencia[0]);
            string fkIdArticulo = idArticulo[0];
            string fkIdLiteral = idLiteral[0];
            string fkIdNumeral = idNumeral[0];
            string fkIdParagrafo = idParagrafo[0];
            if (!string.IsNullOrWhiteSpace(codigo) || !string.IsNullOrWhiteSpace(nombre) || !string.IsNullOrWhiteSpace(objetivo) || !string.IsNullOrWhiteSpace(alcance) || !string.IsNullOrWhiteSpace(formula))
            {
                Indicador objIndicador = new Indicador(id, codigo, nombre, objetivo, alcance, formula, fkIdTipoIndicador, fkIdUnidadMedicion, meta, fkIdSentido, fkIdFrecuencia, fkIdArticulo, fkIdLiteral, fkIdNumeral, fkIdParagrafo);
                ControlIndicador objControlIndicador = new ControlIndicador(objIndicador);
                string mensaje = objControlIndicador.Modificar();
            }

            ControlFuentesPorIndicador objControlFuentesPorIndicador = new ControlFuentesPorIndicador(null);
            objControlFuentesPorIndicador.borrarFuentesIndicador(id);

            for (int i = 0; i < lbFuentes.Items.Count; i++)
            {
                //int fkIdIndicador = Convert.ToInt32(txtId1.Text);
                string[] idNombreFuentesIndicador = lbFuentes.Items[i].Text.Split(':');

                int fkIdFuente = Convert.ToInt32(idNombreFuentesIndicador[0]);
                FuentesPorIndicador objFuentesPorIndicador = new FuentesPorIndicador(fkIdFuente, id);
                objControlFuentesPorIndicador = new ControlFuentesPorIndicador(objFuentesPorIndicador);
                objControlFuentesPorIndicador.Guardar();
            }

            ControlRepresenVisualIndicador objControlRepresenVisualIndicador = new ControlRepresenVisualIndicador(null);
            objControlRepresenVisualIndicador.borrarRepresenVisualIndicador(id);

            for (int i = 0; i < lbRepresenVisualIndicador.Items.Count; i++)
            {
                string[] idNombreRepresenVisual = lbRepresenVisualIndicador.Items[i].Text.Split(':');
                int fkIdRepresenVisual = Convert.ToInt32(idNombreRepresenVisual[0]);
                RepresenVisualIndicador objRepresenVisualIndicador = new RepresenVisualIndicador(id, fkIdRepresenVisual);
                objControlRepresenVisualIndicador = new ControlRepresenVisualIndicador(objRepresenVisualIndicador);
                objControlRepresenVisualIndicador.Guardar();

            }

            ControlResponsableIndicador objControlResponsableIndicador = new ControlResponsableIndicador(null);
            objControlResponsableIndicador.borrarResponsableIndicador(id);

            for (int i = 0; i < lbResponsables.Items.Count; i++)
            {
                string[] arregloActores = lbResponsables.Items[i].Text.Split(':');
                string fkIdResponsables = arregloActores[0];
                DateTime fechaIngresada = Convert.ToDateTime(txtFechaAsignacion.Text);
                string fechaFormateada = fechaIngresada.ToString("yyyy-MM-dd HH:mm:ss");


                ResponsableIndicador objResponsableIndicador = new ResponsableIndicador(fkIdResponsables, id, fechaFormateada);
                objControlResponsableIndicador = new ControlResponsableIndicador(objResponsableIndicador);
                objControlResponsableIndicador.Guardar();

            }

            ControlVariablesIndicador objControlVariablesIndicador = new ControlVariablesIndicador(null);
            objControlVariablesIndicador.borrarVariablesPorIndicador(id);

            for (int i = 0; i < lbVariablesIndicador.Items.Count; i++)
            {
                string[] idNombreVariables = lbVariablesIndicador.Items[i].Text.Split(':');
                string[] guardarVariables = lbVariablesIndicador.Items[i].Text.Split(';');
                int fkIdVariable = Convert.ToInt32(idNombreVariables[0]);
                float dato = Convert.ToSingle(guardarVariables[1]);
                string fkEmailUsuario = guardarVariables[2];
                DateTime fecha = Convert.ToDateTime(guardarVariables[3]);
                string fechaDato = fecha.ToString("yyyy-MM-dd HH:mm:ss");
                VariablesPorIndicador objVariablesPorIndicador = new VariablesPorIndicador(0, fkIdVariable, id, dato, fkEmailUsuario, fechaDato);
                ControlVariablesIndicador objControlVariablesPorIndicador = new ControlVariablesIndicador(objVariablesPorIndicador);
                objControlVariablesPorIndicador.Guardar();

            }

            


            Response.Redirect("FrmIndicador.aspx");
            
        }
        protected void BtnBorrar(object sender, CommandEventArgs e)
        {
            int id = Convert.ToInt32(txtId1.Text);

            Indicador objIndicador = new Indicador(id);
            ControlIndicador objControlIndicador = new ControlIndicador(objIndicador);
            objControlIndicador.Borrar();

            Response.Redirect("FrmIndicador.aspx");

        }

        protected void BtnAgregar(object sender, EventArgs e)
        {
            lbFuentes.Items.Add(ddlFuentes.Text);
            ddlFuentes.Items.Remove(ddlFuentes.Text);
        }

        protected void BtnRemover(object sender, EventArgs e)
        {
            lbFuentes.Items.Remove(lbFuentes.Text);

        }

        protected void BtnRemoveResponsable(object sender, EventArgs e)
        {
            lbResponsables.Items.Remove(lbResponsables.Text);
        }

        protected void BtnAddResponsable(object sender, EventArgs e)
        {
            lbResponsables.Items.Add(ddlResponsables.Text);
            ddlResponsables.Items.Remove(ddlResponsables.Text);
        }

        protected void BtnRemoveRepresen(object sender, EventArgs e)
        {
            lbRepresenVisualIndicador.Items.Remove(lbRepresenVisualIndicador.Text);
            ddlRepresenVisualindicador.Items.Add(ddlRepresenVisualindicador.Text);
        }

        protected void BtnAddRepresen(object sender, EventArgs e)
        {
            lbRepresenVisualIndicador.Items.Add(ddlRepresenVisualindicador.Text);
            ddlRepresenVisualindicador.Items.Remove(ddlRepresenVisualindicador.Text);

        }

        protected void BtnAddVariables(object sender, EventArgs e)
        {
            lbVariablesIndicador.Items.Add(ddlVariables.Text + ";" + txtDato.Text + ";" + ddlEmail.SelectedValue.ToString() + ";" + txtFechaDato.Text) ;
            

        }

        protected void BtnRemoveVariables(object sender, EventArgs e)
        {
            if (lbVariablesIndicador.SelectedIndex >= 0)
            {
                lbVariablesIndicador.Items.RemoveAt(lbVariablesIndicador.SelectedIndex);
            }
        }
    }
}