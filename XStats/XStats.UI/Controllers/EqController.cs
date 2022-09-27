using Microsoft.AspNetCore.Mvc;
using XStats.Repos;

namespace XStats.UI.Controllers
{
    public class EqController : Controller
    {
        private readonly EqRepository eqRepository;
        private readonly IWebHostEnvironment webHostEnvironment;

        public EqController(EqRepository eqRepository,
            IWebHostEnvironment webHostEnvironment)
        {
            this.eqRepository = eqRepository;
            this.webHostEnvironment = webHostEnvironment;
        }

        //eq/icon/@id
        [HttpGet]
        public async Task<FileResult> Icon(int id)
        {
            var mimeType = "image/png";
            var eqType = await eqRepository.GetTypeByIdAsync(id);
            var filePath = Path.Combine(webHostEnvironment.WebRootPath, eqType.IconPath);

            Console.WriteLine($"FILE PATH: {filePath}");

            if(!System.IO.File.Exists(filePath))
            {
                filePath = Path.Combine(webHostEnvironment.WebRootPath, @"Images\eq\no-photo.png");
            }

            return PhysicalFile(filePath, mimeType);
        }
    }
}
