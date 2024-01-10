using primeraEntrega.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace primeraEntrega.Controllers
{
    public class ControlLiteral
    {
        Literal objLiteral;

        public ControlLiteral(Literal objLiteral)
        {
            this.objLiteral = objLiteral;
        }

        public Literal[] Listar()
        {
            Literal[] arregloLiteral = null;
            string baseDeDatos = "bd_indicadores_1330.mdf";
            ControlConexion objControlConexion = new ControlConexion(baseDeDatos);
            string comandoSQL = "SELECT * FROM literal";
            string msg = "ok";
            int i;
            objControlConexion.AbrirBD();
            DataSet objDataSet = objControlConexion.ejecutarConsultaSql(comandoSQL);
            try
            {
                if (objDataSet.Tables[0].Rows.Count > 0)
                {
                    i = 0;
                    arregloLiteral = new Literal[objDataSet.Tables[0].Rows.Count];
                    while (i < objDataSet.Tables[0].Rows.Count)
                    {
                        objLiteral= new Literal();
                        objLiteral.Id = objDataSet.Tables[0].Rows[i][0].ToString();
                        objLiteral.Descripcion = objDataSet.Tables[0].Rows[i][1].ToString();
                        objLiteral.FkIdArticulo = objDataSet.Tables[0].Rows[i][2].ToString();

                        arregloLiteral[i] = objLiteral;
                        i++;
                    }
                    objControlConexion.CerrarBD();
                }
            }
            catch (Exception objException)
            {
                msg = objException.Message;
            }
            return arregloLiteral;
        }
    }
}