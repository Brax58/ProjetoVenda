using ProjetoVendas.Entities.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoVendas.Entities
{
    public class Usuario : Entity
    {
        public string Nome{ get; private set; }
        public string Email{ get; private set; }
        public string DataDeNascimento{ get; set; }
        public string Cpf { get; private set; }

        
        public Usuario(string nome,string email,string cpf,string dataDeNascimento)
        {
            Nome = nome;
            Email = email;
            Cpf = cpf;
            DataDeNascimento = dataDeNascimento;
        }

    }

}
