using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace primeraEntrega.Models
{
    public class ResponsableIndicador
    {
        string fkIdResponsable;
        int fkIdIndicador;
        string fechaAsignacion;

        public string FkIdResponsable { get => fkIdResponsable; set => fkIdResponsable = value; }
        public int FkIdIndicador { get => fkIdIndicador; set => fkIdIndicador = value; }
        public string FechaAsignacion { get => fechaAsignacion; set => fechaAsignacion = value; }

        public ResponsableIndicador(string fkIdResponsable, int fkIdIndicador, string fechaAsignacion)
        {
            this.fkIdResponsable = fkIdResponsable;
            this.fkIdIndicador = fkIdIndicador;
            this.fechaAsignacion = fechaAsignacion;
        }

        public ResponsableIndicador()
        {
            fkIdResponsable = string.Empty;
            fkIdIndicador = 0;
            fechaAsignacion = string.Empty;
        }
    }
}