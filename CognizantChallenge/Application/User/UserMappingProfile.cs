using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using CognizantChallenge.Application.User.DTO;
using CognizantChallenge.Domain.Entities;

namespace CognizantChallenge.Application.User {
    public class UserMappingProfile : Profile {
        public UserMappingProfile() {
            CreateMap<UserEntity, ListUserOutput.ListUserDto>().ForMember(d => d.TaskNames, m => m.MapFrom(r => r.SolvedTasks.Select(s => s.TaskName)))
                .ForMember(d => d.SuccessfulSubmissions, m => m.MapFrom(r => r.SolvedTasks.Count));
            CreateMap<IEnumerable<UserEntity>, ListUserOutput>().ForMember(d => d.Users, m => m.MapFrom(r => r));
        }
    }
}