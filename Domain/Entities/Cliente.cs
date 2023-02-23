using System.ComponentModel.DataAnnotations;

namespace Domain.Entities
{
    public class Cliente : BaseEntity
    {
        public Cliente(string nome, string cpf, DateTime nascimento, string sexo, string endereco, string estado, string cidade)
        {
            Nome = nome;
            Cpf = cpf;
            Nascimento = nascimento;
            Sexo = sexo;
            Endereco = endereco;
            Estado = estado;
            Cidade = cidade;
        }
        public void Atualizar(Cliente cliente)
        {
            Nome = cliente.Nome;
            Cpf = cliente.Cpf;
            Nascimento = cliente.Nascimento;
            Sexo = cliente.Sexo;
            Endereco = cliente.Endereco;
            Estado = cliente.Estado;
            Cidade = cliente.Cidade;
        }

        [MaxLength(50)]
        public string Nome { get; private set; }
        [MaxLength(20)]
        public string Cpf { get; private set; }

        public DateTime Nascimento { get; private set; }
        [MaxLength(15)]
        public string Sexo { get; private set; }
        [MaxLength(100)]
        public string Endereco { get; private set; }
        [MaxLength(20)]
        public string Estado { get; private set; }
        [MaxLength(50)]
        public string Cidade { get; private set; }

        
    }
}
