using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjetoAspNet.Domain
{
    public class Caderno
    {
        public int CadernoId { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }

        [JsonIgnore]
        public virtual ICollection<Notas> Notas { get; set; }
    }
}