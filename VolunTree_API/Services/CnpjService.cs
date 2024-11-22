using System.Net;
using System.Net.Http;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
namespace VolunTree_API.Services;

public class CnpjService
{
    private readonly HttpClient _httpClient;
    private readonly String Url = "https://brasilapi.com.br/api/cnpj/v1/";

    public CnpjService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

    public async Task<HttpStatusCode> RetornaCnpj(String cnpj){
        
        var validacao = await _httpClient.GetAsync(Url + cnpj);

        return validacao.StatusCode;
    }


}