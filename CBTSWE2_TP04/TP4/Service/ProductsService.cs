using Models;
using Newtonsoft.Json;
using System.Net;

namespace TP4.Service
{
    public class ProductsService
    {
        private string baseURL = "http://localhost:5168";


        public async Task<List<Product>> Index()
        {
            var client = new HttpClient();

            var request = new HttpRequestMessage(HttpMethod.Get, $"{baseURL}/products");

            var response = await client.SendAsync(request);
            response.EnsureSuccessStatusCode();

            var products = JsonConvert.DeserializeObject<List<Product>>(await response.Content.ReadAsStringAsync());

            return products;
        }

        public async Task<Product> Details(int? id)
        {
            var client = new HttpClient();

            var request = new HttpRequestMessage(HttpMethod.Get, $"{baseURL}/products/{id}");


            var response = await client.SendAsync(request);
            response.EnsureSuccessStatusCode();

            var product = JsonConvert.DeserializeObject<Product>(await response.Content.ReadAsStringAsync());

            return product;
        }

        public async Task Create(Product product)
        {
            var client = new HttpClient();

            var request = new HttpRequestMessage(HttpMethod.Post, $"{baseURL}/products");

            var content = JsonConvert.SerializeObject(product);

            request.Content = new StringContent(content, null, "application/json");
            var response = await client.SendAsync(request);
        }

        public async Task Edit(int id, Product product)
        {
            var client = new HttpClient();

            var request = new HttpRequestMessage(HttpMethod.Put, $"{baseURL}/products/{id}");

            var content = JsonConvert.SerializeObject(product);

            request.Content = new StringContent(content, null, "application/json");
            var response = await client.SendAsync(request);
        }

        public async Task Delete(int id)
        {
            var client = new HttpClient();

            var request = new HttpRequestMessage(HttpMethod.Delete, $"{baseURL}/products/{id}");


            var response = await client.SendAsync(request);
        }
    }
}
