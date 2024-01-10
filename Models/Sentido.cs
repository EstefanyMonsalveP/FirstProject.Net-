using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace primeraEntrega.Models
{
    public class Sentido
    {
        int id;
        string nombre;

        public Sentido()
        {
            id = 0;
            nombre = string.Empty;
        }

        public Sentido(int intId, string strNombre)
        {
            id = intId;
            nombre = strNombre;
        }

        public Sentido(string strNombre)
        {
            nombre = strNombre;
        }

        public int Id { get => id; set => id = value; }
        public string Nombre { get => nombre; set => nombre = value; }
    }
}