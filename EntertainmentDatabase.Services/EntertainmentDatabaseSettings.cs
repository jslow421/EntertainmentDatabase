using System;
using System.Collections.Generic;
using System.Text;

namespace EntertainmentDatabase.Services
{
    public class EntertainmentDatabaseSettings: IEntertainmentDatabaseSettings
    {
        public string BooksCollectionName { get; set; }
        public string BoardGamesCollectionName { get; set; }
        public string DvdsCollectionName { get; set; }
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }

    }

    public interface IEntertainmentDatabaseSettings
    {
        string BooksCollectionName { get; set; }
        string BoardGamesCollectionName { get; set; }
        string DvdsCollectionName { get; set; }
        string ConnectionString { get; set; }
        string DatabaseName { get; set; }
    }
}
