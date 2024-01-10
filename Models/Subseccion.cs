using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace primeraEntrega.Models
{
    public class Subseccion
    {
        string id;
        string nombre;

        public string Id { get => id; set => id = value; }
        public string Nombre { get => nombre; set => nombre = value; }

        public Subseccion(string id, string nombre)
        {
            this.id = id;
            this.nombre = nombre;
        }

        public Subseccion()
        {
            id = string.Empty;
            nombre = string.Empty;
        }


    }
}