using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace primeraEntrega.Models
{
    public class Seccion
    {
        string id;
        string nombre;

        public string Id { get => id; set => id = value; }
        public string Nombre { get => nombre; set => nombre = value; }

        public Seccion(string id, string nombre)
        {
            this.id = id;
            this.nombre = nombre;
        }

        public Seccion()
        {
            id = string.Empty;
            nombre = string.Empty;
        }
    }
}