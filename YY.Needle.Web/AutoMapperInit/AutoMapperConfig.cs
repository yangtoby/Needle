using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using YY.Needle.Domain.AutoMapperProfiles;

namespace YY.Needle.Web.AutoMapperInit
{
    public class AutoMapperConfig
    {
        public static void RegisterMappings()
        {
            Mapper.Initialize(x =>
            {
                x.AddProfile<DomainToViewModelMappingProfile>();
                x.AddProfile<ViewModelToDomainMappingProfile>();
                x.AddProfile<DomainMapperProfile>();
            });
        }
    }
}