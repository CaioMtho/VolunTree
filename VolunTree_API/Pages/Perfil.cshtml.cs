using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Authentication;
using VolunTree_API.Models;
using System.Security.Claims;
namespace VolunTree_API.Pages
{
    public class PerfilModel : PageModel
    {
        public UsuarioAutenticado? Usuario { get; private set; }
        public void OnGet()
        {
            /*
            Usuario = new UsuarioAutenticado
            {
                Cpf = User.FindFirst("Cpf")?.Value,
                Email = User.FindFirst(ClaimTypes.Email).Value,
                Nome = User.FindFirst("Nome")?.Value,
                Endereco = User.FindFirst("Endereco")?.Value,
                Interesses = User.FindFirst("Interesses")?.Value,
                Habilidades = User.FindFirst("Habilidades")?.Value
            };
            */
        }
    }
}
