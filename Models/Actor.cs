using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace primeraEntrega.Models
{
    public class Actor
    {
        string id;
        string nombre;
        int fkIdTipoActor;

        public string Id { get => id; set => id = value; }
        public string Nombre { get => nombre; set => nombre = value; }
        public int FkIdTipoActor { get => fkIdTipoActor; set => fkIdTipoActor = value; }

        public Actor(string id, string nombre, int fkIdTipoActor)
        {
            this.id = id;
            this.nombre = nombre;
            this.fkIdTipoActor = fkIdTipoActor;
        }

        public Actor()
        {
            id = string.Empty;
            nombre = string.Empty;
            fkIdTipoActor = 0;
        }

        public Actor(string id)
        {
            this.id = id;
        }
    }
}