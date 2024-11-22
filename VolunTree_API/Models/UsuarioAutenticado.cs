using Microsoft.AspNetCore.Identity;

namespace VolunTree_API.Models
{
    public class UsuarioAutenticado : IdentityUser
    {
        public required string Cpf {  get; set; }
        public string? Nome { get; set; }
        public string? Telefone { get; set; }
        public string? Endereco { get; set; }
        public string? Interesses { get; set; }
        public string? Habilidades { get; set; }
    }
}
