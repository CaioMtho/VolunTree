using System.Net.WebSockets;
using VolunTree_API.Models;
using VolunTree_API.Services;

public class UserService : IUserService
{
    private readonly IDataService _dataService;

    public UserService(IDataService dataService)
    {
        _dataService = dataService;
    }

    public async Task<UsuarioAutenticado> AuthenticateAsync(string email, string cpf)
    {
        var voluntario = await _dataService.GetVoluntarioByIdAsync(cpf);

        if (voluntario != null && voluntario.EmailVolun == email)
        {
            var user = new UsuarioAutenticado
            {
                Cpf = voluntario.Cpf,
                UserName = voluntario.EmailVolun,
                Email = voluntario.EmailVolun,
                Nome = voluntario.NomeVolun,
                Telefone = voluntario.TelefoneVolun,
                Endereco = voluntario.EnderecoVolun,
                Interesses = voluntario.Interesses,
                Habilidades = voluntario.Habilidades
            };
            return user;
        }

        return null;
    }

    public async Task<List<Ong>> GetOngsByAbility(string habilidades)
    {
        List<Ong> ongs = (List<Ong>) await _dataService.GetOngsAsync(); 
        var listaHabilidades = habilidades.Split(' ').ToList(); 
        var ongsFiltradas = ongs.Where(ong => listaHabilidades
                                .Any(habilidade => ong.Necessidades
                                .Contains(habilidade, StringComparison.OrdinalIgnoreCase)))
                                .ToList(); 
        return ongsFiltradas;
    }
}
