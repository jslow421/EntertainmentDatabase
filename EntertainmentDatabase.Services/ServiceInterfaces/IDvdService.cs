using EntertainmentDatabase.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace EntertainmentDatabase.Services.ServiceInterfaces
{
    public interface IDvdService
    {
        Task<IEnumerable<Dvd>> Get();
        Task<Dvd> Get(string id);
        Task<Dvd> Create(Dvd dvd);
    }
}
