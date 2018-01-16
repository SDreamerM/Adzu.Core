using System;
using System.Threading;
using System.Threading.Tasks;
using Adzu.Core.Notifications.Files;
using Adzu.Core.Repositories;
using MediatR;

namespace Adzu.Core.NotificationHandlers
{
    public class FileNotificationHandler : INotificationHandler<FileCreatedNotification>
    {
        private readonly IFileRepository _fileRepository;

        public FileNotificationHandler(IFileRepository fileRepository)
        {
            _fileRepository = fileRepository ?? throw new ArgumentNullException(nameof(fileRepository));
        }

        public async Task Handle(FileCreatedNotification notification, CancellationToken cancellationToken)
        {
            await _fileRepository.CreateFileAsync(notification.Id, notification.Name, notification.Path, notification.ContentType);
        }
    }
}
