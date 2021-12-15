using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace TextJSonSample
{
    public class Coches
    {
        [JsonPropertyNameAttribute("Nombre")]
        public string Marca { get; set; }

        public string Matricula { get; set; }

        public int Anno { get; set; }

      public   Color color = new Color();

        public Coches(string marca, string matricula, int anno, Color color, string modelo)
        {
            Marca = marca;
            Matricula = matricula;
            Anno = anno;
            this.color = color;
            Modelo = modelo;
        }

        public string Modelo { get; set; }

        public override string ToString()
        {
            return $"El coche con matricula {Matricula} es un {Marca}, modelo {Modelo}, del año {Anno}, de color {color}";
        }

    }
}
