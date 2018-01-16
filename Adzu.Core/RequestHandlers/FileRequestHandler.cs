using Adzu.Core.Requests.Files;
using Adzu.Core.Services;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Adzu.Core.RequestHandlers
{
    public class FileRequestHandler : IRequestHandler<CreateFileRequest>
    {
        private readonly IFileService _fileService;

        public FileRequestHandler(IFileService fileService)
        {
            _fileService = fileService ?? throw new ArgumentNullException(nameof(fileService));
        }

        public async Task Handle(CreateFileRequest message, CancellationToken cancellationToken)
        {
            await _fileService.CreateFileAsync(message);
        }
    }
}
