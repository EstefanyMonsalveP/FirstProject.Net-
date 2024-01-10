using primeraEntrega.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace primeraEntrega.Controllers
{
    public class ControlFuente
    {
        Fuente objFuente;

        public ControlFuente(Fuente objFuente)
        {
            this.objFuente = objFuente;
        }


        public Fuente[] Listar()
        {
            Fuente[] arregloFuente = null;
            string baseDeDatos = "bd_indicadores_1330.mdf";
            ControlConexion objControlConexion = new ControlConexion(baseDeDatos);
            string comandoSQL = "SELECT * FROM Fuente";
            string msg = "ok";
            int i;
            objControlConexion.AbrirBD();
            DataSet objDataSet = objControlConexion.ejecutarConsultaSql(comandoSQL);
            try
            {
                if (objDataSet.Tables[0].Rows.Count > 0)
                {
                    i = 0;
                    arregloFuente = new Fuente[objDataSet.Tables[0].Rows.Count];
                    while (i < objDataSet.Tables[0].Rows.Count)
                    {
                        objFuente = new Fuente();
                        objFuente.Id = Convert.ToInt32(objDataSet.Tables[0].Rows[i][0].ToString());
                        objFuente.Nombre = objDataSet.Tables[0].Rows[i][1].ToString();

                        arregloFuente[i] = objFuente;
                        i++;
                    }
                    objControlConexion.CerrarBD();
                }
            }
            catch (Exception objException)
            {
                msg = objException.Message;
            }
            return arregloFuente;
        }


        public Fuente Consultar()
        {
            string baseDeDatos = "bd_indicadores_1330.mdf";
            ControlConexion objControlConexion = new ControlConexion(baseDeDatos);
            int id = objFuente.Id;
            string comandoSql = String.Format("SELECT *FROM Fuente WHERE ID ={0}", id);
            string msj = "Ok";

            try
            {
                objControlConexion.AbrirBD();
                DataSet objDataSet = objControlConexion.ejecutarConsultaSql(comandoSql);
                if (objDataSet.Tables[0].Rows.Count > 0)
                {

                    objFuente.Id = Convert.ToInt32(objDataSet.Tables[0].Rows[0][0]);
                    objFuente.Nombre = objDataSet.Tables[0].Rows[0][1].ToString();

                    objControlConexion.CerrarBD();
                }

            }
            catch (Exception Ex)
            {

                msj = Ex.Message;
            }
            return this.objFuente;
        }

        public string Guardar()
        {
            string baseDeDatos = "bd_indicadores_1330.mdf";
            ControlConexion objControlConexion = new ControlConexion(baseDeDatos);
            string nombre = objFuente.Nombre;
            string comandoSql = String.Format("INSERT INTO Fuente ( NOMBRE) VALUES ('{0}')", nombre);
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
            int id = objFuente.Id;
            string nombre = objFuente.Nombre;
            string comandoSql = String.Format("UPDATE Fuente SET NOMBRE ='{0}' WHERE ID= '{1}'", nombre, id);
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
            int id = objFuente.Id;
            string comandoSQL = String.Format("DELETE FROM Fuente WHERE id='{0}'", id);
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