
namespace Domain.Entities
{
    public class Estado : BaseEntity
    {
        public Estado(string sigla, string nomeEstado)
        {
            Sigla = sigla;
            NomeEstado = nomeEstado;
        }

        public string Sigla { get;  set; }

        public string NomeEstado { get;  set; }

        public List<Cidade> Cidades { get;  set; }

    }
}
