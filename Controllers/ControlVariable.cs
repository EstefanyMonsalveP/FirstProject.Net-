using primeraEntrega.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace primeraEntrega.Controllers
{
    public class ControlVariable
    {
        Variable objVariable;

        public ControlVariable(Variable objVariable)
        {
            this.objVariable = objVariable;
        }

        public Variable[] Listar()
        {
            Variable[] arregloVariable = null;
            string baseDeDatos = "bd_indicadores_1330.mdf";
            ControlConexion objControlConexion = new ControlConexion(baseDeDatos);
            string comandoSQL = "SELECT * FROM variable";
            string msg = "ok";
            int i;
            objControlConexion.AbrirBD();
            DataSet objDataSet = objControlConexion.ejecutarConsultaSql(comandoSQL);
            try
            {
                if (objDataSet.Tables[0].Rows.Count > 0)
                {
                    i = 0;
                    arregloVariable = new Variable[objDataSet.Tables[0].Rows.Count];
                    while (i < objDataSet.Tables[0].Rows.Count)
                    {
                        objVariable = new Variable();
                        objVariable.Id = Convert.ToInt32(objDataSet.Tables[0].Rows[i][0].ToString());
                        objVariable.Nombre = objDataSet.Tables[0].Rows[i][1].ToString();
                        objVariable.FechaCreacion = objDataSet.Tables[0].Rows[i][2].ToString();
                        objVariable.FkEmailUsuario = objDataSet.Tables[0].Rows[i][3].ToString();

                        arregloVariable[i] = objVariable;
                        i++;
                    }
                    objControlConexion.CerrarBD();
                }
            }
            catch (Exception objException)
            {
                msg = objException.Message;
            }
            return arregloVariable;
        }


        public Variable Consultar()
        {
            string baseDeDatos = "bd_indicadores_1330.mdf";
            ControlConexion objControlConexion = new ControlConexion(baseDeDatos);
            int id = objVariable.Id;
            string comandoSql = String.Format("SELECT *FROM Variable WHERE ID ={0}", id);
            string msj = "Ok";

            try
            {
                objControlConexion.AbrirBD();
                DataSet objDataSet = objControlConexion.ejecutarConsultaSql(comandoSql);
                if (objDataSet.Tables[0].Rows.Count > 0)
                {

                    objVariable.Id = Convert.ToInt32(objDataSet.Tables[0].Rows[0][0]);
                    objVariable.Nombre = objDataSet.Tables[0].Rows[0][1].ToString();
                    objVariable.FechaCreacion = objDataSet.Tables[0].Rows[0][2].ToString();
                    objVariable.FkEmailUsuario = objDataSet.Tables[0].Rows[0][3].ToString();

                    objControlConexion.CerrarBD();
                }

            }
            catch (Exception Ex)
            {

                msj = Ex.Message;
            }
            return this.objVariable;
        }

        public string Guardar()
        {
            string baseDeDatos = "bd_indicadores_1330.mdf";
            ControlConexion objControlConexion = new ControlConexion(baseDeDatos);
            string nombre = objVariable.Nombre;
            string fechaCreacion = objVariable.FechaCreacion;
            string fkEmailUsuario= objVariable.FkEmailUsuario;
            string comandoSql = String.Format("INSERT INTO variable ( NOMBRE,FECHACREACION,FKEMAILUSUARIO) VALUES ('{0}','{1}','{2}')", nombre, fechaCreacion, fkEmailUsuario);
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
            int id = objVariable.Id;
            string nombre = objVariable.Nombre;
            string fechaCreacion = objVariable.FechaCreacion.ToString();
            string fkEmailUsuario = objVariable.FkEmailUsuario;
            string comandoSql = String.Format("UPDATE variable SET NOMBRE ='{0}',FECHACREACION='{1}',FKEMAILUSUARIO= '{2}'  WHERE ID= '{3}'", nombre,fechaCreacion,fkEmailUsuario, id);
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
            int id = objVariable.Id;
            string comandoSQL = String.Format("DELETE FROM Variable WHERE id='{0}'", id);
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