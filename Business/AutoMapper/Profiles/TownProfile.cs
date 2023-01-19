using AutoMapper;
using Business.Models.v1;
using Persistence.Entities.v1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.AutoMapper.Profiles
{
    public class TownProfile : Profile
    {
        public TownProfile()
        {
            CreateMap<Town, TownInfoModel>();
        }

    }
}
