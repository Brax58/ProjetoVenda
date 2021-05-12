using Domain.Entities.Base;

namespace Domain.Entities
{
    public class Usuario : Entity
    {
        public string Nome{ get; private set; }
        public string Email{ get; private set; }
        public string DataDeNascimento{ get; private set; }
        public string Cpf { get; private set; }
        public bool Ativo { get; private set; }


        public Usuario(string nome,string email,string cpf,string dataDeNascimento)
        {
            Nome = nome;
            Email = email;
            Cpf = cpf;
            DataDeNascimento = dataDeNascimento;
            Ativo = true;
        }


        public void AddNewUsuario(string nome,bool ativo)
        {
            Nome = nome;
            SetAtivo(ativo);
        }

        internal void SetAtivo(bool ativo)
        {
            Ativo = ativo;
        }

    }

}
