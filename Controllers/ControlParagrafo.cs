using primeraEntrega.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace primeraEntrega.Controllers
{
    public class ControlParagrafo
    {
        Paragrafo objParagrafo;

        public ControlParagrafo(Paragrafo objParagrafo)
        {
            this.objParagrafo = objParagrafo;
        }

        public Paragrafo[] Listar()
        {
            Paragrafo[] arregloParagrafo = null;
            string baseDeDatos = "bd_indicadores_1330.mdf";
            ControlConexion objControlConexion = new ControlConexion(baseDeDatos);
            string comandoSQL = "SELECT * FROM Paragrafo";
            string msg = "ok";
            int i;
            objControlConexion.AbrirBD();
            DataSet objDataSet = objControlConexion.ejecutarConsultaSql(comandoSQL);
            try
            {
                if (objDataSet.Tables[0].Rows.Count > 0)
                {
                    i = 0;
                    arregloParagrafo = new Paragrafo[objDataSet.Tables[0].Rows.Count];
                    while (i < objDataSet.Tables[0].Rows.Count)
                    {
                        objParagrafo = new Paragrafo();
                        objParagrafo.Id = objDataSet.Tables[0].Rows[i][0].ToString();
                        objParagrafo.Descripcion = objDataSet.Tables[0].Rows[i][1].ToString();
                        objParagrafo.FkIdArticulo = objDataSet.Tables[0].Rows[i][2].ToString();

                        arregloParagrafo[i] = objParagrafo;
                        i++;
                    }
                    objControlConexion.CerrarBD();
                }
            }
            catch (Exception objException)
            {
                msg = objException.Message;
            }
            return arregloParagrafo;
        }
    }
}