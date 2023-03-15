using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MdFlower.Api.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ImageController : ControllerBase
    {
        [HttpGet]
        public List<ImageModel> GetImages()
        {
            List<ImageModel> list = new List<ImageModel>()
            {
                new ImageModel() {ImageUrl="",CourseUrl=""}
            };
            return list;
        }
    }
}
