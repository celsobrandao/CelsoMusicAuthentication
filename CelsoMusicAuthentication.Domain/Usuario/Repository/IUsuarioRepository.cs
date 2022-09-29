using CelsoMusicAuthentication.Infra.Repository;

namespace CelsoMusicAuthentication.Domain.Usuario.Repository
{
    public interface IUsuarioRepository : IRepository<Usuario>
    {
        Task<Guid> ValidarLogin(string email, string senha);
    }
}
