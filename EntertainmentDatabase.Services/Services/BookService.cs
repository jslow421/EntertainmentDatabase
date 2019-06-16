using MongoDB.Driver;
using System.Collections.Generic;
using System.Text;
using EntertainmentDatabase.Core.Entities;
using EntertainmentDatabase.Services;

namespace EntertainmentDatabase.Core.Services
{
    public class BookService
    {
        private readonly IMongoCollection<Book> _books;

        public BookService(IEntertainmentDatabaseSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.BooksCollectionName);

            _books = database.GetCollection<Book>(settings.BooksCollectionName);]
        }
    }
}
