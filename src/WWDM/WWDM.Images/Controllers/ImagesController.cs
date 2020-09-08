using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace WWDM.Images.Controllers
{
    [Route("/images")]
    public class ImagesController : Controller
    {
        private readonly WWDMContext _context;
        private readonly ILogger<ImagesController> _logger;
        private readonly IOptions<ImageOptions> _options;

        public ImagesController(ILogger<ImagesController> logger, WWDMContext context, IOptions<ImageOptions> options)
        {
            _logger = logger;
            _context = context;
            _options = options;
        }

        [Route("{id:int}")]
        public async Task<IActionResult> View(int id)
        {
            var image = await _context.Images.Include(im => im.Episode).ThenInclude(ep => ep.Season).FirstOrDefaultAsync(im => im.Id == id);
            var absolutePath = Path.Combine(_options.Value.RootPath, image.Episode.ImageFolder, image.Filename);
            return File(System.IO.File.OpenRead(absolutePath), "image/jpeg");
        }
    }
}