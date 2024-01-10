using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace primeraEntrega.Models
{
    public class TipoIndicador
    {
        int id;
        string nombre;

        public TipoIndicador() 
        {
            id = 0;
            nombre = string.Empty;
        }

        public TipoIndicador(int intId, string strNombre)
        {
            id= intId;
            nombre=strNombre;
        }

        public TipoIndicador( string strNombre)
        {
            nombre = strNombre;
        }

        public int Id { get => id; set => id = value; }
        public string Nombre { get => nombre; set => nombre = value; }
    }


}