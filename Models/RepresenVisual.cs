using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace primeraEntrega.Models
{
    public class RepresenVisual
    {
        int id = 0;
        String nombre;


        public RepresenVisual()
        {
            this.id = 0;
            this.nombre = String.Empty;
        }

        public RepresenVisual(int intId, String strNombre)
        {
            id = intId;
            nombre = strNombre;
        }

        public RepresenVisual(string strNombre)
        {
            nombre = strNombre;
        }

        public int Id { get => id; set => id = value; }
        public string Nombre { get => nombre; set => nombre = value; }
    }
}