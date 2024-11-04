using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using VolunTree_API.Models;
using System.Collections.Generic;

namespace VolunTree_API.Pages
{
    public class OngsModel : PageModel
    {
        public List<Ong> Ongs { get; set; }
        public string ConsoleMessage { get; set; }

        private readonly HttpClient _httpClient;

        public OngsModel()
        {
            _httpClient = new HttpClient();
        }

        public async Task OnGetAsync() 
        {
            await GetOngsAsync();
        }

        private async Task GetOngsAsync()
        {
            var response = await _httpClient.GetAsync("https://localhost:7071/api/Ongs");
            if (response.IsSuccessStatusCode)
            {
                Ongs = await response.Content.ReadFromJsonAsync<List<Ong>>();
                ConsoleMessage = "Tudo certo...";
            }
            else
            {
                Ongs = new List<Ong>();
                ConsoleMessage = "Erro ao obter dados";
            }
        }
    }
}
