using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace primeraEntrega.Models
{
    public class VariablesPorIndicador
    {
        int id;
        int fkIdVariable;
        int fkIdIndicador;
        float dato;
        string fkEmailUsuario;
        string fechaDato;

        public VariablesPorIndicador(int id, int fkIdVariable, int fkIdIndicador, float dato, string fkEmailUsuario, string fechaDato)
        {
            this.id = id;
            this.fkIdVariable = fkIdVariable;
            this.fkIdIndicador = fkIdIndicador;
            this.dato = dato;
            this.fkEmailUsuario = fkEmailUsuario;
            this.fechaDato = fechaDato;
        }

        public VariablesPorIndicador()
        {
            id = 0;
            fkIdVariable = 0;
            fkIdIndicador = 0;
            dato = 0;
            fkEmailUsuario = string.Empty;
            fechaDato = string.Empty;
        }

        public int Id { get => id; set => id = value; }
        public int FkIdVariable { get => fkIdVariable; set => fkIdVariable = value; }
        public int FkIdIndicador { get => fkIdIndicador; set => fkIdIndicador = value; }
        public float Dato { get => dato; set => dato = value; }
        public string FkEmailUsuario { get => fkEmailUsuario; set => fkEmailUsuario = value; }
        public string FechaDato { get => fechaDato; set => fechaDato = value; }
    }
}