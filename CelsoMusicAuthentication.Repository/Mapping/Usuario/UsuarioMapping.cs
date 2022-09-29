using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using UsuarioModel = CelsoMusicAuthentication.Domain.Usuario.Usuario;

namespace CelsoMusicAuthentication.Repository.Mapping.Usuario
{
    public class UsuarioMapping : IEntityTypeConfiguration<UsuarioModel>
    {
        public void Configure(EntityTypeBuilder<UsuarioModel> builder)
        {
            builder.ToTable("Usuarios");

            builder.HasKey(x => x.ID);

            builder.Property(x => x.ID)
                .ValueGeneratedOnAdd();

            builder.OwnsOne(x => x.Email, p =>
            {
                p.Property(f => f.Valor)
                    .HasColumnName("Email")
                    .IsRequired()
                    .HasMaxLength(100);
            });

            builder.OwnsOne(x => x.Senha, p =>
            {
                p.Property(f => f.Valor)
                    .HasColumnName("Senha")
                    .IsRequired()
                    .HasMaxLength(200);
            });

            builder.Property(x => x.Nome)
                .IsRequired()
                .HasMaxLength(200);

            builder.Property(x => x.DataNascimento)
                .IsRequired();
        }
    }
}
