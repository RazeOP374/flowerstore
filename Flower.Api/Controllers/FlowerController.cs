using MdFlower.Api;
using MdFlower.Model;
using MdFlower.Service.Flowerss;
using MdFlower.Service.Flowerss.Dto;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MdFlower.Api.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class FlowerController : ControllerBase
    {
        public IFlowerSer _flowerSer;
        public FlowerController(IFlowerSer flowerSer)
        {

            _flowerSer = flowerSer;

        }
        [HttpPost]
        public ApiResult GetFlowers(FlowerReq req)
        {
            ApiResult apiResult = new ApiResult() { IsSuccess = true };
            apiResult.Result = _flowerSer.GetFlowers(req);

            return apiResult;
        }
    }
}
