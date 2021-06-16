using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using WorkOutAppApi.Client.Contracts;

namespace WorkOutAppApi.Client.Services
{
    public class BaseRepository<T> : IBaseRepository<T> where T : class
    {
        private readonly HttpClient _client;

        public BaseRepository(HttpClient client)
        {
            _client = client;
        }
        public async Task<bool> Create(string url, T obj)
        {
            if (obj == null) return false;

            var request = new HttpRequestMessage(HttpMethod.Post, url);
            request.Content = new StringContent(JsonConvert.SerializeObject(obj), Encoding.UTF8, "application/json");

            HttpResponseMessage response = await _client.SendAsync(request);

            if (response.StatusCode == System.Net.HttpStatusCode.OK)
                return true;

            return false;
        }

        public async Task<bool> Delete(string url, int id)
        {
            var request = new HttpRequestMessage(HttpMethod.Delete, url);
            request.Headers.Add("id", id.ToString());

            HttpResponseMessage response = await _client.SendAsync(request);

            if (response.StatusCode == System.Net.HttpStatusCode.OK)
                return true;

            return false;
        }

        public async Task<T> Get(string url, int id)
        {
            var request = new HttpRequestMessage(HttpMethod.Get, url);
            request.Headers.Add("id", id.ToString());

            HttpResponseMessage response = await _client.SendAsync(request);

            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                var content = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<T>(content);
            }

            return null;
        }

        public async Task<List<T>> Get(string url)
        {
            var request = new HttpRequestMessage(HttpMethod.Get, url);

            HttpResponseMessage response = await _client.SendAsync(request);

            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                var content = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<List<T>>(content);
            }

            return null;
        }

        public async Task<bool> Update(string url, T obj)
        {
            if (obj == null) return false;

            var request = new HttpRequestMessage(HttpMethod.Post, url);
            request.Content = new StringContent(JsonConvert.SerializeObject(obj), Encoding.UTF8, "application/json");

            HttpResponseMessage response = await _client.SendAsync(request);

            if (response.StatusCode == System.Net.HttpStatusCode.OK)
                return true;

            return false;
        }

        public async Task<T> PostAndGet(string url, T obj)
        {
            var request = new HttpRequestMessage(HttpMethod.Post, url);
            request.Content = new StringContent(JsonConvert.SerializeObject(obj), Encoding.UTF8, "application/json");
            HttpResponseMessage response = await _client.SendAsync(request);
            var result = JsonConvert.DeserializeObject<T>(await response.Content.ReadAsStringAsync());
            return result;
        }

    }
}
