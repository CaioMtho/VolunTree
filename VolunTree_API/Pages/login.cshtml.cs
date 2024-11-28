using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;
using VolunTree_API.Models;

namespace VolunTree_API.Pages
{
    public class LoginModel : PageModel
    {
        private readonly HttpClient _httpClient;

        public LoginModel()
        {
            _httpClient = new HttpClient();
        }
    }

}