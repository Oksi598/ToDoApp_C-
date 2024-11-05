using AutoMapper;
using ToDoApp.DAL.Models.Identity;
using ToDoApp.DAL.ViewModels;
using System.Data;

namespace ToDoApp.BLL.MappingProfiles
{
    public class RoleMapperProfile : Profile
    {
        public RoleMapperProfile()
        {
            // Role -> RoleVM
            CreateMap<Role, RoleVM>();

            // RoleVM -> Role
            CreateMap<RoleVM, Role>();
        }
    }
}
