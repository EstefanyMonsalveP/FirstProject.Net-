using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace primeraEntrega.Models
{
    public class Numeral
    {
        string id;
        string descripcion;
        string fkIdLiteral;

        public string Id { get => id; set => id = value; }
        public string Descripcion { get => descripcion; set => descripcion = value; }
        public string FkIdLiteral { get => fkIdLiteral; set => fkIdLiteral = value; }

        public Numeral(string id, string descripcion, string fkIdLiteral)
        {
            this.id = id;
            this.descripcion = descripcion;
            this.fkIdLiteral = fkIdLiteral;
        }

        public Numeral()
        {
            id = string.Empty;
            descripcion = string.Empty;
            fkIdLiteral = string.Empty;
        }
    }
}