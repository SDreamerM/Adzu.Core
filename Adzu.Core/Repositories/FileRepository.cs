using Adzu.Core.Entities;
using MongoDB.Driver;
using System;
using System.Threading.Tasks;

namespace Adzu.Core.Repositories
{
    public interface IFileRepository
    {
        Task CreateFileAsync(Guid id, string name, string path, string contentType);
    }

    public class FileRepository : IFileRepository
    {
        private readonly IMongoCollection<File> _files;

        public FileRepository(string connection)
        {
            var client = new MongoClient(connection);
            var database = client.GetDatabase("Adzu");

            _files = database.GetCollection<File>("Files");
        }

        public async Task CreateFileAsync(Guid id, string name, string path, string contentType)
        {
            await _files.InsertOneAsync(new File { Id = id, Name = name, Path = path, ContentType = contentType });
        }
    }
}
