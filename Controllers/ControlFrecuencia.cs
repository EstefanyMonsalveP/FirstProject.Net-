using primeraEntrega.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace primeraEntrega.Controllers
{
    public class ControlFrecuencia
    {
        Frecuencia objFrecuencia;

        public ControlFrecuencia(Frecuencia objFrecuencia)
        {
            this.objFrecuencia = objFrecuencia;
        }

        public Frecuencia[] Listar()
        {
            Frecuencia[] arregloFrecuencia = null;
            string baseDeDatos = "bd_indicadores_1330.mdf";
            ControlConexion objControlConexion = new ControlConexion(baseDeDatos);
            string comandoSQL = "SELECT * FROM frecuencia";
            string msg = "ok";
            int i;
            objControlConexion.AbrirBD();
            DataSet objDataSet = objControlConexion.ejecutarConsultaSql(comandoSQL);
            try
            {
                if (objDataSet.Tables[0].Rows.Count > 0)
                {
                    i = 0;
                    arregloFrecuencia = new Frecuencia[objDataSet.Tables[0].Rows.Count];
                    while (i < objDataSet.Tables[0].Rows.Count)
                    {
                        objFrecuencia = new Frecuencia();
                        objFrecuencia.Id = Convert.ToInt32(objDataSet.Tables[0].Rows[i][0].ToString());
                        objFrecuencia.Descripcion = objDataSet.Tables[0].Rows[i][1].ToString();

                        arregloFrecuencia[i] = objFrecuencia;
                        i++;
                    }
                    objControlConexion.CerrarBD();
                }
            }
            catch (Exception objException)
            {
                msg = objException.Message;
            }
            return arregloFrecuencia;
        }


        public Frecuencia Consultar()
        {
            string baseDeDatos = "bd_indicadores_1330.mdf";
            ControlConexion objControlConexion = new ControlConexion(baseDeDatos);
            int id = objFrecuencia.Id;
            string comandoSql = String.Format("SELECT *FROM Frecuencia WHERE ID ={0}", id);
            string msj = "Ok";

            try
            {
                objControlConexion.AbrirBD();
                DataSet objDataSet = objControlConexion.ejecutarConsultaSql(comandoSql);
                if (objDataSet.Tables[0].Rows.Count > 0)
                {

                    objFrecuencia.Id = Convert.ToInt32(objDataSet.Tables[0].Rows[0][0]);
                    objFrecuencia.Descripcion = objDataSet.Tables[0].Rows[0][1].ToString();

                    objControlConexion.CerrarBD();
                }

            }
            catch (Exception Ex)
            {

                msj = Ex.Message;
            }
            return this.objFrecuencia;
        }

        public string Guardar()
        {
            string baseDeDatos = "bd_indicadores_1330.mdf";
            ControlConexion objControlConexion = new ControlConexion(baseDeDatos);
            int id = objFrecuencia.Id;
            string Descripcion = objFrecuencia.Descripcion;
            string comandoSql = String.Format("INSERT INTO Frecuencia ( id, Descripcion) VALUES ('{0}','{1}')", id,Descripcion);
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
            int id = objFrecuencia.Id;
            string Descripcion = objFrecuencia.Descripcion;
            string comandoSql = String.Format("UPDATE Frecuencia SET Descripcion ='{0}' WHERE ID= '{1}'", Descripcion, id);
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
            int id = objFrecuencia.Id;
            string comandoSQL = String.Format("DELETE FROM Frecuencia WHERE id='{0}'", id);
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