using MongoDB.Driver;
using System.Collections.Generic;
using System.Text;
using EntertainmentDatabase.Core.Entities;
using EntertainmentDatabase.Services;
using EntertainmentDatabase.Services.ServiceInterfaces;
using System.Threading.Tasks;

namespace EntertainmentDatabase.Services
{
    public class BookService: IBookService
    {
        private readonly IMongoCollection<Book> _books;

        public BookService(IEntertainmentDatabaseSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);

            _books = database.GetCollection<Book>(settings.BooksCollectionName);
        }

        public async Task<IEnumerable<Book>> Get() =>
            _books.Find(book => true).ToList();

        public async Task<Book> Get(string id) =>
            _books.Find<Book>(book => book.Id == id).FirstOrDefault();

        public async Task<Book> Create (Book book)
        {
            _books.InsertOne(book);
                return book;
        }
    }
}
