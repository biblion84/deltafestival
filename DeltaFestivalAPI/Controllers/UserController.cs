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
    public class UserController : ControllerBase
    {

        private readonly DeltaDbContext _context;
        private readonly IUserRepository _userRepository;

        public UserController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        // GET all user
        [HttpGet]
        public List<User> GetAll()
        {
            return _userRepository.GetAll().ToList();
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public User Get(int id)
        {
            return _userRepository.FindBy(c => c.Id == id).FirstOrDefault();
        }

        // Add user
        [HttpPost]
        public bool Post(User user)
        {
            try
            {
                _userRepository.Add(user);
                _userRepository.Save();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }

            return true;
        }

        // Edit User
        [HttpPut("{id}")]
        public bool Put(User user)
        {
            try
            {
                User olderUser = _userRepository.FindBy(c => c.Id == user.Id).FirstOrDefault();

                #region Edit properties
                olderUser.MoodId = user.MoodId;
                olderUser.Publications = user.Publications;
                olderUser.Role = user.Role;
                olderUser.TicketCode = user.TicketCode;
                #endregion
                
                _userRepository.Save();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }

            return true;
        }

        // DELETE user by id
        [HttpDelete("{id}")]
        public bool Delete(int id)
        {
            try
            {
                User user = _userRepository.FindBy(c => c.Id == id).FirstOrDefault();
                _userRepository.Delete(user);
                _userRepository.Save();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }

            return true;
        }
    }
}
