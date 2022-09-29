using AutoMapper;
using CelsoMusicAuthentication.Application.Usuario.DTO;
using CelsoMusicAuthentication.Application.Usuario.Service;
using CelsoMusicAuthentication.Domain.Usuario.Repository;
using CelsoMusicAuthentication.Domain.Usuario.ValueObject;
using Moq;
using UsuarioModel = CelsoMusicAuthentication.Domain.Usuario.Usuario;

namespace CelsoMusicAuthentication.Test.Application.Usuario
{
    public class UsuarioServiceTest
    {
        [Fact]
        public async Task DeveCriarUsuarioComSucesso()
        {
            var dto = new UsuarioInputDTO("celso.brandao@al.infnet.edu", "Teste123!", "Celso Braga Brandão", new DateTime(1982, 1, 12));
            var mockRepository = new Mock<IUsuarioRepository>();
            var mockMapper = new Mock<IMapper>();

            var usuario = new UsuarioModel()
            {
                Email = new Email(dto.Email),
                Senha = new Senha(dto.Senha),
                Nome = dto.Nome,
                DataNascimento = dto.DataNascimento
            };

            var usuarioDTO = new UsuarioOutputDTO(Guid.NewGuid(), usuario.Email.Valor, usuario.Nome, usuario.DataNascimento);

            mockMapper.Setup(x => x.Map<UsuarioModel>(dto)).Returns(usuario);
            mockMapper.Setup(x => x.Map<UsuarioOutputDTO>(usuario)).Returns(usuarioDTO);

            mockRepository.Setup(x => x.Save(It.IsAny<UsuarioModel>())).Returns(Task.FromResult(usuario));

            var service = new UsuarioService(mockRepository.Object, mockMapper.Object);

            var result = await service.Criar(dto);

            Assert.NotNull(result);
        }

        [Fact]
        public async Task DeveAtualizarUsuarioComSucesso()
        {
            var dto = new UsuarioUpdateDTO(Guid.NewGuid(), "celso.brandao@al.infnet.edu", "Teste123!", "Celso Braga Brandão", new DateTime(1982, 1, 12));
            var mockRepository = new Mock<IUsuarioRepository>();
            var mockMapper = new Mock<IMapper>();

            var usuario = new UsuarioModel()
            {
                ID = dto.ID,
                Email = new Email(dto.Email),
                Senha = new Senha(dto.Senha),
                Nome = dto.Nome,
                DataNascimento = dto.DataNascimento
            };

            var usuarioDTO = new UsuarioOutputDTO(usuario.ID, usuario.Email.Valor, usuario.Nome, usuario.DataNascimento);

            mockMapper.Setup(x => x.Map<UsuarioModel>(dto)).Returns(usuario);
            mockMapper.Setup(x => x.Map<UsuarioOutputDTO>(usuario)).Returns(usuarioDTO);

            mockRepository.Setup(x => x.Update(It.IsAny<UsuarioModel>())).Returns(Task.FromResult(usuario));

            var service = new UsuarioService(mockRepository.Object, mockMapper.Object);

            var result = await service.Atualizar(dto);

            Assert.NotNull(result);
        }
    }
}
