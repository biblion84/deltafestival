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

        // GET api/values/5/6
        [HttpGet("{idCurrentUser}/{idCrush}")]
        public Crush Get(int idCurrentUser, int idCrush)
        {
            return _crushRepository.FindBy(c => c.IdCurrentUser == idCurrentUser && c.IdCrush == idCrush).FirstOrDefault();
        }

        // GET api/values/5
        [HttpGet("{idCurrentUser}")]
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


        //check si le current user a été crushed par la personne qui l'intéresse
        public bool IsDoubleCrush(int idCurrentUser, int idCrush)
        {
            Crush crush = Get(idCrush, idCurrentUser);
            return !(crush == null);
        }

        // DELETE user by id
        [HttpDelete("{id}")]
        public void Delete(int idCurrentUser, int idCrush)
        {
            Crush crush = Get(idCurrentUser, idCrush);
            _crushRepository.Delete(crush);
            //rajouter new ignored(idCurrentUser, idCrush)
        }
    }
}
