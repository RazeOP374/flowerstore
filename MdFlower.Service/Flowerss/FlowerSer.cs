using AutoMapper;
using MdFlower.Common;
using MdFlower.Model.Entity;
using MdFlower.Service.Flowerss.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MdFlower.Service.Flowerss
{
    public class FlowerSer : IFlowerSer
    {
        private readonly IMapper _mapper;
        public FlowerSer(IMapper mapper)
        {
            _mapper = mapper;

        }
        public List<FlowerRes> GetFlowers(FlowerReq req)
        {
            var res = DbContext.db.Queryable<Flower>().WhereIF(req.Id > 0, x => x.Id == req.Id).WhereIF(req.Type > 0, x => x.Type == req.Type).ToList();
            return _mapper.Map<List<FlowerRes>>(res);
        }
    }
}
