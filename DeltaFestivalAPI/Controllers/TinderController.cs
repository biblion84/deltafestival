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
    public class TinderController : ControllerBase
    {
        private readonly ITinderRepository _tinderRepository;
        private readonly ICrushRepository _crushRepository;
        private readonly IIgnoredRepository _ignoredRepository;
        private readonly IUserRepository _userRepository;

        private List<User> usersList = new List<User>();
        List<Crush> currentUserCrushList = new List<Crush>();
        List<Ignored> currentUserIgnoredList = new List<Ignored>();

        public TinderController(ITinderRepository tinderRepository)
        {
            _tinderRepository = tinderRepository;
        }

        public User GetRandomUser(int idCurrentUser)
        {
            //récupération de tous les users, crushes du current user, ignored du currend user dans des listes
            usersList = _userRepository.GetAll().ToList();
            currentUserCrushList = _crushRepository.FindBy(x => x.IdCurrentUser == idCurrentUser).ToList();
            currentUserIgnoredList = _ignoredRepository.FindBy(x => x.IdCurrentUser == idCurrentUser).ToList();

            //suppression de l'utilisateur lui-même pour ne pas se matcher
            usersList.Remove(_userRepository.FindBy(x => x.Id == idCurrentUser).FirstOrDefault());

            //suppression des gens déjà crushed par le current user
            foreach (Crush crush in currentUserCrushList)
            {
                usersList.RemoveAll(x => x.Id == crush.IdCrush);
            }

            //suppression des gens ignorés par le current user
            foreach (Ignored ignored in currentUserIgnoredList)
            {
                usersList.RemoveAll(x => x.Id == ignored.IdIgnored);
            }

            Random random = new Random();
            int index = random.Next(usersList.Count);

            return usersList[index];
        }
    }
}
