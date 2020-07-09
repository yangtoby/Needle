using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YY.Needle.Domain.DTO.Account;
using YY.Needle.Domain.DTO.Common;

namespace YY.Needle.Domain.AutoMapperProfiles
{
    public class DomainMapperProfile:Profile
    {

        public override string ProfileName
        {
            get { return "DomainMapperProfile"; }
        }

        protected override void Configure()
        {
             Mapper.CreateMap<LoginInput, AccountInfoDto>();
        }
    }
}
