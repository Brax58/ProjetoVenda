using ProjetoVendas.Resquest.Usuarios;

namespace ProjetoVendas.Service.Interfaces.Validar
{
    public interface IValidarUsuario
    {
        bool ValidarCaracteristicas(AdicionarUsuario adicionarUsuario);
    }
}
