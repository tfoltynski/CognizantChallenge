using System;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using JetBrains.Annotations;

namespace CognizantChallenge.DistributedService {
    public class RequestService : IRequestService {
        [NotNull]
        private readonly HttpClient httpClient;

        public RequestService([NotNull] HttpClient httpClient) {
            this.httpClient = httpClient ?? throw new ArgumentNullException(nameof(httpClient));
        }

        public async Task<T> Post<T>(string url, object input) {
            if (url == null) throw new ArgumentNullException(nameof(url));
            if (input == null) throw new ArgumentNullException(nameof(input));

            var inputContent = new StringContent(JsonSerializer.Serialize(input, new JsonSerializerOptions {PropertyNamingPolicy = JsonNamingPolicy.CamelCase}),
                Encoding.UTF8, "application/json");

            using var response = await httpClient.PostAsync(url, inputContent);
            response.EnsureSuccessStatusCode();

            return await response.Content.ReadFromJsonAsync<T>();
        }
    }
}