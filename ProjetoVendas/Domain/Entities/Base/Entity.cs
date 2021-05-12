using System;

namespace Domain.Entities.Base
{
    public abstract class Entity
    {
        
        public Guid Id { get; private set; }
        public DateTime DataCadastro { get; private set; }

        protected Entity(){
            Id = Guid.NewGuid();
            DataCadastro = DateTime.Now;
        }

    }
}
