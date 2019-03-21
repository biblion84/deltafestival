using DeltaFestivalAPI.Database;
using DeltaFestivalAPI.IRepository;
using DeltaFestivalAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace DeltaFestivalAPI.Repository
{
    public class CrushRepository : GenericRepository<Crush>, ICrushRepository
    {
        public CrushRepository(DeltaDbContext dbContext) : base(dbContext)
        {
        }
    }
}
