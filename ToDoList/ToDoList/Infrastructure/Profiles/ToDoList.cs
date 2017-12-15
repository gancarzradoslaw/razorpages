using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using ToDoList.Domain;
using ToDoList.Models.ToDoList;

namespace ToDoList.Infrastructure.Profiles
{
    public class ToDoList : Profile
    {
        public ToDoList()
        {
            CreateMap<ActivityModel, Activity>()
                .ForMember(d => d.Desription, expr => expr.MapFrom(s => s.Desription))
                .ForMember(d => d.Id, expr => expr.MapFrom(s => s.Id))
                .ForMember(d => d.Name, expr => expr.MapFrom(s => s.Name));

            CreateMap<Activity, ActivityModel>()
                .ForMember(d => d.Desription, expr => expr.MapFrom(s => s.Desription))
                .ForMember(d => d.Id, expr => expr.MapFrom(s => s.Id))
                .ForMember(d => d.Name, expr => expr.MapFrom(s => s.Name));
        }
    }
}
