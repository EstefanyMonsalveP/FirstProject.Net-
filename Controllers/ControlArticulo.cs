using primeraEntrega.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace primeraEntrega.Controllers
{
    public class ControlArticulo
    {
        Articulo objArticulo;

        public ControlArticulo(Articulo objArticulo)
        {
            this.objArticulo = objArticulo;
        }

        public Articulo[] Listar()
        {
            Articulo[] arregloArticulo = null;
            string baseDeDatos = "bd_indicadores_1330.mdf";
            ControlConexion objControlConexion = new ControlConexion(baseDeDatos);
            string comandoSQL = "SELECT * FROM articulo";
            string msg = "ok";
            int i;
            objControlConexion.AbrirBD();
            DataSet objDataSet = objControlConexion.ejecutarConsultaSql(comandoSQL);
            try
            {
                if (objDataSet.Tables[0].Rows.Count > 0)
                {
                    i = 0;
                    arregloArticulo = new Articulo[objDataSet.Tables[0].Rows.Count];
                    while (i < objDataSet.Tables[0].Rows.Count)
                    {
                        objArticulo = new Articulo();
                        objArticulo.Id = objDataSet.Tables[0].Rows[i][0].ToString();
                        objArticulo.Nombre = objDataSet.Tables[0].Rows[i][1].ToString();
                        objArticulo.Descripcion = objDataSet.Tables[0].Rows[i][2].ToString();
                        objArticulo.FkIdSeccion = objDataSet.Tables[0].Rows[i][3].ToString();
                        objArticulo.FkIdSubSeccion = objDataSet.Tables[0].Rows[i][4].ToString();

                        arregloArticulo[i] = objArticulo;
                        i++;
                    }
                    objControlConexion.CerrarBD();
                }
            }
            catch (Exception objException)
            {
                msg = objException.Message;
            }
            return arregloArticulo;
        }
    }
}