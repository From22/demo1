using System.Collections.Generic;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Nekrasov.Demo.Blazor.Server.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class FileController : ControllerBase
    {
        public FileController()
        {
        }

        [HttpPost]
        public async Task Post()
        {
            if (HttpContext.Request.Form.Files.Any())
            {
                foreach (var file in HttpContext.Request.Form.Files.ToList())
                {
                    await using var stream = new MemoryStream();

                    await file.CopyToAsync(stream);
                }
            }
        }
    }
}
