using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using VolunTree_API.Models;
using VolunTree_API.Services;

namespace VolunTree_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly IUserService _userService;

        public LoginController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost]
        public async Task<IActionResult> Login([FromBody] LoginRequestDto loginRequest)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var usuarioAutenticado = await _userService.AuthenticateAsync(loginRequest.Email, loginRequest.Cpf);
            if (usuarioAutenticado != null)
            {
                // Criar as reivindicações do usuário
                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, usuarioAutenticado.UserName),
                    new Claim(ClaimTypes.Email, usuarioAutenticado.Email)
                };

                var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                var authProperties = new AuthenticationProperties
                {
                    IsPersistent = true
                };

                // Configurar o cookie de autenticação
                await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(claimsIdentity), authProperties);

                // Retornar resposta de sucesso
                var userDto = new UsuarioAutenticado
                {
                    Cpf = usuarioAutenticado.Cpf,
                    Email = usuarioAutenticado.Email,
                    UserName = usuarioAutenticado.UserName,
                    Nome = usuarioAutenticado.Nome,
                    Endereco = usuarioAutenticado.Endereco,
                    Interesses = usuarioAutenticado.Interesses,
                    Habilidades = usuarioAutenticado.Habilidades,
                };
                return Ok(userDto);
            }

            return Unauthorized();
        }
    }
}
