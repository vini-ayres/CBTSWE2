using Newtonsoft.Json;
using P02_API_SDK.Dtos;
using System.Net;

namespace P02_API_SDK.Services;

public class ProdutosService
{
    private string baseUrl;
    private HttpClient client;
    public ProdutosService(string baseUrl, HttpClient client)
    {
        this.client = client;
        this.baseUrl = baseUrl;
    }

    public async Task<List<ProdutoDTO>> GetAll()
    {
        var request = new HttpRequestMessage(HttpMethod.Get, $"{baseUrl}/api/produtos");

        var response = await client.SendAsync(request);

        var atividades = JsonConvert.DeserializeObject<List<ProdutoDTO>>(await response.Content.ReadAsStringAsync());

        return atividades;
    }

    public async Task<ProdutoDTO> GetById(int id)
    {
        var request = new HttpRequestMessage(HttpMethod.Get, $"{baseUrl}/api/produtos/{id}");

        var response = await client.SendAsync(request);

        var atividade = JsonConvert.DeserializeObject<ProdutoDTO>(await response.Content.ReadAsStringAsync());

        return atividade;
    }

    public async Task<bool> Create(ProdutoDTO atividade)
    {
        var request = new HttpRequestMessage(HttpMethod.Post, $"{baseUrl}/api/produtos");

        var content = JsonConvert.SerializeObject(atividade);

        request.Content = new StringContent(content, null, "application/json");
        var response = await client.SendAsync(request);

        return response.StatusCode == HttpStatusCode.Created;
    }

    public async Task<bool> Update(int id, ProdutoDTO atividade)
    {

        var request = new HttpRequestMessage(HttpMethod.Put, $"{baseUrl}/api/produtos/{id}");

        var content = JsonConvert.SerializeObject(atividade);

        request.Content = new StringContent(content, null, "application/json");
        var response = await client.SendAsync(request);
        response.EnsureSuccessStatusCode();

        return response.StatusCode == HttpStatusCode.NoContent;
    }

    public async Task<bool> Delete(int id)
    {
        var request = new HttpRequestMessage(HttpMethod.Delete, $"{baseUrl}/api/produtos/{id}");

        var response = await client.SendAsync(request);

        return response.StatusCode == HttpStatusCode.NoContent;
    }

}
