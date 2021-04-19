using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoVendas.Entities.Base
{
    public abstract class Entity
    {
        public Guid Id { get; private set; }
        public bool Ativo { get; private set; }
        public DateTime DataCadastro { get; private set; }

        protected Entity(){
            Id = Guid.NewGuid();
            DataCadastro = DateTime.Now;
            Ativo = true;
        }


    }
}
