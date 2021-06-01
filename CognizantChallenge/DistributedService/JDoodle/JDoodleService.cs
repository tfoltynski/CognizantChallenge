using System;
using System.Threading.Tasks;
using CognizantChallenge.DistributedService.JDoodle.DTO;
using JetBrains.Annotations;
using Microsoft.Extensions.Configuration;

namespace CognizantChallenge.DistributedService.JDoodle {
    public class JDoodleService : IJDoodleService {
        [NotNull]
        private readonly IRequestService requestService;
        
        [NotNull]
        private readonly string clientId;

        [NotNull]
        private readonly string clientSecret;

        [NotNull]
        private string url;

        public JDoodleService([NotNull] IRequestService requestService, [NotNull] IConfiguration configuration) {
            this.requestService = requestService ?? throw new ArgumentNullException(nameof(requestService));
            url = configuration.GetValue<string>("JDoodleAPIConnection:ApiUrl");
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

            var response = await this.requestService.Post<JDoodleCompileOutput>($"{url}/execute", request);
            return response;
        }
    }
}