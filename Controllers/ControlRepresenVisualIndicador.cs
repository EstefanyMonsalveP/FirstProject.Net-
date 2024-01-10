using primeraEntrega.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace primeraEntrega.Controllers
{
    public class ControlRepresenVisualIndicador
    {
        RepresenVisualIndicador objRepresenVisualIndicador;

        public ControlRepresenVisualIndicador(RepresenVisualIndicador objRepresenVisualIndicador)
        {
            this.objRepresenVisualIndicador = objRepresenVisualIndicador;
        }

        public string Guardar()
        {
            string baseDeDatos = "bd_indicadores_1330.mdf";
            ControlConexion objControlConexion = new ControlConexion(baseDeDatos);
            int fkIdIndicador = objRepresenVisualIndicador.FkIdIndicador;
            int fkIdRepresenVisual = objRepresenVisualIndicador.FkIdRepresenVisual;
            string comandoSQL = String.Format("INSERT INTO represenvisualporindicador(fkidindicador,fkIdRepresenVisual) VALUES('{0}','{1}')",  fkIdIndicador, fkIdRepresenVisual);
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
        public string Modificar()
        {
            string baseDeDatos = "bd_indicadores_1330.mdf";
            ControlConexion objControlConexion = new ControlConexion(baseDeDatos);
            int fkIdRepresenVisual = objRepresenVisualIndicador.FkIdRepresenVisual;
            int fkIdIndicador = objRepresenVisualIndicador.FkIdIndicador;
            string comandoSQL = String.Format("INSERT INTO represenvisualporindicador(fkidindicador,fkIdRepresenVisual) VALUES('{0}','{1}')" , fkIdRepresenVisual, fkIdIndicador);
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

        public string borrarRepresenVisualIndicador(int fkIdIndicador)
        {
            string msg = "ok";
            try
            {
                string baseDeDatos = "bd_indicadores_1330.mdf";
                ControlConexion objControlConexion = new ControlConexion(baseDeDatos);
                string comandoSQL = "DELETE FROM represenvisualporindicador WHERE fkidindicador='" + fkIdIndicador + "'";
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

        public RepresenVisual[] Consultar(int fkIdIndicador)
        {
            RepresenVisual[] arregloRepresenVisual = null;

            string baseDeDatos = "bd_indicadores_1330.mdf";
            ControlConexion objControlConexion = new ControlConexion(baseDeDatos);
            string comandoSql = String.Format("SELECT dbo.represenvisual.id, dbo.represenvisual.nombre " +
            "FROM dbo.represenvisual INNER JOIN " +
            "dbo.represenvisualporindicador ON dbo.represenvisualporindicador.fkidrepresenvisual = dbo.represenvisual.id " +
            "WHERE represenvisualporindicador.fkidindicador = '" + fkIdIndicador + "'");
            int i = 0;
            string msj = "Ok";
            try
            {
                objControlConexion.AbrirBD();
                DataSet objDataSet = objControlConexion.ejecutarConsultaSql(comandoSql);

                if (objDataSet.Tables[0].Rows.Count > 0)
                {
                    arregloRepresenVisual = new RepresenVisual[objDataSet.Tables[0].Rows.Count];

                    while (i < objDataSet.Tables[0].Rows.Count)
                    {
                        RepresenVisual objRepresenVisual = new RepresenVisual();
                        objRepresenVisual.Id = Convert.ToInt32(objDataSet.Tables[0].Rows[i][0].ToString());
                        objRepresenVisual.Nombre = objDataSet.Tables[0].Rows[i][1].ToString();

                        arregloRepresenVisual[i] = objRepresenVisual;
                        i++;
                    }
                    objControlConexion.CerrarBD();
                }
            }
            catch (Exception Ex)
            {
                msj = Ex.Message;
            }
            return arregloRepresenVisual;
        }
    }
}