using AutoMapper;
using Domain.Entites;
using Service.DTOs.Admin.Groups;
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
            CreateMap<Group, GroupDto>();
            CreateMap<GroupCreateDto, Group>();
            CreateMap<GroupEditDto, Group>();



        }
    }
}
