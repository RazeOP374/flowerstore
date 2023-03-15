using MdFlower.Model;
using MdFlower.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;


namespace MdFlower.Api.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    [Authorize]
    public class OrderController : ControllerBase
    {
        private readonly ILogger<OrderController> _logger;
        private IOrderService _orderService;
        public OrderController(IOrderService orderService, ILogger<OrderController> logger)
        {
            _orderService = orderService;
            _logger = logger;
        }
        /// <summary>
        /// 创建订单
        /// </summary>
        /// <param name="req"></param>
        /// <returns></returns>
        [HttpPost]
        public ApiResult CreateOrder(OrderReq req)
        {
            ApiResult apiResult = new ApiResult() { IsSuccess = false };
            if (req.FlowerId == 0)
            {
                apiResult.Msg = "参数不可以为空！";
            }
            else
            {
                string msg = string.Empty;
                long userId = Convert.ToInt32(HttpContext.User.Claims.ToList()[0].Value);
                bool res = _orderService.CreateOrder(req, userId, ref msg);
                if (!string.IsNullOrEmpty(msg))
                {
                    apiResult.Msg = msg;
                }
                else
                {
                    apiResult.IsSuccess = res;
                }
            }
            return apiResult;
        }


        [HttpPost]
        public ApiResult GetOrder()
        {
            ApiResult apiResult = new ApiResult() { IsSuccess = true };
            try
            {
                long userId = Convert.ToInt32(HttpContext.User.Claims.ToList()[0].Value);
                apiResult.Result = _orderService.GetOrder(userId);
                _logger.LogInformation("this is GetOrder。。。");
            }
            catch (Exception ex)
            {
                apiResult.IsSuccess = false;
                apiResult.Msg = ex.Message;
            }
            return apiResult;
        }

    }
}
