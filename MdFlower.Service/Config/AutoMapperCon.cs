using MdFlower.Model.Entity;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MdFlower.Service.Users.Dto;
using MdFlower.Service.Flowerss.Dto;

namespace MdFlower.Service.Config
{
    public class AutoMapperCon : Profile
    {
        //配置映射
        public AutoMapperCon() {
            CreateMap<Flower, FlowerRes>();
            CreateMap<Userss, UserRes>();
            CreateMap<RegisterReq, Userss>();
        }
    }
}
