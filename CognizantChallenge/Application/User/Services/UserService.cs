using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using CognizantChallenge.Application.User.DTO;
using CognizantChallenge.Domain.Entities;
using CognizantChallenge.Domain.Repositories;
using JetBrains.Annotations;

namespace CognizantChallenge.Application.User.Services {
    public class UserService : IUserService {
        [NotNull]
        private readonly IUserRepository userRepository;

        [NotNull]
        private readonly IMapper mapper;

        public UserService([NotNull] IUserRepository userRepository, [NotNull] IMapper mapper) {
            this.userRepository = userRepository ?? throw new ArgumentNullException(nameof(userRepository));
            this.mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public async Task<ListUserOutput> ListUsers() {
            var users = await this.userRepository.List();
            return mapper.Map<IEnumerable<UserEntity>, ListUserOutput>(users);
        }
    }
}