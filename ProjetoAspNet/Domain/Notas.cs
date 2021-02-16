using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjetoAspNet.Domain
{
    public class Notas
    {
        public int NotasId { get; set; }
        public string Titulo { get; set; }
        public string Tag { get; set; }
        public DateTime DataDaCriacao { get; set; }
        public string Conteudo { get; set; }

        [JsonIgnore]
        public virtual ICollection<Caderno> Cadernos { get; set; }

        public Notas()
        {
            this.Cadernos = new List<Caderno>();
        }
    }
}