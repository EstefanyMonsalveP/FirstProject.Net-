using primeraEntrega.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace primeraEntrega.Controllers
{
    public class ControlNumeral
    {
        Numeral objNumeral;

        public ControlNumeral(Numeral objNumeral)
        {
            this.objNumeral = objNumeral;
        }

        public Numeral[] Listar()
        {
            Numeral[] arregloNumeral = null;
            string baseDeDatos = "bd_indicadores_1330.mdf";
            ControlConexion objControlConexion = new ControlConexion(baseDeDatos);
            string comandoSQL = "SELECT * FROM numeral";
            string msg = "ok";
            int i;
            objControlConexion.AbrirBD();
            DataSet objDataSet = objControlConexion.ejecutarConsultaSql(comandoSQL);
            try
            {
                if (objDataSet.Tables[0].Rows.Count > 0)
                {
                    i = 0;
                    arregloNumeral = new Numeral[objDataSet.Tables[0].Rows.Count];
                    while (i < objDataSet.Tables[0].Rows.Count)
                    {
                        objNumeral = new Numeral();
                        objNumeral.Id = objDataSet.Tables[0].Rows[i][0].ToString();
                        objNumeral.Descripcion = objDataSet.Tables[0].Rows[i][1].ToString();
                        objNumeral.FkIdLiteral = objDataSet.Tables[0].Rows[i][2].ToString();

                        arregloNumeral[i] = objNumeral;
                        i++;
                    }
                    objControlConexion.CerrarBD();
                }
            }
            catch (Exception objException)
            {
                msg = objException.Message;
            }
            return arregloNumeral;
        }
    }
}