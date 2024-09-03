using VolunTree_API.Models;

namespace VolunTree_API.Services
{
    public interface IDataService
    {
        Task<IEnumerable<Voluntario>> GetVoluntariosAsync();
        Task<Voluntario> GetVoluntarioByIdAsync(string cpf);
        Task AddVoluntarioAsync(Voluntario voluntario);
        Task UpdateVoluntarioAsync(Voluntario voluntario);
        Task DeleteVoluntarioAsync(string cpf);

        Task<IEnumerable<Ong>> GetOngsAsync();
        Task<Ong> GetOngByIdAsync(string cnpj);
        Task AddOngAsync(Ong ong);
        Task UpdateOngAsync(Ong ong);
        Task DeleteOngAsync(string cnpj);

        Task<IEnumerable<VoluntarioOng>> GetVoluntarioOngsAsync();
        Task AddVoluntarioOngAsync(VoluntarioOng voluntarioOng);
        Task DeleteVoluntarioOngAsync(int idLigacao);

        Task<IEnumerable<Sugestao>> GetSugestoesAsync();
        Task<Sugestao> GetSugestaoByIdAsync(int idSuges);
        Task AddSugestaoAsync(Sugestao sugestao);
        Task UpdateSugestaoAsync(Sugestao sugestao);
        Task DeleteSugestaoAsync(int idSuges);
    }

}
