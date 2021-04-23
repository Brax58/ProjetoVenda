using ProjetoVendas.Resquest.Usuario;

namespace ProjetoVendas.Service.Interfaces.Validar
{
    public interface IValidarUsuario
    {
        bool ValidarCaracteristicas(AdicionarUsuario adicionarUsuario);
    }
}
