using Ilida.Api.Dtos;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Ilida.Api.Client
{
    public class IlidaApiClient : IIlidaApi
    {
        private readonly HttpClient _httpClient;

        public IlidaApiClient()
        {
            _httpClient = new HttpClient();
            _httpClient.BaseAddress = new Uri("http://ilida-api.azurewebsites.net/");
            _httpClient.DefaultRequestHeaders.TryAddWithoutValidation("Accept", "application/json");
        }

        public void Dispose()
        {
            _httpClient.Dispose();
        }

        public async Task<List<AccidentDto>> GetAccidentsAsync(long userId, CancellationToken token = default(CancellationToken))
        {
            var request = new HttpRequestMessage(HttpMethod.Get, "api/accidents?userId=" + userId);

            var response = await _httpClient.SendAsync(request, token).ConfigureAwait(false);

            return await DeserializeAsync<List<AccidentDto>>(response);
        }

        public async Task<AccidentDto> GetAccidentAsync(long userId, long accidentId, CancellationToken token = default(CancellationToken))
        {
            var request = new HttpRequestMessage(HttpMethod.Get, "api/accidents/" + accidentId + "?userId=" + userId);

            var response = await _httpClient.SendAsync(request, token).ConfigureAwait(false);

            return await DeserializeAsync<AccidentDto>(response);
        }

        public async Task<AccidentDto> CreateAccidentAsync(CreateAccidentRequest createAccidentRequest, CancellationToken token = default(CancellationToken))
        {
            var request = new HttpRequestMessage(HttpMethod.Post, "api/accidents")
            {
                Content = new StringContent(JsonConvert.SerializeObject(createAccidentRequest), Encoding.UTF8, "application/json")
            };

            var response = await _httpClient.SendAsync(request, token).ConfigureAwait(false);

            return await DeserializeAsync<AccidentDto>(response);
        }

        public async Task<UserDto> LoginAsync(LoginRequest loginRequest, CancellationToken token = default(CancellationToken))
        {
            var request = new HttpRequestMessage(HttpMethod.Post, "api/login")
            {
                Content = new StringContent(JsonConvert.SerializeObject(loginRequest), Encoding.UTF8, "application/json")
            };

            var response = await _httpClient.SendAsync(request, token).ConfigureAwait(false);

            return await DeserializeAsync<UserDto>(response);
        }

        public async Task<bool> AcceptAccidentAsync(AcceptAccidentRequest acceptAccidentRequest, CancellationToken token = default(CancellationToken))
        {
            var request = new HttpRequestMessage(HttpMethod.Post, "api/accidents/" + acceptAccidentRequest.AccidentId + "/accept?userId=" + acceptAccidentRequest.UserId);

            var response = await _httpClient.SendAsync(request, token).ConfigureAwait(false);

            response.EnsureSuccessStatusCode();
            return true;
        }

        private async Task<T> DeserializeAsync<T>(HttpResponseMessage response)
        {
            response.EnsureSuccessStatusCode();

            var content = await response.Content.ReadAsStringAsync().ConfigureAwait(false);

            return JsonConvert.DeserializeObject<T>(content);
        }
    }
}
