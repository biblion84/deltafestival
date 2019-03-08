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
    public class CrushController : ControllerBase
    {
        private readonly ICrushRepository _crushRepository;

        public CrushController(ICrushRepository crushRepository)
        {
            _crushRepository = crushRepository;
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public List<Crush> GetCrushesByUser(int idCurrentUser)
        {
            return _crushRepository.FindBy(c => c.IdCurrentUser == idCurrentUser).ToList();
        }

        // POST api/values
        [HttpPost]
        public void Post(int idCurrentUser, int idCrush)
        {
            _crushRepository.Add(
                new Crush
            {
                IdCurrentUser = idCurrentUser,
                IdCrush = idCrush
            });
            _crushRepository.Save();
        }

        public void CheckIfDoubleCrush()
        {

        }
    }
}
