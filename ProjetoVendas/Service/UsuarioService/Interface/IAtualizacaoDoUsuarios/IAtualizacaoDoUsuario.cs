using ProjetoVendas.Entities;
using ProjetoVendas.Resquest.Usuarios;

namespace ProjetoVendas.Service.Interfaces.Atualizar
{
    public interface IAtualizacaoDoUsuario
    {
        void AtualizarUsuario(Usuario usuario, AtualizarUsuarios atualizarUsuario);
    }
}
