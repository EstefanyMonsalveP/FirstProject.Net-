using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace primeraEntrega.Models
{
    public class Indicador
    {
        int id;
        string codigo;
        string nombre;
        string objetivo;
        string alcance;
        string formula;
        int fkIdTipoIndicador;
        int fkIdUnidadMedicion;
        string meta;
        int fkIdSentido;
        int fkIdFrecuencia;
        string fkIdArticulo;
        string fkIdLiteral;
        string fkIdNumeral;
        string fkIdParagrafo;

        public Indicador(int id, string codigo, string nombre, string objetivo, string alcance, string formula, int fkIdTipoIndicador, int fkIdUnidadMedicion, string meta, int fkIdSentido, int fkIdFrecuencia, string fkIdArticulo, string fkIdLiteral, string fkIdNumeral, string fkIdParagrafo)
        {
            this.id = id;
            this.codigo = codigo;
            this.nombre = nombre;
            this.objetivo = objetivo;
            this.alcance = alcance;
            this.formula = formula;
            this.fkIdTipoIndicador = fkIdTipoIndicador;
            this.fkIdUnidadMedicion = fkIdUnidadMedicion;
            this.meta = meta;
            this.fkIdSentido = fkIdSentido;
            this.fkIdFrecuencia = fkIdFrecuencia;
            this.fkIdArticulo = fkIdArticulo;
            this.fkIdLiteral = fkIdLiteral;
            this.fkIdNumeral = fkIdNumeral;
            this.fkIdParagrafo = fkIdParagrafo;
        }

        public Indicador()
        {
            id = 0;
            codigo = string.Empty;
            nombre = string.Empty;
            objetivo = string.Empty;
            alcance=string.Empty;
            formula = string.Empty;
            fkIdTipoIndicador = 0;
            fkIdUnidadMedicion = 0;
            meta = string.Empty;
            fkIdSentido = 0;
            fkIdFrecuencia= 0;
            fkIdArticulo = string.Empty;
            fkIdLiteral = string.Empty;
            fkIdNumeral = string.Empty;
            fkIdParagrafo = string.Empty;
        }

        public Indicador (int id)
        {
            this.id = id;
        }

        public int Id { get => id; set => id = value; }
        public string Codigo { get => codigo; set => codigo = value; }
        public string Nombre { get => nombre; set => nombre = value; }
        public string Objetivo { get => objetivo; set => objetivo = value; }
        public string Alcance { get => alcance; set => alcance = value; }
        public string Formula { get => formula; set => formula = value; }
        public int FkIdTipoIndicador { get => fkIdTipoIndicador; set => fkIdTipoIndicador = value; }
        public int FkIdUnidadMedicion { get => fkIdUnidadMedicion; set => fkIdUnidadMedicion = value; }
        public string Meta { get => meta; set => meta = value; }
        public int FkIdSentido { get => fkIdSentido; set => fkIdSentido = value; }
        public int FkIdFrecuencia { get => fkIdFrecuencia; set => fkIdFrecuencia = value; }
        public string FkIdArticulo { get => fkIdArticulo; set => fkIdArticulo = value; }
        public string FkIdLiteral { get => fkIdLiteral; set => fkIdLiteral = value; }
        public string FkIdNumeral { get => fkIdNumeral; set => fkIdNumeral = value; }
        public string FkIdParagrafo { get => fkIdParagrafo; set => fkIdParagrafo = value; }
    }
}