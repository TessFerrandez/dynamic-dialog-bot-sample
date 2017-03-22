using System;
using System.Threading.Tasks;
using DynamicDialogCore.Models.DTO;
using System.Net.Http;
using Newtonsoft.Json;
using System.Net.Http.Headers;
using System.Collections.Generic;

namespace DynamicDialogBot.Services
{
    [Serializable]
    public sealed class ResponseService : IResponseService
    {
        private Dictionary<string, Config> _configs = new Dictionary<string, Config>();

        public static string Endpoint => "<YOUR API ENDPOINT>/api";

        public async Task<Config> GetConfigAsync(string language)
        {
            Config config;

            if (_configs.ContainsKey(language))
            {
                config = _configs[language];
            }
            else
            {
                // Get the config.
                var requestUri = CreateRequestUri($"/configs");
                config = await GetAsync<Config>(requestUri, language);
                _configs[language] = config;
            }
            return config;
        }

        public async Task<Response> GetResponseAsync(string responseId, string language)
        {
            // Get the response.
            var requestUri = CreateRequestUri($"/responses/{responseId}");
            var response = await GetAsync<Response>(requestUri, language);

            return response;
        }

        private async Task<T> GetAsync<T>(Uri requestUri, string language) where T : class
        {
            try
            {
                // Create the HTTP client.
                var httpClient = new HttpClient();

                httpClient.DefaultRequestHeaders.AcceptLanguage.Add(new StringWithQualityHeaderValue(language));

                // Get the response.
                var response = await httpClient.GetAsync(requestUri);
                var str = await response.Content.ReadAsStringAsync();

                if (!response.IsSuccessStatusCode)
                {
                    return null;
                }

                // Deserialize the response body.
                var result = JsonConvert.DeserializeObject<T>(str);
                return result;
            }
            catch
            {
                // Ignored.
            }
            return null;
        }

        private Uri CreateRequestUri(string resource)
        {
            return new Uri($"{Endpoint}{resource}");
        }
    }
}