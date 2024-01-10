using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace primeraEntrega.Models
{
    public class RepresenVisualIndicador
    {
        int fkIdIndicador;
        int fkIdRepresenVisual;

        public int FkIdIndicador { get => fkIdIndicador; set => fkIdIndicador = value; }
        public int FkIdRepresenVisual { get => fkIdRepresenVisual; set => fkIdRepresenVisual = value; }

        public RepresenVisualIndicador(int fkIdIndicador, int fkIdRepresenVisual)
        {
            this.fkIdIndicador = fkIdIndicador;
            this.fkIdRepresenVisual = fkIdRepresenVisual;
        }

        public RepresenVisualIndicador()
        {
            fkIdIndicador = 0;
            fkIdRepresenVisual =0;
        }
    }
}