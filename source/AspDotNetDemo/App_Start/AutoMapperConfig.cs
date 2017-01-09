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
                cfg.CreateMap<UserEditViewModel, User>();
                cfg.CreateMap<User, UserEditViewModel>();
            });
        }
    }
}
