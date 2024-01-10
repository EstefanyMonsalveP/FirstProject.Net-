using primeraEntrega.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace primeraEntrega.Controllers
{
    public class ControlTipoActor
    {
        TipoActor objTipoActor;

        public ControlTipoActor(TipoActor objTipoActor)
        {
            this.objTipoActor = objTipoActor;
        }


        public TipoActor[] Listar()
        {
            TipoActor[] arregloTipoActor = null;
            string baseDeDatos = "bd_indicadores_1330.mdf";
            ControlConexion objControlConexion = new ControlConexion(baseDeDatos);
            string comandoSQL = "SELECT * FROM TipoActor";
            string msg = "ok";
            int i;
            objControlConexion.AbrirBD();
            DataSet objDataSet = objControlConexion.ejecutarConsultaSql(comandoSQL);
            try
            {
                if (objDataSet.Tables[0].Rows.Count > 0)
                {
                    i = 0;
                    arregloTipoActor = new TipoActor[objDataSet.Tables[0].Rows.Count];
                    while (i < objDataSet.Tables[0].Rows.Count)
                    {
                        objTipoActor = new TipoActor();
                        objTipoActor.Id = Convert.ToInt32(objDataSet.Tables[0].Rows[i][0].ToString());
                        objTipoActor.Nombre = objDataSet.Tables[0].Rows[i][1].ToString();

                        arregloTipoActor[i] = objTipoActor;
                        i++;
                    }
                    objControlConexion.CerrarBD();
                }
            }
            catch (Exception objException)
            {
                msg = objException.Message;
            }
            return arregloTipoActor;
        }


        public TipoActor Consultar()
        {
            string baseDeDatos = "bd_indicadores_1330.mdf";
            ControlConexion objControlConexion = new ControlConexion(baseDeDatos);
            int id = objTipoActor.Id;
            string comandoSql = String.Format("SELECT *FROM TipoActor WHERE ID ={0}", id);
            string msj = "Ok";

            try
            {
                objControlConexion.AbrirBD();
                DataSet objDataSet = objControlConexion.ejecutarConsultaSql(comandoSql);
                if (objDataSet.Tables[0].Rows.Count > 0)
                {

                    objTipoActor.Id = Convert.ToInt32(objDataSet.Tables[0].Rows[0][0]);
                    objTipoActor.Nombre = objDataSet.Tables[0].Rows[0][1].ToString();

                    objControlConexion.CerrarBD();
                }

            }
            catch (Exception Ex)
            {

                msj = Ex.Message;
            }
            return this.objTipoActor;
        }

        public string Guardar()
        {
            string baseDeDatos = "bd_indicadores_1330.mdf";
            ControlConexion objControlConexion = new ControlConexion(baseDeDatos);
            string nombre = objTipoActor.Nombre;
            string comandoSql = String.Format("INSERT INTO TipoActor ( NOMBRE) VALUES ('{0}')", nombre);
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
            int id = objTipoActor.Id;
            string nombre = objTipoActor.Nombre;
            string comandoSql = String.Format("UPDATE TipoActor SET NOMBRE ='{0}' WHERE ID= '{1}'", nombre, id);
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
            int id = objTipoActor.Id;
            string comandoSQL = String.Format("DELETE FROM TipoActor WHERE id='{0}'", id);
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