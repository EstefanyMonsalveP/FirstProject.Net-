using primeraEntrega.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace primeraEntrega.Controllers
{
    public class ControlSubseccion
    {
        Subseccion objSubseccion;

        public ControlSubseccion(Subseccion objSubseccion)
        {
            this.objSubseccion = objSubseccion;
        }

        public Subseccion[] Listar()
        {
            Subseccion[] arregloSubseccion = null;
            string baseDeDatos = "bd_indicadores_1330.mdf";
            ControlConexion objControlConexion = new ControlConexion(baseDeDatos);
            string comandoSQL = "SELECT * FROM subseccion";
            string msg = "ok";
            int i;
            objControlConexion.AbrirBD();
            DataSet objDataSet = objControlConexion.ejecutarConsultaSql(comandoSQL);
            try
            {
                if (objDataSet.Tables[0].Rows.Count > 0)
                {
                    i = 0;
                    arregloSubseccion = new Subseccion[objDataSet.Tables[0].Rows.Count];
                    while (i < objDataSet.Tables[0].Rows.Count)
                    {
                        objSubseccion = new Subseccion();
                        objSubseccion.Id = objDataSet.Tables[0].Rows[i][0].ToString();
                        objSubseccion.Nombre = objDataSet.Tables[0].Rows[i][1].ToString();                      

                        arregloSubseccion[i] = objSubseccion;
                        i++;
                    }
                    objControlConexion.CerrarBD();
                }
            }
            catch (Exception objException)
            {
                msg = objException.Message;
            }
            return arregloSubseccion;
        }
    }
}