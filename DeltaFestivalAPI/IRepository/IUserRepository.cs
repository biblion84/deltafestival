using DeltaFestivalAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DeltaFestivalAPI.IRepository
{
    public interface IUserRepository : IGenericRepository<User>
    {
        User Authenticate(string ticketCode);
    }
}
