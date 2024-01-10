using primeraEntrega.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace primeraEntrega.Controllers
{
    public class ControlResponsableIndicador
    {
        ResponsableIndicador objResponsableIndicador;

        public ControlResponsableIndicador(ResponsableIndicador objResponsableIndicador)
        {
            this.objResponsableIndicador = objResponsableIndicador;
        }

       
        public string Guardar()
        {
            string baseDeDatos = "bd_indicadores_1330.mdf";
            ControlConexion objControlConexion = new ControlConexion(baseDeDatos);
            string fkIdResponsable = objResponsableIndicador.FkIdResponsable;
            int fkIdIndicador = objResponsableIndicador.FkIdIndicador;
            string fechaAsignacion = objResponsableIndicador.FechaAsignacion;
            string comandoSQL = String.Format("INSERT INTO responsablesporindicador(fkidresponsable,fkidindicador,fechaasignacion) VALUES('{0}','{1}','{2}')", fkIdResponsable, fkIdIndicador, fechaAsignacion);
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

        public Actor[] Consultar(int fkIdIndicador)
        {
            Actor[] arregloResponsableIndicador = null;

            string baseDeDatos = "bd_indicadores_1330.mdf";
            ControlConexion objControlConexion = new ControlConexion(baseDeDatos);
            string comandoSql = String.Format("SELECT dbo.actor.id, dbo.actor.nombre " +
            "FROM dbo.actor INNER JOIN " +
            "dbo.responsablesporindicador ON dbo.responsablesporindicador.fkidresponsable = dbo.actor.id " +
            "WHERE responsablesporindicador.fkidindicador = '" + fkIdIndicador + "'");
            int i = 0;
            string msj = "Ok";
            try
            {
                objControlConexion.AbrirBD();
                DataSet objDataSet = objControlConexion.ejecutarConsultaSql(comandoSql);

                if (objDataSet.Tables[0].Rows.Count > 0)
                {
                    arregloResponsableIndicador = new Actor[objDataSet.Tables[0].Rows.Count];

                    while (i < objDataSet.Tables[0].Rows.Count)
                    {
                        Actor objActor = new Actor();
                        objActor.Id = objDataSet.Tables[0].Rows[i][0].ToString();
                        objActor.Nombre = objDataSet.Tables[0].Rows[i][1].ToString();

                        arregloResponsableIndicador[i] = objActor;
                        i++;
                    }
                    objControlConexion.CerrarBD();
                }
            }
            catch (Exception Ex)
            {
                msj = Ex.Message;
            }
            return arregloResponsableIndicador;
        }

        public string borrarResponsableIndicador(int fkIdIndicador)
        {
            string msg = "ok";
            try
            {
                string baseDeDatos = "bd_indicadores_1330.mdf";
                ControlConexion objControlConexion = new ControlConexion(baseDeDatos);
                string comandoSQL = "DELETE FROM responsablesporindicador WHERE fkidindicador='" + fkIdIndicador + "'";
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
    }
    
}