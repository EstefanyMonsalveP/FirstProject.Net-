using primeraEntrega.Models;
using System;
using System.Data;



namespace primeraEntrega.Controllers
{
    public class ControlUnidadMedicion
    {
        UnidadMedicion objUnidadMedicion;

        public ControlUnidadMedicion(UnidadMedicion objUnidadMedicion)
        {
            this.objUnidadMedicion = objUnidadMedicion;
        }


        public UnidadMedicion[] Listar()
        {
            UnidadMedicion[] arregloUnidadMedicion = null;
            string baseDeDatos = "bd_indicadores_1330.mdf";
            ControlConexion objControlConexion = new ControlConexion(baseDeDatos);
            string comandoSQL = "SELECT * FROM UnidadMedicion";
            string msg = "ok";
            int i;
            objControlConexion.AbrirBD();
            DataSet objDataSet = objControlConexion.ejecutarConsultaSql(comandoSQL);
            try
            {
                if (objDataSet.Tables[0].Rows.Count > 0)
                {
                    i = 0;
                    arregloUnidadMedicion = new UnidadMedicion[objDataSet.Tables[0].Rows.Count];
                    while (i < objDataSet.Tables[0].Rows.Count)
                    {
                        objUnidadMedicion = new UnidadMedicion();
                        objUnidadMedicion.Id = Convert.ToInt32(objDataSet.Tables[0].Rows[i][0].ToString());
                        objUnidadMedicion.Descripcion = objDataSet.Tables[0].Rows[i][1].ToString();

                        arregloUnidadMedicion[i] = objUnidadMedicion;
                        i++;
                    }
                    objControlConexion.CerrarBD();
                }
            }
            catch (Exception objException)
            {
                msg = objException.Message;
            }
            return arregloUnidadMedicion;
        }


        public UnidadMedicion Consultar()
        {
            string baseDeDatos = "bd_indicadores_1330.mdf";
            ControlConexion objControlConexion = new ControlConexion(baseDeDatos);
            int id = objUnidadMedicion.Id;
            string comandoSql = String.Format("SELECT *FROM UnidadMedicion WHERE ID ={0}", id);
            string msj = "Ok";

            try
            {
                objControlConexion.AbrirBD();
                DataSet objDataSet = objControlConexion.ejecutarConsultaSql(comandoSql);
                if (objDataSet.Tables[0].Rows.Count > 0)
                {

                    objUnidadMedicion.Id = Convert.ToInt32(objDataSet.Tables[0].Rows[0][0]);
                    objUnidadMedicion.Descripcion = objDataSet.Tables[0].Rows[0][1].ToString();

                    objControlConexion.CerrarBD();
                }

            }
            catch (Exception Ex)
            {

                msj = Ex.Message;
            }
            return this.objUnidadMedicion;
        }

        public string Guardar()
        {
            string baseDeDatos = "bd_indicadores_1330.mdf";
            ControlConexion objControlConexion = new ControlConexion(baseDeDatos);
            string Descripcion = objUnidadMedicion.Descripcion;
            string comandoSql = String.Format("INSERT INTO UnidadMedicion ( Descripcion) VALUES ('{0}')", Descripcion);
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
            int id = objUnidadMedicion.Id;
            string Descripcion = objUnidadMedicion.Descripcion;
            string comandoSql = String.Format("UPDATE UnidadMedicion SET Descripcion ='{0}' WHERE ID= '{1}'", Descripcion, id);
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
            int id = objUnidadMedicion.Id;
            string comandoSQL = String.Format("DELETE FROM UnidadMedicion WHERE id='{0}'", id);
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
