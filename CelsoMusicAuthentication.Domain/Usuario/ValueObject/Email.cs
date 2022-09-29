namespace CelsoMusicAuthentication.Domain.Usuario.ValueObject
{
    public class Email
    {
        public Email()
        {
        }

        public Email(string valor)
        {
            Valor = valor ?? throw new ArgumentNullException(nameof(valor));
        }

        public string Valor { get; set; }

        public override string ToString()
        {
            return Valor;
        }
    }
}
