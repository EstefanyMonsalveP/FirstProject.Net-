using primeraEntrega.Models;
using System;
using System.Data;


namespace primeraEntrega.Controllers
{
    public class ControlIndicador
    {
        Indicador objIndicador;

        public ControlIndicador(Indicador objIndicador)
        {
            this.objIndicador = objIndicador;
        }


        public Indicador[] Listar()
        {
            Indicador[] arregloIndicador = null;
            string baseDeDatos = "bd_indicadores_1330.mdf";
            ControlConexion objControlConexion = new ControlConexion(baseDeDatos);
            string comandoSQL = "SELECT * FROM Indicador";
            string msg = "ok";
            int i;
            objControlConexion.AbrirBD();
            DataSet objDataSet = objControlConexion.ejecutarConsultaSql(comandoSQL);
            try
            {
                if (objDataSet.Tables[0].Rows.Count > 0)
                {
                    i = 0;
                    arregloIndicador = new Indicador[objDataSet.Tables[0].Rows.Count];
                    while (i < objDataSet.Tables[0].Rows.Count)
                    {
                        objIndicador = new Indicador();
                        objIndicador.Id = Convert.ToInt32(objDataSet.Tables[0].Rows[i][0].ToString());
                        objIndicador.Codigo = objDataSet.Tables[0].Rows[i][1].ToString();
                        objIndicador.Nombre = objDataSet.Tables[0].Rows[i][2].ToString();
                        objIndicador.Objetivo = objDataSet.Tables[0].Rows[i][3].ToString();
                        objIndicador.Alcance = objDataSet.Tables[0].Rows[i][4].ToString();
                        objIndicador.Formula = objDataSet.Tables[0].Rows[i][5].ToString();
                        objIndicador.FkIdTipoIndicador = Convert.ToInt32(objDataSet.Tables[0].Rows[i][6].ToString());
                        objIndicador.FkIdUnidadMedicion = Convert.ToInt32(objDataSet.Tables[0].Rows[i][7].ToString());
                        objIndicador.Meta = objDataSet.Tables[0].Rows[i][8].ToString(); ;
                        objIndicador.FkIdSentido = Convert.ToInt32(objDataSet.Tables[0].Rows[i][9].ToString());
                        objIndicador.FkIdFrecuencia = Convert.ToInt32(objDataSet.Tables[0].Rows[i][10].ToString());
                        objIndicador.FkIdArticulo = objDataSet.Tables[0].Rows[i][11].ToString();
                        objIndicador.FkIdLiteral = objDataSet.Tables[0].Rows[i][12].ToString();
                        objIndicador.FkIdNumeral = objDataSet.Tables[0].Rows[i][13].ToString();
                        objIndicador.FkIdParagrafo = objDataSet.Tables[0].Rows[i][14].ToString();


                        arregloIndicador[i] = objIndicador;
                        i++;
                    }
                    objControlConexion.CerrarBD();
                }
            }
            catch (Exception objException)
            {
                msg = objException.Message;
            }
            return arregloIndicador;
        }


        public Indicador Consultar()
        {

            string baseDeDatos = "bd_indicadores_1330.mdf";
            ControlConexion objControlConexion = new ControlConexion(baseDeDatos);
            int id = objIndicador.Id;
            string comandoSql = String.Format("SELECT I.id AS IdIndicador, I.codigo, I.nombre AS NombreIndicador, I.objetivo, I.alcance, I.formula, I.meta, " +
        "FkFrecuencia.id AS IdFrecuencia, FkFrecuencia.descripcion AS NombreFrecuencia, FkSentido.id AS IdSentido, FkSentido.nombre AS NombreSentido, " +
        "FkTipoIndicador.id AS IdTipoIndicador, FkTipoIndicador.nombre AS NombreTipoIndicador, " +
        "U.id AS IdUnidadMedicion, U.descripcion AS NombreUnidadMedicion, A.id AS IdArticulo, A.nombre AS NombreArticulo, " +
        "L.id AS IdLiteral, L.descripcion AS NombreLiteral, N.id AS IdNumeral, N.descripcion AS NombreNumeral, " +
        "P.id AS IdParagrafo, P.descripcion AS NombreParagrafo " +
        "FROM dbo.indicador AS I LEFT JOIN dbo.frecuencia AS FkFrecuencia ON I.fkidfrecuencia = FkFrecuencia.id " +
        "LEFT JOIN dbo.sentido AS FkSentido ON I.fkidsentido = FkSentido.id " +
        "LEFT JOIN dbo.tipoindicador AS FkTipoIndicador ON I.fkidtipoindicador = FkTipoIndicador.id " +
        "LEFT JOIN dbo.unidadmedicion AS U ON I.fkidunidadmedicion = U.id " +
        "LEFT JOIN dbo.articulo AS A ON I.fkidarticulo = A.id " +
        "LEFT JOIN dbo.literal AS L ON I.fkidliteral = L.id " +
        "LEFT JOIN dbo.numeral AS N ON I.fkidnumeral = N.id " +
        "LEFT JOIN dbo.paragrafo AS P ON I.fkidparagrafo = P.id " +
        "WHERE I.id = {0}", id);

            string msj = "Ok";

            try
            {
                objControlConexion.AbrirBD();
                DataSet objDataSet = objControlConexion.ejecutarConsultaSql(comandoSql);
                if (objDataSet.Tables[0].Rows.Count > 0)
                {
                    DataRow row = objDataSet.Tables[0].Rows[0]; // Obtén la primera fila

                    objIndicador.Id = Convert.ToInt32(row["IdIndicador"]);
                    objIndicador.Codigo = row["codigo"].ToString();
                    objIndicador.Nombre = row["NombreIndicador"].ToString();
                    objIndicador.Objetivo = row["objetivo"].ToString();
                    objIndicador.Alcance = row["alcance"].ToString();
                    objIndicador.Formula = row["formula"].ToString();
                    objIndicador.Meta = row["meta"].ToString();
                    objIndicador.FkIdFrecuencia = Convert.ToInt32(row["IdFrecuencia"]);
                    objIndicador.FkIdSentido = Convert.ToInt32(row["IdSentido"]);
                    objIndicador.FkIdTipoIndicador = Convert.ToInt32(row["IdTipoIndicador"]);
                    objIndicador.FkIdUnidadMedicion = Convert.ToInt32(row["IdUnidadMedicion"]);
                    objIndicador.FkIdArticulo = row["IdArticulo"].ToString();
                    objIndicador.FkIdLiteral = row["IdLiteral"].ToString();
                    objIndicador.FkIdNumeral = row["IdNumeral"].ToString();
                    objIndicador.FkIdParagrafo = row["IdParagrafo"].ToString();

                    objControlConexion.CerrarBD();
                }
            }
            catch (Exception Ex)
            {
                msj = Ex.Message;
            }
            return objIndicador;
        }


        public string Guardar()
        {
            string baseDeDatos = "bd_indicadores_1330.mdf";
            ControlConexion objControlConexion = new ControlConexion(baseDeDatos);
            string codigo = objIndicador.Codigo;
            string nombre = objIndicador.Nombre;
            string objetivo = objIndicador.Objetivo;
            string alcance = objIndicador.Alcance;
            string formula = objIndicador.Formula;
            int fkIdTipoIndicador = objIndicador.FkIdTipoIndicador;
            int fkIdUnidadMedicion = objIndicador.FkIdUnidadMedicion;
            string meta = objIndicador.Meta;
            int fkIdSentido = objIndicador.FkIdSentido;
            int fkIdFrecuencia = objIndicador.FkIdFrecuencia;
            string fkIdArticulo = objIndicador.FkIdArticulo;
            string fkIdLiteral = objIndicador.FkIdLiteral;
            string fkIdNumeral = objIndicador.FkIdNumeral;
            string fkIdParagrafo = objIndicador.FkIdParagrafo;
            string comandoSQL = String.Format("INSERT INTO indicador(codigo,nombre,objetivo,alcance,formula,fkIdTipoIndicador,fkIdUnidadMedicion,meta, fkIdSentido,fkIdFrecuencia,fkIdArticulo,fkIdLiteral,fkIdNumeral,fkIdParagrafo) VALUES('{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}','{8}','{9}','{10}','{11}','{12}','{13}')",
            codigo, nombre, objetivo, alcance, formula, fkIdTipoIndicador, fkIdUnidadMedicion, meta, fkIdSentido, fkIdFrecuencia, fkIdArticulo, fkIdLiteral, fkIdNumeral, fkIdParagrafo);
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
    

        public string Modificar()
        {
            string baseDeDatos = "bd_indicadores_1330.mdf";
            ControlConexion objControlConexion = new ControlConexion(baseDeDatos);
            int id = objIndicador.Id;
            string codigo = objIndicador.Codigo;
            string nombre = objIndicador.Nombre;
            string objetivo = objIndicador.Objetivo;
            string alcance = objIndicador.Alcance;
            string formula = objIndicador.Formula;
            int fkIdTipoIndicador = objIndicador.FkIdTipoIndicador;
            int fkIdUnidadMedicion = objIndicador.FkIdUnidadMedicion;
            string meta = objIndicador.Meta;
            int fkIdSentido = objIndicador.FkIdSentido;
            int fkIdFrecuencia = objIndicador.FkIdFrecuencia;
            string fkIdArticulo = objIndicador.FkIdArticulo;
            string fkIdLiteral = objIndicador.FkIdLiteral;
            string fkIdNumeral = objIndicador.FkIdNumeral;
            string fkIdParagrafo = objIndicador.FkIdParagrafo;
            string comandoSql = string.Format("UPDATE Indicador SET CODIGO = '{0}', NOMBRE = '{1}', OBJETIVO = '{2}', ALCANCE = '{3}', FORMULA = '{4}', FKIDTIPOINDICADOR = {5}," +
            "FKIDUNIDADMEDICION = {6}, META = '{7}', FKIDSENTIDO = {8}, FKIDFRECUENCIA = {9}, FKIDARTICULO = '{10}', FKIDLITERAL = '{11}'," +
            "FKIDNUMERAL = '{12}', FKIDPARAGRAFO = '{13}' WHERE ID = {14}",
            codigo, nombre, objetivo, alcance, formula, fkIdTipoIndicador, fkIdUnidadMedicion, meta, fkIdSentido, fkIdFrecuencia, fkIdArticulo, fkIdLiteral, fkIdNumeral, fkIdParagrafo, id);

            string msj = "Ok";


            try
            {
                objControlConexion.AbrirBD();
                objControlConexion.EjecutarComandoSQL(comandoSql);
                objControlConexion.CerrarBD();

            }
            catch (Exception Ex)
            {

                msj = Ex.Message;
            }
            return msj;
        }

        public string Borrar()
        {
            string baseDeDatos = "bd_indicadores_1330.mdf";
            ControlConexion objControlConexion = new ControlConexion(baseDeDatos);
            int id = objIndicador.Id;
            string comandoSQL = String.Format("DELETE FROM Indicador WHERE id='{0}'", id);
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
    }
}