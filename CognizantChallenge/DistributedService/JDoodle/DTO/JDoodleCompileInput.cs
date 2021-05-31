namespace CognizantChallenge.DistributedService.JDoodle.DTO {
    public sealed class JDoodleCompileInput {
        public string Input { get; set; }

        public string Code { get; set; }

        public string Language { get; set; }

        public string LanguageVersionIndex { get; set; } = "0";
    }
}