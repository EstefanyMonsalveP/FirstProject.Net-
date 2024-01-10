using System;
using System.Collections.Generic;
using System.Deployment.Internal;
using System.Linq;
using System.Web;

namespace primeraEntrega.Models
{
    public class Variable
    {
        int id;
        string nombre;
        string fechaCreacion;
        string fkEmailUsuario;

        public Variable(int id, string nombre, string fechaCreacion, string fkEmailUsuario)
        {
            this.id = id;
            this.nombre = nombre;
            this.fechaCreacion = fechaCreacion;
            this.fkEmailUsuario = fkEmailUsuario;
        }

        public Variable()
        {
            id = 0;
            nombre = string.Empty;
            fechaCreacion = string.Empty;
            fkEmailUsuario = string.Empty;
        }

        public Variable(int id)
        {
            this.id = id;
        }

        public int Id { get => id; set => id = value; }
        public string Nombre { get => nombre; set => nombre = value; }
        public string FechaCreacion { get => fechaCreacion; set => fechaCreacion = value; }
        public string FkEmailUsuario { get => fkEmailUsuario; set => fkEmailUsuario = value; }
    }
}