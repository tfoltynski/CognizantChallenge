using System.Text.Json.Serialization;

namespace CognizantChallenge.DistributedService.JDoodle.DTO {
    internal sealed class JDoodleCompileRequest {
        public string ClientId { get; set; }

        public string ClientSecret { get; set; }

        [JsonPropertyName("stdin")]
        public string Input { get; set; }

        [JsonPropertyName("script")]
        public string Code { get; set; }

        public string Language { get; set; }

        [JsonPropertyName("versionIndex")]
        public string LanguageVersionIndex { get; set; } = "0";
    }
}