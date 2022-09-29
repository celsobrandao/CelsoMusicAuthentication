using CelsoMusicAuthentication.Domain.Usuario.Repository;
using CelsoMusicAuthentication.Repository.Context;
using CelsoMusicAuthentication.Repository.Database;
using Microsoft.EntityFrameworkCore;
using UsuarioModel = CelsoMusicAuthentication.Domain.Usuario.Usuario;

namespace CelsoMusicAuthentication.Repository.Repository.Usuario
{
    public class UsuarioRepository : Repository<UsuarioModel>, IUsuarioRepository
    {
        public UsuarioRepository(CelsoMusicAuthenticationContext context) : base(context)
        {
        }

        public Task<Guid> ValidarLogin(string email, string senha)
        {
            return DbSet.Where(x => x.Email.Valor.ToUpper() == email.ToUpper() && x.Senha.Valor == senha)
                        .Select(x => x.ID)
                        .FirstOrDefaultAsync();
        }
    }
}
