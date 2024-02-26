using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using SistemaDeTarefas.Models;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace SistemaDeTarefas.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContaController : ControllerBase
    {
        [HttpPost("login")]
        public IActionResult Login([FromBody] LoginModel login)
        {
            if (login.Login == "admin" && login.Senha == "admin")
            {
                var token = GerarTokenJWT();
                return Ok(new { token });
            }

            return BadRequest(new { mensagem = "Credenciais inválidas. Por favor, verifique seu nome de usuário e senha." });
        }

        private string GerarTokenJWT()
        {
            string chaveSecreta = "fd541ac8-73bf-40fd-9f6d-bcf670a97636";
            var secretKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(chaveSecreta));
            var signingCredentials = new SigningCredentials(secretKey, SecurityAlgorithms.HmacSha256);

            var claims = new[]
            {
                new Claim("login", "admin"),
                new Claim("nome", "Administrador do Sistema"),
            };

            var token = new JwtSecurityToken(
                issuer: "sua_empresa",
                audience: "sua_aplicacao",
                claims: claims,
                expires: DateTime.Now.AddHours(1),
                signingCredentials: signingCredentials
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
