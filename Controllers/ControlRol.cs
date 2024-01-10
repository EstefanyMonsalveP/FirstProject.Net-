using primeraEntrega.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace primeraEntrega.Controllers
{
    public class ControlRol
    {
        Rol objRol;
        public ControlRol(Rol objRol)
        {
            this.objRol = objRol;
        }
        public Rol[] Listar()
        {
            Rol[] arregloRol = null;
            string baseDeDatos = "bd_indicadores_1330.mdf";
            ControlConexion objControlConexion = new ControlConexion(baseDeDatos);
            string comandoSQL = "SELECT * FROM rol";
            string msg = "ok";
            int i;
            objControlConexion.AbrirBD();
            DataSet objDataSet = objControlConexion.ejecutarConsultaSql(comandoSQL);
            try
            {
                if (objDataSet.Tables[0].Rows.Count > 0)
                {
                    i = 0;
                    arregloRol = new Rol[objDataSet.Tables[0].Rows.Count];
                    while (i < objDataSet.Tables[0].Rows.Count)
                    {
                        objRol = new Rol();
                        objRol.Id = Convert.ToInt32(objDataSet.Tables[0].Rows[i][0].ToString());
                        objRol.Nombre = objDataSet.Tables[0].Rows[i][1].ToString();

                        arregloRol[i] = objRol;
                        i++;
                    }
                    objControlConexion.CerrarBD();
                }
            }
            catch (Exception objException)
            {
                msg = objException.Message;
            }
            return arregloRol;
        }

        public Rol Consultar()
        {
            string baseDeDatos = "bd_indicadores_1330.mdf";
            ControlConexion objControlConexion = new ControlConexion(baseDeDatos);
            int id = objRol.Id;
            string comandoSQL = String.Format("SELECT * FROM Rol WHERE id='{0}'", id);
            string msg = "ok";
            objControlConexion.AbrirBD();
            DataSet objDataSet = objControlConexion.ejecutarConsultaSql(comandoSQL);
            try
            {
                if (objDataSet.Tables[0].Rows.Count > 0)
                {
                    objRol.Nombre = objDataSet.Tables[0].Rows[0][1].ToString();
                    objControlConexion.CerrarBD();
                }
            }
            catch (Exception objException)
            {
                msg = objException.Message;
            }
            return this.objRol;
        }
        public string Guardar()
        {
            string baseDeDatos = "bd_indicadores_1330.mdf";
            ControlConexion objControlConexion = new ControlConexion(baseDeDatos);
            string nom = objRol.Nombre;
            string comandoSQL = String.Format("INSERT INTO Rol(nombre) VALUES('{0}')", nom);
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
            int id = objRol.Id;
            string nom = objRol.Nombre;
            string comandoSQL = String.Format("UPDATE Rol SET nombre='{0}' WHERE id='{1}'", nom, id);
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
            int id = objRol.Id;
            string comandoSQL = String.Format("DELETE FROM Rol WHERE id='{0}'", id);
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