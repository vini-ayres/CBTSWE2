using Newtonsoft.Json;
using P02_API_SDK.Dtos;
using System.Net;

namespace P02_API_SDK.Services;

public class UsuariosService
{
    private string baseUrl;
    private HttpClient client;
    public UsuariosService(string baseUrl, HttpClient client)
    {
        this.client = client;
        this.baseUrl = baseUrl;
    }

    public async Task<List<UsuarioDTO>> GetAll()
    {
        var request = new HttpRequestMessage(HttpMethod.Get, $"{baseUrl}/api/usuarios");

        var response = await client.SendAsync(request);

        var atividades = JsonConvert.DeserializeObject<List<UsuarioDTO>>(await response.Content.ReadAsStringAsync());

        return atividades;
    }

    public async Task<List<UsuarioDTO>> GetByName(string name)
    {
        var request = new HttpRequestMessage(HttpMethod.Get, $"{baseUrl}/api/usuarios?name={name}");

        var response = await client.SendAsync(request);

        var atividades = JsonConvert.DeserializeObject<List<UsuarioDTO>>(await response.Content.ReadAsStringAsync());

        return atividades;
    }

    public async Task<UsuarioDTO> GetById(int id)
    {
        var request = new HttpRequestMessage(HttpMethod.Get, $"{baseUrl}/api/usuarios/{id}");

        var response = await client.SendAsync(request);

        var atividade = JsonConvert.DeserializeObject<UsuarioDTO>(await response.Content.ReadAsStringAsync());

        return atividade;
    }

    public async Task<bool> Create(UsuarioDTO atividade)
    {
        var request = new HttpRequestMessage(HttpMethod.Post, $"{baseUrl}/api/usuarios");

        var content = JsonConvert.SerializeObject(atividade);

        request.Content = new StringContent(content, null, "application/json");
        var response = await client.SendAsync(request);

        return response.StatusCode == HttpStatusCode.Created;
    }

    public async Task<bool> Update(int id, UsuarioDTO atividade)
    {

        var request = new HttpRequestMessage(HttpMethod.Put, $"{baseUrl}/api/usuarios/{id}");

        var content = JsonConvert.SerializeObject(atividade);

        request.Content = new StringContent(content, null, "application/json");
        var response = await client.SendAsync(request);
        response.EnsureSuccessStatusCode();

        return response.StatusCode == HttpStatusCode.NoContent;
    }

    public async Task<bool> Delete(int id)
    {
        var request = new HttpRequestMessage(HttpMethod.Delete, $"{baseUrl}/api/usuarios/{id}");

        var response = await client.SendAsync(request);

        return response.StatusCode == HttpStatusCode.NoContent;
    }

    public async Task<UsuarioDTO> Login(string login, string senha)
    {
        var request = new HttpRequestMessage(HttpMethod.Post, $"{baseUrl}/api/usuarios/login?login={login}&senha={senha}");

        request.Content = new StringContent("", null, "application/json");
        var response = await client.SendAsync(request);

        var usuario = JsonConvert.DeserializeObject<UsuarioDTO>(await response.Content.ReadAsStringAsync());

        return usuario;
    }

}
