using MongoDB.Driver;
using System.Collections.Generic;
using System.Text;
using EntertainmentDatabase.Core.Entities;
using EntertainmentDatabase.Services;

namespace EntertainmentDatabase.Services
{
    public class BookService
    {
        private readonly IMongoCollection<Book> _books;

        public BookService(IEntertainmentDatabaseSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.BooksCollectionName);

            _books = database.GetCollection<Book>(settings.BooksCollectionName);
        }

        public List<Book> Get() =>
            _books.Find(book => true).ToList();

        public Book Get(string id) =>
            _books.Find<Book>(book => book.Id == id).FirstOrDefault();

        public Book Create (Book book)
        {
            _books.InsertOne(book);
                return book;
        }
    }
}
