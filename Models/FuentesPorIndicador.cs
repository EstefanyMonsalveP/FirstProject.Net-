using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace primeraEntrega.Models
{
    public class FuentesPorIndicador
    {
        int fkIdFuente;
        int fkIndicador;
      

        public FuentesPorIndicador()
        {
            fkIdFuente = 0;
            fkIndicador = 0;
            
        }

        public FuentesPorIndicador(int fkIdFuente, int fkIndicador)
        {
            this.fkIdFuente = fkIdFuente;
            this.fkIndicador = fkIndicador;
            
        }
        public int FkIdFuente { get => fkIdFuente; set => fkIdFuente = value; }
        public int FkIndicador { get => fkIndicador; set => fkIndicador = value; }
      
    }
}