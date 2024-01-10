using primeraEntrega.Models;
using System;

using System.Data;


namespace primeraEntrega.Controllers
{
    public class ControlFuentesPorIndicador
    {
        FuentesPorIndicador objFuentesPorIndicador;
        public ControlFuentesPorIndicador(FuentesPorIndicador objFuentesPorIndicador)
        {
            this.objFuentesPorIndicador = objFuentesPorIndicador;
        }
        

        public string Guardar()
        {
            string baseDeDatos = "bd_indicadores_1330.mdf";
            ControlConexion objControlConexion = new ControlConexion(baseDeDatos);
            int fkIdFuente = objFuentesPorIndicador.FkIdFuente;
            int fkIdIndicador = objFuentesPorIndicador.FkIndicador;
            string comandoSQL = String.Format("INSERT INTO fuentesporindicador(fkidfuente,fkidindicador) VALUES('{0}','{1}')", fkIdFuente, fkIdIndicador);
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
        

        public string borrarFuentesIndicador(int fkIdIndicador)
        {
            string msg = "ok";
            try
            {
                string baseDeDatos = "bd_indicadores_1330.mdf";
                ControlConexion objControlConexion = new ControlConexion(baseDeDatos);
                string comandoSQL = "DELETE FROM fuentesporindicador WHERE fkidindicador='" + fkIdIndicador + "'";
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
        

        public Fuente[] Consultar(int fkIdIndicador)
        {
            Fuente[] arregloFuentes = null;
            
            string baseDeDatos = "bd_indicadores_1330.mdf";
            ControlConexion objControlConexion = new ControlConexion(baseDeDatos);
            string comandoSql = String.Format("SELECT dbo.fuente.id, dbo.fuente.nombre " +
            "FROM dbo.fuente INNER JOIN " +
            "dbo.fuentesporindicador ON dbo.fuentesporindicador.fkidfuente = dbo.fuente.id " +
            "WHERE fuentesporindicador.fkidindicador = '"+fkIdIndicador+"'");
            int i = 0;
            string msj = "Ok";
            try
            {
                objControlConexion.AbrirBD();
                DataSet objDataSet = objControlConexion.ejecutarConsultaSql(comandoSql);

                if (objDataSet.Tables[0].Rows.Count > 0)
                {
                    arregloFuentes = new Fuente[objDataSet.Tables[0].Rows.Count];

                    while (i < objDataSet.Tables[0].Rows.Count)
                    {
                        Fuente objFuente = new Fuente();
                        objFuente.Id = Convert.ToInt32(objDataSet.Tables[0].Rows[i][0].ToString());
                        objFuente.Nombre = objDataSet.Tables[0].Rows[i][1].ToString();

                        arregloFuentes[i] = objFuente;
                        i++;
                    }
                    objControlConexion.CerrarBD();
                }
            }
            catch (Exception Ex)
            {
                msj = Ex.Message;
            }
            return arregloFuentes;
        }
    }

}
