using MediatR;
using System;

namespace Adzu.Core.Notifications.Files
{
    public class FileCreatedNotification : INotification
    {
        public Guid Id { get; set; }

        public string Name { get; set; }
        public string Path { get; set; }

        public string ContentType { get; set; }
    }
}
