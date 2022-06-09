using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoTask.DataAccess.Models;
using ToDoTask.Logic.DTOModels;

namespace ToDoTask.Logic.Mappings
{
    public class ToDoProfile : Profile
    {
        public ToDoProfile()
        {
            CreateMap<ToDoDTO, ToDoModel>().ReverseMap();
        }
    }
}
