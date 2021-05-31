namespace CognizantChallenge.Application.Tasks.DTO {
    public sealed class SubmitTaskOutput {
        public bool IsCorrect { get; set; }

        public string Expected { get; set; }

        public string Output { get; set; }
    }
}