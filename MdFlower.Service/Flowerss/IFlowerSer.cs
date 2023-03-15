using MdFlower.Service.Flowerss.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MdFlower.Service.Flowerss
{
    public interface IFlowerSer
    {
        List<FlowerRes> GetFlowers(FlowerReq req);
    }
}
