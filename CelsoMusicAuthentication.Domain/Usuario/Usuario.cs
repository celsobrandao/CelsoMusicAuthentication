using CelsoMusicAuthentication.Domain.Usuario.Rules;
using CelsoMusicAuthentication.Domain.Usuario.ValueObject;
using CelsoMusicAuthentication.Infra.Entidade;
using CelsoMusicAuthentication.Infra.Utils;
using FluentValidation;

namespace CelsoMusicAuthentication.Domain.Usuario
{
    public class Usuario : Entidade<Guid>
    {
        public Email Email { get; set; }
        public Senha Senha { get; set; }
        public string Nome { get; set; }
        public DateTime DataNascimento { get; set; }

        public void Validar() => new ValidadorUsuario().ValidateAndThrow(this);

        public void AtualizarSenha()
        {
            Senha.Valor = SegurancaUtils.HashSHA1(Senha.Valor);
        }
    }
}