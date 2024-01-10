using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace primeraEntrega.Models
{
    public class TipoActor
    {
        int id = 0;
        string nombre;


        public TipoActor()
        {
            this.id = 0;
            this.nombre = String.Empty;
        }

        public TipoActor(int intId, String strNombre)
        {
            id = intId;
            nombre = strNombre;
        }

        public TipoActor(int id)
        {
            this.id = id;
        }

        public TipoActor(string nombre)
        {
            this.Nombre = nombre;
        }

        public int Id { get => id; set => id = value; }
        public string Nombre { get => nombre; set => nombre = value; }
    }
}