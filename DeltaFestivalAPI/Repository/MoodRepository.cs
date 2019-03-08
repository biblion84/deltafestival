using DeltaFestivalAPI.Database;
using DeltaFestivalAPI.IRepository;
using DeltaFestivalAPI.Models;
using DeltaFestivalAPI.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DeltaFestivalAPI.Repository
{
    public class MoodRepository : GenericRepository<Mood>, IMoodRepository
    {
        public MoodRepository(DeltaDbContext dbContext) : base(dbContext)
        {
        }
    }
}
