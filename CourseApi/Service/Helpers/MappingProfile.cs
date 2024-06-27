using AutoMapper;
using Domain.Entities;
using Service.DTOs.Groups;
using Service.DTOs.Students;
using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Helpers
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Student, StudentDto>();
            CreateMap<StudentCreateDto, Student>();
            CreateMap<StudentEditDto, Student>();


            CreateMap<Group, GroupDto>().ReverseMap();
            CreateMap<GroupCreateDto, Group>();
            CreateMap<GroupEditDto, Group>();
        }

    }
}
