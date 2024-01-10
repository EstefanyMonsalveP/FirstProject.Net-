using primeraEntrega.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace primeraEntrega.Controllers
{
    public class ControlRepresenVisual
    {
        RepresenVisual objRepresenVisual;

        public ControlRepresenVisual(RepresenVisual objRepresenVisual)
        {
            this.objRepresenVisual = objRepresenVisual;
        }


        public RepresenVisual[] Listar()
        {
            RepresenVisual[] arregloRepresenVisual = null;
            string baseDeDatos = "bd_indicadores_1330.mdf";
            ControlConexion objControlConexion = new ControlConexion(baseDeDatos);
            string comandoSQL = "SELECT * FROM RepresenVisual";
            string msg = "ok";
            int i;
            objControlConexion.AbrirBD();
            DataSet objDataSet = objControlConexion.ejecutarConsultaSql(comandoSQL);
            try
            {
                if (objDataSet.Tables[0].Rows.Count > 0)
                {
                    i = 0;
                    arregloRepresenVisual = new RepresenVisual[objDataSet.Tables[0].Rows.Count];
                    while (i < objDataSet.Tables[0].Rows.Count)
                    {
                        objRepresenVisual = new RepresenVisual();
                        objRepresenVisual.Id = Convert.ToInt32(objDataSet.Tables[0].Rows[i][0].ToString());
                        objRepresenVisual.Nombre = objDataSet.Tables[0].Rows[i][1].ToString();

                        arregloRepresenVisual[i] = objRepresenVisual;
                        i++;
                    }
                    objControlConexion.CerrarBD();
                }
            }
            catch (Exception objException)
            {
                msg = objException.Message;
            }
            return arregloRepresenVisual;
        }


        public RepresenVisual Consultar()
        {
            string baseDeDatos = "bd_indicadores_1330.mdf";
            ControlConexion objControlConexion = new ControlConexion(baseDeDatos);
            int id = objRepresenVisual.Id;
            string comandoSql = String.Format("SELECT *FROM RepresenVisual WHERE ID ={0}", id);
            string msj = "Ok";

            try
            {
                objControlConexion.AbrirBD();
                DataSet objDataSet = objControlConexion.ejecutarConsultaSql(comandoSql);
                if (objDataSet.Tables[0].Rows.Count > 0)
                {

                    objRepresenVisual.Id = Convert.ToInt32(objDataSet.Tables[0].Rows[0][0]);
                    objRepresenVisual.Nombre = objDataSet.Tables[0].Rows[0][1].ToString();

                    objControlConexion.CerrarBD();
                }

            }
            catch (Exception Ex)
            {

                msj = Ex.Message;
            }
            return this.objRepresenVisual;
        }

        public string Guardar()
        {
            string baseDeDatos = "bd_indicadores_1330.mdf";
            ControlConexion objControlConexion = new ControlConexion(baseDeDatos);
            string nombre = objRepresenVisual.Nombre;
            string comandoSql = String.Format("INSERT INTO RepresenVisual ( NOMBRE) VALUES ('{0}')", nombre);
            string msj = "Ok";

            try
            {

                objControlConexion.AbrirBD();
                objControlConexion.EjecutarComandoSQL(comandoSql);
                objControlConexion.CerrarBD();

            }
            catch (Exception Ex)
            {

                msj = Ex.Message;
            }
            return msj;
        }

        public string Modificar()
        {
            string baseDeDatos = "bd_indicadores_1330.mdf";
            ControlConexion objControlConexion = new ControlConexion(baseDeDatos);
            int id = objRepresenVisual.Id;
            string nombre = objRepresenVisual.Nombre;
            string comandoSql = String.Format("UPDATE RepresenVisual SET NOMBRE ='{0}' WHERE ID= '{1}'", nombre, id);
            string msj = "Ok";


            try
            {
                objControlConexion.AbrirBD();
                objControlConexion.EjecutarComandoSQL(comandoSql);
                objControlConexion.CerrarBD();

            }
            catch (Exception Ex)
            {

                msj = Ex.Message;
            }
            return msj;
        }

        public string Borrar()
        {
            string baseDeDatos = "bd_indicadores_1330.mdf";
            ControlConexion objControlConexion = new ControlConexion(baseDeDatos);
            int id = objRepresenVisual.Id;
            string comandoSQL = String.Format("DELETE FROM RepresenVisual WHERE id='{0}'", id);
            string msg = "ok";

            try
            {
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