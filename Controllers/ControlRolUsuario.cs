using primeraEntrega.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace primeraEntrega.Controllers
{
    public class ControlRolUsuario
    {
        RolUsuario objRolUsuario;

        public ControlRolUsuario(RolUsuario objRolUsuario)
        {
            this.objRolUsuario = objRolUsuario;
        }
        public string guardar()
        {
            string baseDeDatos = "bd_indicadores_1330.mdf";
            ControlConexion objControlConexion = new ControlConexion(baseDeDatos);
            string fkemail = objRolUsuario.FkEmail;
            int fkidrol = objRolUsuario.FkIdRol;
            string comandoSQL = String.Format("INSERT INTO rol_usuario(fkemail,fkidrol) VALUES('{0}','{1}')", fkemail, fkidrol);
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

        public Rol[] buscarIdNombrePorEmail(string fkemail)
        {
            Rol[] arregloRol = null;
            string baseDeDatos = "bd_indicadores_1330.mdf";
            ControlConexion objControlConexion = new ControlConexion(baseDeDatos);
            //string comandoSQL = "SELECT rol_usuario.fkidrol,rol.nombre " +
            string comandoSQL = "SELECT rol.id,rol.nombre " +
                "FROM rol INNER JOIN rol_usuario " +
                "ON rol_usuario.fkidrol= rol.id " +
                "WHERE rol_usuario.fkemail='" + fkemail + "'";
            string msg = "ok";
            int i;
            objControlConexion.AbrirBD();
            DataSet objDataSet = objControlConexion.ejecutarConsultaSql(comandoSQL);
            try
            {
                if (objDataSet.Tables[0].Rows.Count > 0)
                {
                    i = 0;
                    arregloRol = new Rol[objDataSet.Tables[0].Rows.Count];
                    while (i < objDataSet.Tables[0].Rows.Count)
                    {
                        Rol objRol = new Rol();
                        objRol.Id = Convert.ToInt32(objDataSet.Tables[0].Rows[i][0].ToString());
                        objRol.Nombre = objDataSet.Tables[0].Rows[i][1].ToString();

                        arregloRol[i] = objRol;
                        i++;
                    }
                    objControlConexion.CerrarBD();
                }
            }
            catch (Exception objException)
            {
                msg = objException.Message;
            }
            return arregloRol;
        }

        public string borrarRolesDelUsuario(string fkemail)
        {
            string msg = "ok";
            try
            {
                string baseDeDatos = "bd_indicadores_1330.mdf";
                ControlConexion objControlConexion = new ControlConexion(baseDeDatos);
                string comandoSQL = "DELETE FROM rol_usuario WHERE fkemail='" + fkemail + "'";
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