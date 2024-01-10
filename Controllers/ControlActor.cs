using primeraEntrega.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Runtime.Remoting;
using System.Web;

namespace primeraEntrega.Controllers
{
    public class ControlActor
    {
        Actor objActor;

        public ControlActor(Actor objActor) 
        {
            this.objActor = objActor;
        }

        public Actor[] Listar()
        {
            Actor[] arregloActor = null;
            string baseDeDatos = "bd_indicadores_1330.mdf";
            ControlConexion objControlConexion = new ControlConexion(baseDeDatos);
            Actor objActor; // Declarar objActor
            string comandoSQL = "SELECT *FROM Actor";
            string msg = "ok";
            int i;
            objControlConexion.AbrirBD();
            DataSet objDataSet = objControlConexion.ejecutarConsultaSql(comandoSQL);
            try
            {
                if (objDataSet.Tables[0].Rows.Count > 0)
                {
                    i = 0;
                    arregloActor = new Actor[objDataSet.Tables[0].Rows.Count];
                    while (i < objDataSet.Tables[0].Rows.Count)
                    {
                        objActor = new Actor();
                        objActor.Id = objDataSet.Tables[0].Rows[i][0].ToString();
                        objActor.Nombre = objDataSet.Tables[0].Rows[i][1].ToString();
                        objActor.FkIdTipoActor = Convert.ToInt32(objDataSet.Tables[0].Rows[i][2].ToString());
                        arregloActor[i] = objActor;
                        i++;
                    }
                    objControlConexion.CerrarBD();
                }
            }
            catch (Exception objException)
            {
                msg = objException.Message;
            }
            return arregloActor;
        }


        public Actor Consultar()
        {
            string baseDeDatos = "bd_indicadores_1330.mdf";
            ControlConexion objControlConexion = new ControlConexion(baseDeDatos);
            string id = objActor.Id;
            string comandoSQL = String.Format("SELECT * FROM actor WHERE id='{0}'", id);
            string msg = "ok";
            objControlConexion.AbrirBD();
            DataSet objDataSet = objControlConexion.ejecutarConsultaSql(comandoSQL);
            try
            {
                if (objDataSet.Tables[0].Rows.Count > 0)
                {
                    objActor.Nombre = objDataSet.Tables[0].Rows[0][1].ToString();
                    objActor.FkIdTipoActor = Convert.ToInt32(objDataSet.Tables[0].Rows[0][2].ToString());
                    objControlConexion.CerrarBD();
                }
            }
            catch (Exception objException)
            {
                msg = objException.Message;
            }
            return this.objActor;
        }

        public string Guardar()
        {
            string baseDeDatos = "bd_indicadores_1330.mdf";
            ControlConexion objControlConexion = new ControlConexion(baseDeDatos);
            string id = objActor.Id;
            string nombre = objActor.Nombre;
            int fkIdTipoActor = objActor.FkIdTipoActor;
            string comandoSQL = String.Format("INSERT INTO Actor(id,nombre,fkidtipoactor) VALUES('{0}','{1}',{2})", id, nombre,fkIdTipoActor);
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
            string id = objActor.Id;
            string nombre = objActor.Nombre;
            int fkIdTipoActor = objActor.FkIdTipoActor;
            string comandoSQL = String.Format("UPDATE Actor SET nombre='{0}', fkidtipoactor='{1}' WHERE id='{2}'", nombre, fkIdTipoActor,id);
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
        public string Borrar()
        {
            string baseDeDatos = "bd_indicadores_1330.mdf";
            ControlConexion objControlConexion = new ControlConexion(baseDeDatos);
            string id = objActor.Id;
            string comandoSQL = String.Format("DELETE FROM Actor WHERE id='{0}'", id);
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


    }
}