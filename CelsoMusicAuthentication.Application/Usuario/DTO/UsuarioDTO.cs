using System.ComponentModel.DataAnnotations;

namespace CelsoMusicAuthentication.Application.Usuario.DTO
{
    public record UsuarioInputDTO([Required(ErrorMessage = "O Email deve ser informado.")] string Email,
                                  [Required(ErrorMessage = "A Senha deve ser informada.")] string Senha,
                                  [Required(ErrorMessage = "O Nome deve ser informado.")] string Nome,
                                  [Required(ErrorMessage = "A Data de Nascimento deve ser informada.")] DateTime DataNascimento);

    public record UsuarioUpdateDTO([Required(ErrorMessage = "O ID deve ser informado.")] Guid ID,
                                   [Required(ErrorMessage = "O Email deve ser informado.")] string Email,
                                   [Required(ErrorMessage = "A Senha deve ser informada.")] string Senha,
                                   [Required(ErrorMessage = "O Nome deve ser informado.")] string Nome,
                                   [Required(ErrorMessage = "A Data de Nascimento deve ser informada.")] DateTime DataNascimento);

    public record UsuarioOutputDTO(Guid ID, string Email, string Nome, DateTime DataNascimento);

    public record UsuarioLoginInputDTO([Required(ErrorMessage = "O Email deve ser informado.")] string Email,
                                       [Required(ErrorMessage = "A Senha deve ser informada.")] string Senha);

    public record UsuarioLoginOutputDTO(bool Valido,
                                        string Mensagem,
                                        Guid? ID);
}
