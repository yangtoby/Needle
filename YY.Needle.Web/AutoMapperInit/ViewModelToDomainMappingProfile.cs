using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace YY.Needle.Web.AutoMapperInit
{
    public class ViewModelToDomainMappingProfile : Profile
    {
        public override string ProfileName
        {
            get { return "ViewModelToDomainMappings"; }
        }

        protected override void Configure()
        {
           // Mapper.CreateMap<GenreMenuViewModel, Genre>();
        }
    }
}