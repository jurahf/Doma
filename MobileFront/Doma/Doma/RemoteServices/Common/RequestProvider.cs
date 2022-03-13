using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace Doma.RemoteServices.Common
{
    public class RequestProvider : IRequestProvider
    {
        public async Task<TResult> GetAsync<TResult>(string uri, string token = "")
        {
            HttpResponseMessage response;
            try
            {
                HttpClient httpClient = CreateHttpClient(token);
                
                response = await httpClient.GetAsync(uri);
            }
            catch (Exception ex)
            {
                // TODO: Log
                throw;
            }

            if (!response.IsSuccessStatusCode)
                throw new Exception($"Код ответа говорит о неудачном выполнении запроса: {(int)response.StatusCode}"); // TODO: typed exception

            string serialized = await response.Content.ReadAsStringAsync();

            TResult result = await Task.Run(() => JsonConvert.DeserializeObject<TResult>(serialized));

            return result;
        }

        public async Task<TResult> PostAsync<TResult>(string uri, object data, string token = "")
        {
            HttpResponseMessage response;
            try
            {
                HttpClient httpClient = CreateHttpClient(token);
                HttpContent content = new StringContent(JsonConvert.SerializeObject(data), Encoding.UTF8, "application/json");

                response = await httpClient.PostAsync(uri, content);
            }
            catch (Exception ex)
            {
                // TODO: Log
                throw;
            }

            if (!response.IsSuccessStatusCode)
                throw new Exception($"Код ответа говорит о неудачном выполнении запроса: {(int)response.StatusCode}"); // TODO: typed exception

            string serialized = await response.Content.ReadAsStringAsync();

            TResult result = await Task.Run(() => JsonConvert.DeserializeObject<TResult>(serialized));

            return result;
        }

        public async Task PutAsync<TResult>(string uri, object data, string token = "")
        {
            HttpResponseMessage response;
            try
            {
                HttpClient httpClient = CreateHttpClient(token);
                HttpContent content = new StringContent(JsonConvert.SerializeObject(data), Encoding.UTF8, "application/json");

                response = await httpClient.PutAsync(uri, content);
            }
            catch (Exception ex)
            {
                // TODO: Log
                throw;
            }

            if (!response.IsSuccessStatusCode)
                throw new Exception($"Код ответа говорит о неудачном выполнении запроса: {(int)response.StatusCode}"); // TODO: typed exception
        }

        public async Task DeleteAsync(string uri, string token = "")
        {
            HttpResponseMessage response;
            try
            {
                HttpClient httpClient = CreateHttpClient(token);

                response = await httpClient.DeleteAsync(uri);
            }
            catch (Exception ex)
            {
                // TODO: Log
                throw;
            }

            if (!response.IsSuccessStatusCode)
                throw new Exception($"Код ответа говорит о неудачном выполнении запроса: {(int)response.StatusCode}"); // TODO: typed exception
        }

        private HttpClient CreateHttpClient(string token)
        {
            var httpClient = new HttpClient();
            //httpClient.BaseAddress = new Uri(backendUri);
            httpClient.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));

            if (!string.IsNullOrEmpty(token))
            {
                httpClient.DefaultRequestHeaders.Authorization =
                    new AuthenticationHeaderValue("Bearer", token);
            }
            return httpClient;
        }
    }
}
