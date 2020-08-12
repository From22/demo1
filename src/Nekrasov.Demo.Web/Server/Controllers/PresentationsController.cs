using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Nekrasov.Demo.Dto.ViewModel;

namespace Nekrasov.Demo.Web.Server.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PresentationsController : ControllerBase
    {
        public PresentationsController()
        {
        }

        [HttpGet]
        public async Task<IEnumerable<FileViewModel>> GetList()
        {
            await Task.CompletedTask;

            var files = new FileViewModel[]
            {
                new FileViewModel
                {
                    Title = new Title{Text = "Это пробный текст", IsWarning=true},
                    Movies = new Movie[]
                    {
                        new Movie{Name="movie.mp4", Number="1", SizeInMb="123.45 Mb"}
                    }
                }
            };

            return files;
        }

        //[HttpGet("content")]
        //public async Task<IEnumerable<FileViewModel>> GetFile()
        //{
        //    await Task.CompletedTask;
        //    return null;
        //}


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
