using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Domain.Dtos;
using Domain.Models;

namespace Domain.Mapper
{
    public class N5ChallengeMapper : Profile
    {
        public N5ChallengeMapper()
        {
            CreateMap<Permission, PermissionDto>().ForMember(a => a.PermissionDate, b => b.MapFrom(e => e.PermissionDate.ToString()));
            CreateMap<PermissionType, PermissionTypeDto>();
        }
    }
}
