using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace YY.Needle.Web.AutoMapperInit
{
    public class DomainToViewModelMappingProfile : Profile
    {
        public override string ProfileName
        {
            get { return "DomainToViewModelMappings"; }
        }

        protected override void Configure()
        {
           // Mapper.CreateMap<Genre, GenreMenuViewModel>();
        }
    }
}