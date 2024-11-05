using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoApp.DAL.Models;
using ToDoApp.DAL.ViewModels;

namespace ToDoApp.BLL.MappingProfiles
{
    public class TaskMappingProfile : Profile
    {
        public TaskMappingProfile()
        {
            CreateMap<DAL.Models.Task, TaskVM>().ReverseMap();
        }
    }
}
