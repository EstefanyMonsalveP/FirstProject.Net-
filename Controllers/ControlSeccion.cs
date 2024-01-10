using primeraEntrega.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace primeraEntrega.Controllers
{
    public class ControlSeccion
    {
        Seccion objSeccion;

        public ControlSeccion(Seccion objSeccion)
        {
            this.objSeccion = objSeccion;
        }

        public Seccion[] Listar()
        {
            Seccion[] arregloSeccion = null;
            string baseDeDatos = "bd_indicadores_1330.mdf";
            ControlConexion objControlConexion = new ControlConexion(baseDeDatos);
            string comandoSQL = "SELECT * FROM Seccion";
            string msg = "ok";
            int i;
            objControlConexion.AbrirBD();
            DataSet objDataSet = objControlConexion.ejecutarConsultaSql(comandoSQL);
            try
            {
                if (objDataSet.Tables[0].Rows.Count > 0)
                {
                    i = 0;
                    arregloSeccion = new Seccion[objDataSet.Tables[0].Rows.Count];
                    while (i < objDataSet.Tables[0].Rows.Count)
                    {
                        objSeccion = new Seccion();
                        objSeccion.Id = objDataSet.Tables[0].Rows[i][0].ToString();
                        objSeccion.Nombre = objDataSet.Tables[0].Rows[i][1].ToString();

                        arregloSeccion[i] = objSeccion;
                        i++;
                    }
                    objControlConexion.CerrarBD();
                }
            }
            catch (Exception objException)
            {
                msg = objException.Message;
            }
            return arregloSeccion;
        }
    }
}