using System;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using CognizantChallenge.DistributedService.JDoodle.DTO;
using JetBrains.Annotations;
using Microsoft.Extensions.Configuration;

namespace CognizantChallenge.DistributedService.JDoodle {
    public class JDoodleCompilerService : ICompilerService<JDoodleCompileOutput, JDoodleCompileInput> {
        [NotNull]
        private readonly HttpClient httpClient;

        [NotNull]
        private readonly string clientId;

        [NotNull]
        private readonly string clientSecret;

        public JDoodleCompilerService([NotNull] HttpClient httpClient, [NotNull] IConfiguration configuration) {
            this.httpClient = httpClient ?? throw new ArgumentNullException(nameof(httpClient));
            clientId = configuration.GetValue<string>("JDoodleAPIConnection:ClientId");
            clientSecret = configuration.GetValue<string>("JDoodleAPIConnection:ClientSecret");
        }

        public async Task<JDoodleCompileOutput> Compile(JDoodleCompileInput input) {
            if (input == null) throw new ArgumentNullException(nameof(input));

            var request = new JDoodleCompileRequest {
                ClientId = clientId,
                ClientSecret = clientSecret,
                Input = input.Input,
                Code = input.Code,
                Language = input.Language,
                LanguageVersionIndex = input.LanguageVersionIndex
            };

            var inputContent = new StringContent(
                JsonSerializer.Serialize(request, new JsonSerializerOptions {PropertyNamingPolicy = JsonNamingPolicy.CamelCase}),
                Encoding.UTF8, "application/json");

            using var response = await httpClient.PostAsync("/execute", inputContent);
            response.EnsureSuccessStatusCode();

            return await response.Content.ReadFromJsonAsync<JDoodleCompileOutput>();
        }
    }
}