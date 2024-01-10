using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace primeraEntrega.Models
{
    public class ResultadoIndicador
    {
        int id;
        double resultado;
        string fechaCalculo;
        int fkIdIndicador;

        public ResultadoIndicador(int id, double resultado, string fechaCalculo, int fkIdIndicador)
        {
            this.id = id;
            this.resultado = resultado;
            this.fechaCalculo = fechaCalculo;
            this.fkIdIndicador = fkIdIndicador;
        }

        public ResultadoIndicador()
        {
            id = 0;
            resultado = 0;
            fechaCalculo = string.Empty;
            fkIdIndicador = 0;
        }

        public ResultadoIndicador(int id)
        {
            this.id = id;
        }

        public int Id { get => id; set => id = value; }
        public double Resultado { get => resultado; set => resultado = value; }
        public string FechaCalculo { get => fechaCalculo; set => fechaCalculo = value; }
        public int FkIdIndicador { get => fkIdIndicador; set => fkIdIndicador = value; }
    }
}