﻿using System;
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

<<<<<<< HEAD
        public TinderController(ITinderRepository tinderRepository, ICrushRepository crushRepository, IIgnoredRepository ignoredRepository, IUserRepository userRepository)
        {
            _tinderRepository = tinderRepository;
            _crushRepository = crushRepository;
            _ignoredRepository = ignoredRepository;
            _userRepository = userRepository;
        }

        public TinderController(ITinderRepository tinderRepository)
        {
            _tinderRepository = tinderRepository;
        }

        /// <summary>
        /// Retourne le premier utilisateur qui n'a pas encore été match ou ignoré par l'user
        /// </summary>
        public User GetRandomUser(int idCurrentUser)
        {
            List<int> excludedUsers = _crushRepository.FindBy(x => x.IdCurrentUser == idCurrentUser).Select(x => x.IdCrush).ToList();
            excludedUsers.AddRange(_ignoredRepository.FindBy(x => x.IdCurrentUser == idCurrentUser).Select(x => x.IdIgnored).ToList());

            return _userRepository.GetRandomUser(excludedUsers);

        }

        

}
