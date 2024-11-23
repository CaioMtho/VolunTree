using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
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
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [Authorize]
        [HttpGet("user/address")]
        public IActionResult GetEnderecoUsuario()
        {
            var endereco = User.FindFirstValue("Endereco");
            if (string.IsNullOrEmpty(endereco))
            {
                return NotFound("Endereço não encontrado");
            }
            return Ok(new {adress =  endereco});
        }

        [Authorize]
        [HttpGet("ongs")] 
        public async Task<IActionResult> GetOngsPorHabilidade() 
        { 
            var habilidades = User.FindFirstValue("Habilidades"); 
            if (string.IsNullOrEmpty(habilidades)) 
            { 
                return Unauthorized("Habilidades não encontradas"); 
            } 
            var ongs = await _userService.GetOngsByAbility(habilidades); 
            return Ok(ongs); 
        }

        /*
        [Authorize]
        [HttpGet("ongs")]
        public async Task<IActionResult> GetOngsPorDistancia([FromQuery] double distancia)
        {
            var enderecoUsuario = User.FindFirstValue("Endereco");

            if (string.IsNullOrEmpty(enderecoUsuario)) 
            { 
                return Unauthorized("Endereço não encontrado"); 
            }

            var ongs = await _dataService.ge
            
        }
        */

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
                    new Claim(ClaimTypes.Email, usuarioAutenticado.Email),
                    new Claim("Cpf", usuarioAutenticado.Cpf),                //CPF (Custom claim)
                    new Claim("Nome", usuarioAutenticado.Nome),               // Nome completo
                    new Claim("Endereco", usuarioAutenticado.Endereco),       // Endereço do usuário
                    new Claim("Interesses", usuarioAutenticado.Interesses ?? string.Empty), // Interesses do usuário
                    new Claim("Habilidades", usuarioAutenticado.Habilidades ?? string.Empty)  // Habilidades do usuário
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
