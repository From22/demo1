using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Nekrasov.Demo.Application.Services.Abstraction;
using Nekrasov.Demo.Dto.ViewModel;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Nekrasov.Demo.Web.Server.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PresentationsController : ControllerBase
    {
        private readonly ILogger<PresentationsController> _logger;
        private readonly IFileService _fileService;

        public PresentationsController(ILogger<PresentationsController> logger, IFileService fileService)
        {
            _logger = logger;
            _fileService = fileService;
        }

        [HttpGet]
        public async Task<IEnumerable<FileViewModel>> GetList()
        {
            IEnumerable<FileViewModel> files = null;
            try
            {
                files = await _fileService.GetListAsync(HttpContext.Request.Host.Value);
            }
            catch (Exception e)
            {
                _logger.LogError(e, $"{HttpContext.Request}");
            }

            return files;
        }

        [HttpGet("content/{videoId}")]
        public async Task<FileContentResult> GetFile(string videoId, [FromServices] IContentService contentService)
        {
            var (content, contentType) = await contentService.ReadVideoAsync(videoId);
            return File(content, contentType);
        }


        [HttpPost]
        public async Task<StatusCodeResult> Post()
        {
            try
            {
                foreach (var file in HttpContext.Request.Form.Files.ToList())
                {
                    byte[] bytes;
                    await using (var content = new MemoryStream())
                    {

                        await file.CopyToAsync(content);
                        content.Seek(0, SeekOrigin.Begin);
                        bytes = content.ToArray();
                    }

                    await _fileService.UploadAsync(bytes, file.FileName);
                }
                return Ok();
            }
            catch (Exception e)
            {
                _logger.LogError(e, $"{HttpContext.Request}");
                return BadRequest();
            }
        }
    }
}
