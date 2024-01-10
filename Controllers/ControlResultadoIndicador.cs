using primeraEntrega.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace primeraEntrega.Controllers
{
    public class ControlResultadoIndicador
    {
        ResultadoIndicador objResultadoIndicador;

        public ControlResultadoIndicador(ResultadoIndicador objResultadoIndicador)
        {
            this.objResultadoIndicador = objResultadoIndicador;
        }

        public ResultadoIndicador[] Listar()
        {
            ResultadoIndicador[] arregloResultadoIndicador = null;
            string baseDeDatos = "bd_indicadores_1330.mdf";
            ControlConexion objControlConexion = new ControlConexion(baseDeDatos);
            string comandoSQL = "SELECT * FROM ResultadoIndicador";
            string msg = "ok";
            int i;
            objControlConexion.AbrirBD();
            DataSet objDataSet = objControlConexion.ejecutarConsultaSql(comandoSQL);
            try
            {
                if (objDataSet.Tables[0].Rows.Count > 0)
                {
                    i = 0;
                    arregloResultadoIndicador = new ResultadoIndicador[objDataSet.Tables[0].Rows.Count];
                    while (i < objDataSet.Tables[0].Rows.Count)
                    {
                        objResultadoIndicador = new ResultadoIndicador();
                        objResultadoIndicador.Id = Convert.ToInt32(objDataSet.Tables[0].Rows[i][0].ToString());
                        objResultadoIndicador.Resultado = Convert.ToDouble(objDataSet.Tables[0].Rows[i][1].ToString());
                        objResultadoIndicador.FechaCalculo = objDataSet.Tables[0].Rows[i][2].ToString();
                        objResultadoIndicador.FkIdIndicador = Convert.ToInt32(objDataSet.Tables[0].Rows[i][3].ToString());

                        arregloResultadoIndicador[i] = objResultadoIndicador;
                        i++;
                    }
                    objControlConexion.CerrarBD();
                }
            }
            catch (Exception objException)
            {
                msg = objException.Message;
            }
            return arregloResultadoIndicador;
        }


        public ResultadoIndicador Consultar()
        {
            string baseDeDatos = "bd_indicadores_1330.mdf";
            ControlConexion objControlConexion = new ControlConexion(baseDeDatos);
            int id = objResultadoIndicador.Id;
            string comandoSql = String.Format("SELECT *FROM ResultadoIndicador WHERE ID ={0}", id);
            string msj = "Ok";

            try
            {
                objControlConexion.AbrirBD();
                DataSet objDataSet = objControlConexion.ejecutarConsultaSql(comandoSql);
                if (objDataSet.Tables[0].Rows.Count > 0)
                {

                    objResultadoIndicador.Id = Convert.ToInt32(objDataSet.Tables[0].Rows[0][0]);
                    objResultadoIndicador.Resultado = Convert.ToDouble(objDataSet.Tables[0].Rows[0][1].ToString());
                    objResultadoIndicador.FechaCalculo = objDataSet.Tables[0].Rows[0][2].ToString();
                    objResultadoIndicador.FkIdIndicador = Convert.ToInt32(objDataSet.Tables[0].Rows[0][3].ToString());

                    objControlConexion.CerrarBD();
                }

            }
            catch (Exception Ex)
            {

                msj = Ex.Message;
            }
            return this.objResultadoIndicador;
        }

        public string Guardar()
        {
            string baseDeDatos = "bd_indicadores_1330.mdf";
            ControlConexion objControlConexion = new ControlConexion(baseDeDatos);
            double resultado = Convert.ToDouble(objResultadoIndicador.Resultado);
            string fechaCalculo = objResultadoIndicador.FechaCalculo;
            int fkIdIndicador = objResultadoIndicador.FkIdIndicador;
            string comandoSql = String.Format("INSERT INTO ResultadoIndicador ( resultado,fechacalculo,fkidindicador) VALUES ('{0}','{1}','{2}')", resultado,fechaCalculo,fkIdIndicador);
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
            int id = objResultadoIndicador.Id;
            double resultado = Convert.ToDouble(objResultadoIndicador.Resultado);
            string fechaCalculo = objResultadoIndicador.FechaCalculo;
            int fkIdIndicador = objResultadoIndicador.FkIdIndicador;
            string comandoSql = String.Format("UPDATE ResultadoIndicador SET resultado ='{0}',fechacalculo ='{1}',fkidindicador ='{2}' WHERE ID= '{3}'", resultado,fechaCalculo,fkIdIndicador, id);
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
            int id = objResultadoIndicador.Id;
            string comandoSQL = String.Format("DELETE FROM ResultadoIndicador WHERE id='{0}'", id);
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