namespace CognizantChallenge.DistributedService.JDoodle.DTO {
    public sealed class JDoodleCompileOutput {
        public string Output { get; set; }

        public int StatusCode { get; set; }

        public string Memory { get; set; }

        public string CpuTime { get; set; }
    }
}