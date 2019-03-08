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
    public class PublicationController : ControllerBase
    {

        private readonly DeltaDbContext _context;
        private readonly IPublicationRepository _publicationRepository;


        public PublicationController(IPublicationRepository publicationRepository)
        {
            _publicationRepository = publicationRepository;
        }

        // GET all list of publication
        [HttpGet]
        public List<Publication> Get()
        {
           return _publicationRepository.GetAll().ToList();
        }

        // GET publication by id
        [HttpGet("{id}")]
        public Publication Get(int id)
        {
            return _publicationRepository.FindBy(c => c.Id == id).FirstOrDefault();
        }

        // Inset publication
        [HttpPost]
        public bool Post(Publication publication)
        {
            try
            {
                _publicationRepository.Add(publication);
                _publicationRepository.Save();
            }
            catch(Exception e)
            {
                throw new Exception(e.Message);
            }

            return true;
        }

        // Edit 
        [HttpPut("{id}")]
        public void Put(Publication publication)
        {
           
        }

        // DELETE publication by id
        [HttpDelete("{id}")]
        public bool Delete(int id)
        {
            try
            {
                Publication publication = _publicationRepository.FindBy(c => c.Id == id).FirstOrDefault();
                _publicationRepository.Delete(publication);
                _publicationRepository.Save();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }

            return true;
        }
    }
}
