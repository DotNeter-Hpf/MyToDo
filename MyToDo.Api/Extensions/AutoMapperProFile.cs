using AutoMapper;
using MyToDo.Api.Models;
using MyToDo.Shared.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyToDo.Api.Extensions
{
    public class AutoMapperProFile : MapperConfigurationExpression
    {
        public AutoMapperProFile()
        {
            //相互之间转换
            CreateMap<ToDo, ToDoDto>().ReverseMap();
                //Dto中FirstName+LastName = 实体类中的Name
                //.ForMember(d=>d.Name,o=>o.MapFrom(o=>o.FirstName+o.LastName))
                //字段名字不同
                //.ForMember(d=>d.Id,o=>o.MapFrom(o=>o.Id))
                //不映射某个字段
                //.ForMember(d=>d.Id,o=>o.Ignore());


            CreateMap<Memo, MemoDto>().ReverseMap();

            CreateMap<User, UserDto>().ReverseMap();
        }
    }
}
