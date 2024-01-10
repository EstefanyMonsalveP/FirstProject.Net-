using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace primeraEntrega.Models
{
    public class Literal
    {
        string id;
        string descripcion;
        string fkIdArticulo;

        public string Id { get => id; set => id = value; }
        public string Descripcion { get => descripcion; set => descripcion = value; }
        public string FkIdArticulo { get => fkIdArticulo; set => fkIdArticulo = value; }

        public Literal(string id, string descripcion, string fkIdArticulo)
        {
            this.id = id;
            this.descripcion = descripcion;
            this.fkIdArticulo = fkIdArticulo;
        }

        public Literal()
        {
            id = string.Empty;
            descripcion = string.Empty;
            fkIdArticulo = string.Empty;
        }
    }
}