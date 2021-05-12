using Application.Request.Usuarios;
using FluentValidation;

namespace Application.Service.UsuarioService.ValidacaoUsuarios
{
    public class ValidarUsuario : AbstractValidator<AdicionarUsuario>
    {
        public ValidarUsuario()
        {
            RuleFor(x => x.Nome).Length(1, 60).WithMessage("O nome não pode ser nulo e também pode ter no máximo 60 caracteres!.");
            
            RuleFor(x => x.Email).NotNull().WithMessage("Email não pode ser nulo!")
                .EmailAddress().WithMessage("Formato do email invalido!.");
            
            RuleFor(x => x.DataDeNascimento).NotNull().WithMessage("Data de nascimento não pode ser nula!.")
                .Length(8).WithMessage("A data de nascimento tem que ter 8 digitos!.");
            
            RuleFor(x => x.Cpf).NotNull().WithMessage("Cpf não pode ser nula!.")
                .Length(11).WithMessage("O cpf tem que ter 11 digitos!.");
        }
    }
}
