using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DeltaFestivalAPI.Database;
using DeltaFestivalAPI.IRepository;
using DeltaFestivalAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace DeltaFestivalAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class IgnoredController : ControllerBase
    {
        private readonly IIgnoredRepository _ignoredRepository;

        public IgnoredController (IIgnoredRepository ignoredRepository)
        {
            _ignoredRepository = ignoredRepository;
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public List<Ignored> GetIgnoredByUser(int id)
        {
            return _ignoredRepository.FindBy(c => c.IdCurrentUser == id).ToList();
        }

        // POST api/values
        [HttpPost]
        public void Post(int idCurrentUser, int idCrush)
        {
            _ignoredRepository.Add(
                new Ignored
                {
                    IdCurrentUser = idCurrentUser,
                    IdIgnored = idCrush
                });
            _ignoredRepository.Save();
        }

    }
}
