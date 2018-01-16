using Adzu.Core.Requests.Files;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Adzu.Core.Controllers
{
    [Route("api/files")]
    public class FilesController : Controller
    {
        private readonly IMediator _mediator;

        public FilesController(IMediator mediator)
        {
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }

        [HttpPost]
        public async Task<IActionResult> CreateAsync()
        {
            var filePath = Path.GetTempFileName();
            var file = Request.Form.Files.SingleOrDefault();
            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                await file.CopyToAsync(stream);
            }

            var request = new CreateFileRequest { Path = filePath, Name = file.Name, ContentType = file.ContentType };
            await _mediator.Send(request);

            return Ok(request.Id);
        }
    }
}
