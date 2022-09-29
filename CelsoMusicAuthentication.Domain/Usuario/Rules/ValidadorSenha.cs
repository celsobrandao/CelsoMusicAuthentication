using CelsoMusicAuthentication.Domain.Usuario.ValueObject;
using FluentValidation;
using System.Text.RegularExpressions;

namespace CelsoMusicAuthentication.Domain.Usuario.Rules
{
    public class ValidadorSenha : AbstractValidator<Senha>
    {
        private const string _padrao = @"^(?=.*\d)(?=.*[a-z])(?=.*[A-Z])(?=.*[$*&@#!])[0-9a-zA-Z$*&@#!]{8,}$";

        public ValidadorSenha()
        {
            RuleFor(x => x.Valor)
                .NotEmpty()
                .Must(EmailValido)
                .WithMessage("A senha deve conter ao menos um dígito, ao menos uma letra minúscula, ao menos uma letra maiúscula, ao menos um caractere especial e ao menos 8 dos caracteres mencionados.");
        }

        private bool EmailValido(string valor) => Regex.IsMatch(valor, _padrao);
    }
}
