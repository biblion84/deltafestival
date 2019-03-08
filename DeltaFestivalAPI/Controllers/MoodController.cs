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
    public class MoodController : ControllerBase
    {
         private readonly DeltaDbContext _context;
        private readonly IMoodRepository _moodRepository;

        public MoodController(IMoodRepository moodRepository)
        {
            _moodRepository = moodRepository;
        }
                
        // GET api/values
        [HttpGet]
        public ActionResult<List<Mood>> Get()
        {
            return _moodRepository.GetAll().ToList();
        }

        // Get a Mood by Id
        [HttpGet("{id}")]
        public ActionResult<Mood> Get(int id)
        {
            return _moodRepository.FindBy(c => c.Id == id).FirstOrDefault();

        }

        // Add a Mood
        [HttpPost]
        public bool Post(Mood mood)
        {
            try
            {
                _moodRepository.Add(mood);
                _moodRepository.Save();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }

            return true;
        }

        // Update Mood
        [HttpPut("{id}")]
        public void Put(Mood mood)
        {
            try
            {

            }
            catch(Exception e)
            {

            }
        }

        // DELETE Mood
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            Mood currentMood = _moodRepository.FindBy(c => c.Id == id).FirstOrDefault();
            _moodRepository.Delete(currentMood);
            _moodRepository.Save();
        }
    }
}
