using Microsoft.AspNetCore.Identity;
using VolunTree_API.Models;

namespace VolunTree_API.Services
{
    public interface IUserService
    {
        Task<UsuarioAutenticado> AuthenticateAsync(string email, string cpf);
    }
}
