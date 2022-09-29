using CelsoMusicAuthentication.Application.Usuario.DTO;
using CelsoMusicAuthentication.Application.Usuario.Service.Interfaces;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace CelsoMusicAuthentication.API.Controllers.Usuario
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class UsuarioController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        private readonly IUsuarioService _usuarioService;

        public UsuarioController(IConfiguration configuration,
                                 IUsuarioService usuarioService)
        {
            _configuration = configuration;
            _usuarioService = usuarioService;
        }

        [HttpPost]
        [Route("ValidarLogin")]
        [AllowAnonymous]
        public async Task<IActionResult> ValidarLogin(UsuarioLoginInputDTO dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var result = await _usuarioService.ValidarLogin(dto);

            if (result.Valido)
            {
                return Ok($"Bearer {GenerateToken(result.ID.Value)}");
            }
            else
            {
                return Unauthorized(result.Mensagem);
            }
        }

        private string GenerateToken(Guid id)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(_configuration["TokenSecret"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Name, id.ToString()),
                new Claim("role", "User")
            };

            var token = new JwtSecurityToken(
                    issuer: _configuration["Issuer"],
                    audience: _configuration["Audience"],
                    claims: claims,
                    expires: DateTime.UtcNow.AddMinutes(10),
                    signingCredentials: credentials
                );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        [HttpGet]
        public async Task<IActionResult> ObterTodos()
        {
            return Ok(await _usuarioService.ObterTodos());
        }

        [HttpPost]
        [Route("Criar")]
        [AllowAnonymous]
        public async Task<IActionResult> Criar(UsuarioInputDTO dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var result = await _usuarioService.Criar(dto);

            return Created($"/{result.ID}", result);
        }

        [HttpPut]
        public async Task<IActionResult> Atualizar(UsuarioUpdateDTO dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var result = await _usuarioService.Atualizar(dto);

            return Ok(result);
        }

        [HttpDelete]
        public async Task<IActionResult> Remover(Guid usuarioID)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            await _usuarioService.Remover(usuarioID);

            return NoContent();
        }
    }
}
