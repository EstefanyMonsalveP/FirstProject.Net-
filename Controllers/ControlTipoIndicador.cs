using primeraEntrega.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace primeraEntrega.Controllers
{
    public class ControlTipoIndicador
    {
        TipoIndicador objTipoIndicador;

        public ControlTipoIndicador(TipoIndicador objTipoIndicador)
        {
            this.objTipoIndicador = objTipoIndicador;
        }

        public TipoIndicador[] Listar()
        {
            TipoIndicador[] arregloTipoIndicador = null;
            string baseDeDatos = "bd_indicadores_1330.mdf";
            ControlConexion objControlConexion = new ControlConexion(baseDeDatos);
            string comandoSQL = "SELECT * FROM tipoindicador";
            string msg = "ok";
            int i;
            objControlConexion.AbrirBD();
            DataSet objDataSet = objControlConexion.ejecutarConsultaSql(comandoSQL);
            try
            {
                if (objDataSet.Tables[0].Rows.Count > 0)
                {
                    i = 0;
                    arregloTipoIndicador = new TipoIndicador[objDataSet.Tables[0].Rows.Count];
                    while (i < objDataSet.Tables[0].Rows.Count)
                    {
                        objTipoIndicador = new TipoIndicador();
                        objTipoIndicador.Id = Convert.ToInt32(objDataSet.Tables[0].Rows[i][0].ToString());
                        objTipoIndicador.Nombre = objDataSet.Tables[0].Rows[i][1].ToString();

                        arregloTipoIndicador[i] = objTipoIndicador;
                        i++;
                    }
                    objControlConexion.CerrarBD();
                }
            }
            catch (Exception objException)
            {
                msg = objException.Message;
            }
            return arregloTipoIndicador;
        }


            public TipoIndicador Consultar()
            {
                string baseDeDatos = "bd_indicadores_1330.mdf";
                ControlConexion objControlConexion = new ControlConexion(baseDeDatos);
                int id = objTipoIndicador.Id;
                string comandoSql = String.Format("SELECT *FROM tipoindicador WHERE ID ={0}", id);
                string msj = "Ok";

                try
                {
                    objControlConexion.AbrirBD();
                    DataSet objDataSet = objControlConexion.ejecutarConsultaSql(comandoSql);
                    if (objDataSet.Tables[0].Rows.Count > 0)
                    {
                        
                        objTipoIndicador.Id = Convert.ToInt32(objDataSet.Tables[0].Rows[0][0]);
                        objTipoIndicador.Nombre = objDataSet.Tables[0].Rows[0][1].ToString();

                        objControlConexion.CerrarBD();
                    }

                }
                catch (Exception Ex)
                {

                    msj = Ex.Message;
                }
                return this.objTipoIndicador;
            }

            public string Guardar()
            {
                string baseDeDatos = "bd_indicadores_1330.mdf";
                ControlConexion objControlConexion = new ControlConexion(baseDeDatos);
                string nombre = objTipoIndicador.Nombre;
                string comandoSql = String.Format("INSERT INTO tipoindicador ( NOMBRE) VALUES ('{0}')", nombre);
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
                int id = objTipoIndicador.Id;
                string nombre = objTipoIndicador.Nombre;
                string comandoSql = String.Format("UPDATE tipoindicador SET NOMBRE ='{0}' WHERE ID= '{1}'", nombre, id);
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
                int id = objTipoIndicador.Id;
                string comandoSQL = String.Format("DELETE FROM tipoindicador WHERE id='{0}'", id);
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
       
      