using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;
using System;
using System.Diagnostics;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using VolunTree_API.Models;

namespace VolunTree_API.Pages
{
    public class CadastroOngModel : PageModel
    {
        private readonly HttpClient _httpClient;

        public CadastroOngModel()
        {
            _httpClient = new HttpClient();
        }

        [BindProperty]
        public Ong NovaOng { get; set; }

        public string Message { get; set; }
        public string AlertClass { get; set; }

        public void OnGet()
        {
            NovaOng = new Ong();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                Console.WriteLine("ModelState inválido");
                return Page();
            }

            NovaOng.DataRegistroOng = DateTime.UtcNow;

            try
            {
                Console.WriteLine("Dados antes da serialização: " + NovaOng.ToString());

                var json = JsonConvert.SerializeObject(NovaOng);
                Console.WriteLine("Dados JSON enviados: " + json);

                var content = new StringContent(json, System.Text.Encoding.UTF8, "application/json");
                var response = await _httpClient.PostAsync("https://localhost:7071/api/Ongs", content);

                if (response.IsSuccessStatusCode)
                {
                    Message = "ONG cadastrada com sucesso!";
                    AlertClass = "alert-success";
                }
                else
                {
                    var errorText = await response.Content.ReadAsStringAsync();
                    Console.WriteLine("Erro na resposta: " + errorText);
                    Message = $"Erro ao cadastrar ONG: {errorText}";
                    AlertClass = "alert-danger";
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Erro ao cadastrar ONG: " + ex.Message);
                Message = $"Erro ao cadastrar ONG: {ex.Message}";
                AlertClass = "alert-danger";
            }

            return Page();
        }
    }
}
