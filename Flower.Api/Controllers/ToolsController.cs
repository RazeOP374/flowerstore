using MdFlower.Common;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MdFlower.Api.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ToolsController : ControllerBase
    {
        [HttpGet]
        public void InitDatabase()
        {
            DbContext.InitDataBase();
        }
    }
}
