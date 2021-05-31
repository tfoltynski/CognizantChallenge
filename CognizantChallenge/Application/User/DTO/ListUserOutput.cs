using System;
using System.Collections.Generic;

namespace CognizantChallenge.Application.User.DTO {
    public sealed class ListUserOutput {
        public IEnumerable<ListUserDto> Users { get; set; }

        public sealed class ListUserDto {
            public Guid Id { get; set; }

            public string User { get; set; }

            public int SuccessfulSubmissions { get; set; }

            public IEnumerable<string> TaskNames { get; set; }
        }
    }
}