using EntertainmentDatabase.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace EntertainmentDatabase.Services.ServiceInterfaces
{
    public interface IBookService
    {
        Task<IEnumerable<Book>> Get();
        Task<Book> Get(string id);
        Task<Book> Create(Book book);
    }
}
