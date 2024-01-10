using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace primeraEntrega.Models
{
    public class UnidadMedicion
    {
        int id = 0;
        String descripcion;


        public UnidadMedicion()
        {
            this.id = 0;
            this.descripcion = String.Empty;
        }

        public UnidadMedicion(int intId, String strDescripcion)
        {
            id = intId;
            descripcion = strDescripcion;
        }

        public UnidadMedicion(string strDescripcion)
        {
            descripcion = strDescripcion;
        }

        public int Id { get => id; set => id = value; }
        public string Descripcion { get => descripcion; set => descripcion = value; }
    }
}