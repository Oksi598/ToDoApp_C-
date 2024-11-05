using AutoMapper;
using ToDoApp.DAL;
using ToDoApp.DAL.Models.Identity;
using ToDoApp.DAL.ViewModels;

namespace ToDoApp.BLL.MappingProfiles
{
    public class UserMapperProfile : Profile
    {
        public UserMapperProfile()
        {
            // User -> UserVM
            CreateMap<User, UserVM>()
                .ForMember(dest => dest.Role, opt => opt.MapFrom(
                    src => src.UserRoles.Count > 0 ? src.UserRoles.First().Role.Name : "no role"));

            // CreateUpdateUserVM -> User
            CreateMap<CreateUpdateUserVM, User>()
                .ForMember(dest => dest.Id, opt => opt.Ignore());
        }
    }
}
