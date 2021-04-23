using ProjetoVendas.Entities;
using ProjetoVendas.Resquest.Usuario;

namespace ProjetoVendas.Service.Interfaces.Atualizar
{
    public interface IAtualizacaoDoUsuario
    {
        void AtualizarUsuario(Usuario usuario, AtualizarUsuario atualizarUsuario);
    }
}
