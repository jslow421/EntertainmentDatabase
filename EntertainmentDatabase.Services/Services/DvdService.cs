using EntertainmentDatabase.Core.Entities;
using EntertainmentDatabase.Services;
using EntertainmentDatabase.Services.ServiceInterfaces;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace EntertainmentDatabase.Services
{
    public class DvdService : IDvdService
    {
        private readonly IMongoCollection<Dvd> _dvds;
        public DvdService(IEntertainmentDatabaseSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);

            _dvds = database.GetCollection<Dvd>(settings.DvdsCollectionName);
        }
        
        public async Task<IEnumerable<Dvd>> Get() =>
            await _dvds.Find(dvd => true).ToListAsync();

        public async Task<Dvd> Get(string id) =>
            await _dvds.Find<Dvd>(dvd => dvd.Id == id).FirstOrDefaultAsync();
        
        public async Task<Dvd> Create(Dvd dvd)
        {
            await _dvds.InsertOneAsync(dvd);
            return dvd;
        }
    }
}
