﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoVendas.Resquest.Usuario
{
    public class AtualizarUsuario
    {
        /*O sistema deve ser capaz de atualizar os dados do usuário(apresentados acima), 
        com EXCEÇÃO da Data de cadastro e do Email, estas propriedades não poderão ser atualizadas pelo usuário 
       em nenhum momento*/

        public Guid Id { get; set; }
        public string Nome{ get; set; }
        public bool Ativo { get; set; }
    }
}