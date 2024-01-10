using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace primeraEntrega.Controllers
{
    public class ControlConexion
    {
        String cadenaConexion;
        SqlConnection objSqlConnection;

        public ControlConexion()
        {
            cadenaConexion = null;
            objSqlConnection = null;
        }

        public ControlConexion(String baseDeDatos)
        {
            this.cadenaConexion = @"Data Source = (LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\" + baseDeDatos + ";Integrated Security = True";
            objSqlConnection = new SqlConnection(cadenaConexion);
        }
        
        public String AbrirBD()
        {
            string msj = "Ok";
            try
            {
                objSqlConnection = new SqlConnection(cadenaConexion);
                objSqlConnection.Open();

            }
            catch (Exception Ex)
            {

                msj= Ex.Message;
            }

            return msj;
        }

        public String CerrarBD()
        {
            string msj = "Ok";
            try
            {
                objSqlConnection = new SqlConnection(cadenaConexion);
                objSqlConnection.Close();

            }
            catch (Exception Ex)
            {

                msj = Ex.Message; 
            }
            return msj;
        }

        public String EjecutarComandoSQL(string comandoSql)
        {
            string msj = "Ok";
            try
            {
                SqlCommand sqlComando = new SqlCommand(comandoSql, objSqlConnection);
                sqlComando.ExecuteNonQuery();


            }
            catch (Exception Ex)
            {

                msj = Ex.Message;
            }
            return msj;
        }

        public DataSet ejecutarConsultaSql(string comandoSql)
        {
            string msj = "Ok";
            DataSet objDataSet= new DataSet();

            try
            {
                SqlDataAdapter sqlDataAdap = new SqlDataAdapter(comandoSql, objSqlConnection);
                sqlDataAdap.Fill(objDataSet);
            }
            catch (Exception Ex)
            {

                msj = Ex.Message;
            }
            return objDataSet;
        }
    }
}