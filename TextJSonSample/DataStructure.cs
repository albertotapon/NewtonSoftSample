using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace TextJSonSample
{
    public class Persona
    {
        [JsonPropertyNameAttribute("Nombre")]
        public string Name { get; set; }
        public Guid idCliente { get; set; }

        public string apellidos { get; set; }

        public List<Coches> Coches { get; set; }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat("ID Cliente:{0}", idCliente);
            sb.AppendFormat("Nombre:{0}", Name);
            sb.AppendFormat("Apellidos:{0}", apellidos);
            sb.AppendFormat("Coches: {0}", Coches);
            return sb.ToString();
        }
    }
}
