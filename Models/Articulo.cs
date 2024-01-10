using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web;

namespace primeraEntrega.Models
{
    public class Articulo
    {
        string id;
        string nombre;
        string descripcion;
        string fkIdSeccion;
        string fkIdSubSeccion;

        public string Id { get => id; set => id = value; }
        public string Nombre { get => nombre; set => nombre = value; }
        public string Descripcion { get => descripcion; set => descripcion = value; }
        public string FkIdSeccion { get => fkIdSeccion; set => fkIdSeccion = value; }
        public string FkIdSubSeccion { get => fkIdSubSeccion; set => fkIdSubSeccion = value; }

        public Articulo(string id, string nombre, string descripcion, string fkIdSeccion, string fkIdSubSeccion)
        {
            this.id = id;
            this.nombre = nombre;
            this.descripcion = descripcion;
            this.fkIdSeccion = fkIdSeccion;
            this.fkIdSubSeccion = fkIdSubSeccion;
        }

        public Articulo()
        {
            id = string.Empty;
            nombre = string.Empty;
            descripcion = string.Empty;
            fkIdSeccion = string.Empty;
            fkIdSubSeccion = string.Empty;
        }
    }
}