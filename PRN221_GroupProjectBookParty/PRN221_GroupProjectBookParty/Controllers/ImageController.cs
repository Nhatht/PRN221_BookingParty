using Microsoft.AspNetCore.Mvc;
using PartyService.BlogPosts;
using System.Net;

namespace PRN221_GroupProjectBookParty.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ImageController : Controller
    {
        private readonly ICloudinaryService cloudinaryService;

        public ImageController(ICloudinaryService _cloudinaryService)
        {
            cloudinaryService = _cloudinaryService;
        }

        [HttpPost]
        public async Task<IActionResult> UploadAsync(IFormFile file)
        {
            var imageUrl = await cloudinaryService.UploadAsync(file);

            if (imageUrl == null)
            {
                return Problem("Something went wrong!", null, (int)HttpStatusCode.InternalServerError);
            }

            return Json(new { link = imageUrl });
        }
    }
}
