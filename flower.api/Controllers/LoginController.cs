using MdFlower.Model;
using MdFlower.Service.Users;
using MdFlower.Service.Users.Dto;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MdFlower.Api.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        public IUserService _userService;
      //  public ICustomJWTService _customJWTService;
       public LoginController(IUserService userService)
        {
            _userService = userService;
           
        }



        /// <summary>
        /// 登录
        /// </summary>
        /// <param name="req"></param>
        /// <returns></returns>
        [HttpPost]
        public ApiResult Check(UserReq req)
        {
      //          var currCode = MemoryHelper.GetMemory(req.ValidateKey);
            ApiResult apiResult = new ApiResult() { IsSuccess = false };
            if (string.IsNullOrEmpty(req.UserName) || string.IsNullOrEmpty(req.Password) || string.IsNullOrEmpty(req.ValidateKey) || string.IsNullOrEmpty(req.ValidateCode))
            {
                apiResult.Msg = "参数不能为空！";
            }
         //   else if (currCode == null)
           // {
             //   apiResult.Msg = "验证码不存在，请刷新验证码！";
            //}
            //else if (currCode.ToString() != req.ValidateCode)
            //{
              //  apiResult.Msg = "验证码错误，请重新输入或刷新重试！";
            //}
            else
            {
                UserRes user = _userService.GetUsers(req);
                if (string.IsNullOrEmpty(user.UserName))
                {
                    apiResult.Msg = "账号不存在，用户名或密码错误！";
                }
                else
                {
                    apiResult.IsSuccess = true;
                    apiResult.Result = "";// _customJWTService.GetToken(user);
                }
            }
            return apiResult;
        }


        /// 注册
        /// </summary>
        /// <param name="req"></param>
        /// <returns></returns>
        [HttpPost]
        public ApiResult Register(RegisterReq req)
        {
         //   var currCode = MemoryHelper.GetMemory(req.ValidateKey);
            ApiResult apiResult = new ApiResult() { IsSuccess = false };
            if (string.IsNullOrEmpty(req.UserName) || string.IsNullOrEmpty(req.Password) || string.IsNullOrEmpty(req.NickName) || string.IsNullOrEmpty(req.ValidateKey) || string.IsNullOrEmpty(req.ValidateCode))
            {
                apiResult.Msg = "参数不能为空！";
            }
       //     else if (currCode == null)
         //   {
           //     apiResult.Msg = "验证码不存在，请刷新验证码！";
            //}
            //else if (currCode.ToString() != req.ValidateCode)
            //{
              //  apiResult.Msg = "验证码错误，请重新输入或刷新重试！";
           // }
            else
            {
                string msg = string.Empty;
                var res = _userService.RegisterUser(req, ref msg);
                if (!string.IsNullOrEmpty(msg))
                {
                    apiResult.Msg = msg;
                }
                else
                {
                    apiResult.IsSuccess = true;
                    apiResult.Result = "";//_customJWTService.GetToken(res);
                }
            }
            return apiResult;
        }
    }
}
