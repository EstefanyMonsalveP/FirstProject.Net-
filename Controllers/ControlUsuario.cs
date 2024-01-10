using primeraEntrega.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace primeraEntrega.Controllers
{
    public class ControlUsuario
    {
        Usuario objUsuario;
        public ControlUsuario(Usuario objUsuario)
        {
            this.objUsuario = objUsuario;
        }
        public Usuario[] Listar()
        {
            Usuario[] arregloUsuario = null;
            string baseDeDatos = "bd_indicadores_1330.mdf";
            ControlConexion objControlConexion = new ControlConexion(baseDeDatos);
            string comandoSQL = "SELECT * FROM usuario";
            string msg = "ok";
            int i;
            objControlConexion.AbrirBD();
            DataSet objDataSet = objControlConexion.ejecutarConsultaSql(comandoSQL);
            try
            {
                if (objDataSet.Tables[0].Rows.Count > 0)
                {
                    i = 0;
                    arregloUsuario = new Usuario[objDataSet.Tables[0].Rows.Count];
                    while (i < objDataSet.Tables[0].Rows.Count)
                    {
                        objUsuario = new Usuario();
                        objUsuario.Email = objDataSet.Tables[0].Rows[i][0].ToString();
                        objUsuario.Contrasena = objDataSet.Tables[0].Rows[i][1].ToString();

                        arregloUsuario[i] = objUsuario;
                        i++;
                    }
                    objControlConexion.CerrarBD();
                }
            }
            catch (Exception objException)
            {
                msg = objException.Message;
            }
            return arregloUsuario;
        }
        public bool ValidarIngreso()
        {
            bool validar = false;
            string ema = objUsuario.Email;
            string con = objUsuario.Contrasena;
            //string comamdoSql = "SELECT * FROM USUARIO WHERE email='"+ema+"' AND contrasena='"+con+"'";
            string comamdoSql = String.Format("SELECT * FROM USUARIO WHERE email='{0}' AND contrasena='{1}'", ema, con);
            ControlConexion objControlConexion = new ControlConexion("bd_indicadores_1330.mdf");
            objControlConexion.AbrirBD();
            DataSet objDataSet = objControlConexion.ejecutarConsultaSql(comamdoSql);
            if (objDataSet.Tables[0].Rows.Count > 0)
            {
                validar = true;
            }
            objControlConexion.CerrarBD();
            return validar;
        }
        public Usuario consultar()
        {
            string baseDeDatos = "bd_indicadores_1330.mdf";
            ControlConexion objControlConexion = new ControlConexion(baseDeDatos);
            string ema = objUsuario.Email;
            string comandoSQL = String.Format("SELECT * FROM usuario WHERE email='{0}'", ema);
            string msg = "ok";
            objControlConexion.AbrirBD();
            DataSet objDataSet = objControlConexion.ejecutarConsultaSql(comandoSQL);
            try
            {
                if (objDataSet.Tables[0].Rows.Count > 0)
                {
                    objUsuario.Contrasena = objDataSet.Tables[0].Rows[0][1].ToString();
                    objControlConexion.CerrarBD();
                }
            }
            catch (Exception objException)
            {
                msg = objException.Message;
            }
            return this.objUsuario;
        }
        public string Guardar()
        {
            string baseDeDatos = "bd_indicadores_1330.mdf";
            ControlConexion objControlConexion = new ControlConexion(baseDeDatos);
            string ema = objUsuario.Email;
            string con = objUsuario.Contrasena;
            string comandoSQL = String.Format("INSERT INTO usuario(email,contrasena) VALUES('{0}','{1}')", ema, con);
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
        public string Modificar()
        {
            string baseDeDatos = "bd_indicadores_1330.mdf";
            ControlConexion objControlConexion = new ControlConexion(baseDeDatos);
            string ema = objUsuario.Email;
            string con = objUsuario.Contrasena;
            string comandoSQL = String.Format("UPDATE usuario SET contrasena='{0}' WHERE email='{1}'", con, ema);
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
        public string Borrar()
        {
            string baseDeDatos = "bd_indicadores_1330.mdf";
            ControlConexion objControlConexion = new ControlConexion(baseDeDatos);
            string ema = objUsuario.Email;
            string comandoSQL = String.Format("DELETE FROM usuario WHERE email='{0}'", ema);
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
    }
}