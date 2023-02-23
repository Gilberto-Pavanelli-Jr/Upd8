using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Cidade : BaseEntity
    {
        public Cidade(string nomeCidade)
        {
            NomeCidade = nomeCidade;
        }

        public string NomeCidade { get; private set; }
        public Estado Estado { get;  set; }
        public Guid EstadoId { get; set; }
    }
}
