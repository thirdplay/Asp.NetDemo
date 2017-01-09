using AspDotNetDemo.Models;
using AutoMapper;

namespace AspDotNetDemo
{
    public class AutoMapperConfig
    {
        public static void RegisterMappings()
        {
            Mapper.Initialize(cfg =>
            {
                cfg.CreateMap<User, UserIndexViewModel>()
                    .ForMember(dest => dest.Sex, o => o.MapFrom(src => SexExt.GetDisplayName(src.Sex)));
                cfg.CreateMap<UserEditViewModel, User>();
                cfg.CreateMap<User, UserEditViewModel>();
                cfg.CreateMap<User, UserDeleteViewModel>()
                    .ForMember(dest => dest.Sex, o => o.MapFrom(src => SexExt.GetDisplayName(src.Sex)));
            });
        }
    }
}
