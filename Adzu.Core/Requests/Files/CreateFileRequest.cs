using MediatR;
using System;

namespace Adzu.Core.Requests.Files
{
    public class CreateFileRequest : IRequest
    {
        public Guid Id { get; set; }

        public string Name { get; set; }
        public string Path { get; set; }

        public string ContentType { get; set; }

        public CreateFileRequest() => Id = Guid.NewGuid();
    }
}
