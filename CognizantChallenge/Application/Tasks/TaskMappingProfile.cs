using System.Collections.Generic;
using AutoMapper;
using CognizantChallenge.Application.Tasks.DTO;
using CognizantChallenge.Domain.Entities;

namespace CognizantChallenge.Application.Tasks {
    public class TaskMappingProfile : Profile {
        public TaskMappingProfile() {
            CreateMap<TaskEntity, GetTaskOutput>();
            CreateMap<TaskEntity, ListTaskOutput.ListTaskDto>();
            CreateMap<IEnumerable<TaskEntity>, ListTaskOutput>().ForMember(d => d.Tasks, m => m.MapFrom(r => r));
        }
    }
}