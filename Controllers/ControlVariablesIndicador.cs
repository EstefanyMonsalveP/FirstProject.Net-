using primeraEntrega.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;
using System.Web;

namespace primeraEntrega.Controllers
{
    public class ControlVariablesIndicador
    {
        VariablesPorIndicador objVariablesPorIndicador;

        public ControlVariablesIndicador(VariablesPorIndicador objVariablesPorIndicador)
        {
            this.objVariablesPorIndicador = objVariablesPorIndicador;
        }

        public string Guardar()
        {
            string baseDeDatos = "bd_indicadores_1330.mdf";
            ControlConexion objControlConexion = new ControlConexion(baseDeDatos);
            int fkIdVariable = objVariablesPorIndicador.FkIdVariable;
            int fkIdIndicador = objVariablesPorIndicador.FkIdIndicador;
            float dato = objVariablesPorIndicador.Dato;
            string fkEmailUsuario = objVariablesPorIndicador.FkEmailUsuario;
            string fechaDato = objVariablesPorIndicador.FechaDato;
            string comandoSQL = String.Format("INSERT INTO variablesporindicador(fkidvariable,fkidindicador,dato,fkemailusuario,fechadato) VALUES('{0}','{1}','{2}','{3}','{4}')", fkIdVariable, fkIdIndicador, dato,fkEmailUsuario,fechaDato);
            string msg = "ok";
            objControlConexion.AbrirBD();
            try
            {
                objControlConexion.EjecutarComandoSQL(comandoSQL);
                objControlConexion.CerrarBD();
            }
            catch (Exception objException)
            {
                msg = objException.Message;
            }
            return msg;
        }

        public VariablesPorIndicador[] ConsultarVariablesIndicador(int fkIdIndicador)
        {
            VariablesPorIndicador[] arregloVariablesPorIndicador = null;

            string baseDeDatos = "bd_indicadores_1330.mdf";
            ControlConexion objControlConexion = new ControlConexion(baseDeDatos);
            string comandoSql = String.Format("SELECT dato, fkemailusuario, fechadato " +
            "FROM dbo.variablesporindicador " +
            "WHERE dbo.variablesporindicador.fkidindicador ='" + fkIdIndicador + "'");
            
            string msj = "Ok";
            try
            {
                objControlConexion.AbrirBD();
                
                DataSet objDataSet = objControlConexion.ejecutarConsultaSql(comandoSql);

                if (objDataSet.Tables[0].Rows.Count > 0)
                {
                    arregloVariablesPorIndicador = new VariablesPorIndicador [objDataSet.Tables[0].Rows.Count];

                    for (int i=0;i < objDataSet.Tables[0].Rows.Count;i++)
                    {
                        VariablesPorIndicador objVariablesPorIndicador = new VariablesPorIndicador();
                        objVariablesPorIndicador.Dato = Convert.ToSingle(objDataSet.Tables[0].Rows[i]["dato"]);
                        objVariablesPorIndicador.FkEmailUsuario = objDataSet.Tables[0].Rows[i]["fkemailusuario"].ToString();
                        objVariablesPorIndicador.FechaDato = objDataSet.Tables[0].Rows[i]["fechadato"].ToString();

                        arregloVariablesPorIndicador[i] = objVariablesPorIndicador;
                        

                    }
                    objControlConexion.CerrarBD();
                }
            }
            catch (Exception Ex)
            {
                msj = Ex.Message;
            }
            return arregloVariablesPorIndicador;
        }


        public string borrarVariablesPorIndicador(int fkIdIndicador)
        {
            string msg = "ok";
            try
            {
                string baseDeDatos = "bd_indicadores_1330.mdf";
                ControlConexion objControlConexion = new ControlConexion(baseDeDatos);
                string comandoSQL = "DELETE FROM variablesporindicador WHERE fkidindicador='" + fkIdIndicador + "'";
                objControlConexion.AbrirBD();
                objControlConexion.EjecutarComandoSQL(comandoSQL);
                objControlConexion.CerrarBD();
            }
            catch (Exception objException)
            {
                msg = objException.Message;
            }
            return msg;
        }

        public Variable[] ConsultarVariable(int fkIdIndicador)
        {
            Variable[] arregloVariable = null;

            string baseDeDatos = "bd_indicadores_1330.mdf";
            ControlConexion objControlConexion = new ControlConexion(baseDeDatos);
            string comandoSql = String.Format("SELECT dbo.variable.id, dbo.variable.nombre " +
            "FROM dbo.variable INNER JOIN " +
            "dbo.variablesporindicador ON dbo.variablesporindicador.fkidvariable = dbo.variable.id " +
            "WHERE variablesporindicador.fkidindicador = '" + fkIdIndicador + "'");
            int i = 0;
            string msj = "Ok";
            try
            {
                objControlConexion.AbrirBD();
                DataSet objDataSet = objControlConexion.ejecutarConsultaSql(comandoSql);

                if (objDataSet.Tables[0].Rows.Count > 0)
                {
                    arregloVariable = new Variable[objDataSet.Tables[0].Rows.Count];

                    while (i < objDataSet.Tables[0].Rows.Count)
                    {
                        Variable objVariable = new Variable();
                        objVariable.Id = Convert.ToInt32(objDataSet.Tables[0].Rows[i][0].ToString());
                        objVariable.Nombre = objDataSet.Tables[0].Rows[i][1].ToString();

                        arregloVariable[i] = objVariable;
                        i++;
                    }
                    objControlConexion.CerrarBD();
                }
            }
            catch (Exception Ex)
            {
                msj = Ex.Message;
            }
            return arregloVariable;
        }
    
    }
}