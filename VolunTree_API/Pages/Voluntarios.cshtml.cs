using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using VolunTree_API.Models;

namespace VolunTree_API.Pages
{
    public class VoluntariosModel : PageModel
    {
        private readonly HttpClient _httpClient;
        public List<Voluntario>? Voluntarios { get; set; }
        public String? ConsoleMessage { get; set; }

        public VoluntariosModel()
        {
            _httpClient = new HttpClient();
        }

        public async Task OnGetAsync()
        {
            await GetVoluntariosAsync();
        }

        public async Task GetVoluntariosAsync()
        {
            var response = await _httpClient.GetAsync("https://localhost:7071/api/Voluntarios");
            if (response.IsSuccessStatusCode)
            {
                Voluntarios = await response.Content.ReadFromJsonAsync<List<Voluntario>>();
                ConsoleMessage = "Tudo certo...";
            }
            else
            {
                Voluntarios = new List<Voluntario>();
                ConsoleMessage = "Erro ao obter dados";
            }
        }


    }
}
