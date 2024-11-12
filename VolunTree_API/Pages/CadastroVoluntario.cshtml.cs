using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;
using VolunTree_API.Models;

namespace VolunTree_API.Pages
{
    public class CadastroVoluntarioModel : PageModel
    {
        private readonly HttpClient _httpClient;
        public CadastroVoluntarioModel(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        [BindProperty]
        public Voluntario NovoVoluntario { get; set; }
        public string? Message { get; set; }
        public void OnGet()
        {
            NovoVoluntario = new Voluntario();
        }

        public async Task<ActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                Console.WriteLine("ModelState inválido");
                return Page();
            }

            NovoVoluntario.DataRegistroVolun = DateTime.UtcNow;
            try

            {
                var json = JsonConvert.SerializeObject(NovoVoluntario);
                var content = new StringContent(json, System.Text.Encoding.UTF8, "application/json");
                var response = await _httpClient.PostAsync("https://localhost:7071/api/Voluntarios", content);
                if (response.IsSuccessStatusCode)
                {
                    Message = "Voluntario cadastrado";
                    Console.WriteLine("sucesso");
                }
                else
                {
                    var errorText = await response.Content.ReadAsStringAsync();
                    Message = "Erro ao cadastrar voluntario: " + errorText;
                    Console.WriteLine("Erro");
                }
            }catch(Exception ex)
            {
                Console.WriteLine("Excecao: " + ex.Message);
                Message = "Erro ao cadastrar Voluntario: " + ex.Message;
            }

            return Page();
        }

    }
}
