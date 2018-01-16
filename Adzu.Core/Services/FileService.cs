using Adzu.Core.Notifications.Files;
using Adzu.Core.Requests.Files;
using MediatR;
using System;
using System.Threading.Tasks;

namespace Adzu.Core.Services
{
    public interface IFileService
    {
        Task CreateFileAsync(CreateFileRequest request);
    }

    public class FileService : IFileService
    {
        private readonly IMediator _mediator;

        public FileService(IMediator mediator)
        {
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }

        public async Task CreateFileAsync(CreateFileRequest request)
        {
            await _mediator.Publish(new FileCreatedNotification { Id = request.Id, Name = request.Name, Path = request.Path, ContentType = request.ContentType });
        }
    }
}
