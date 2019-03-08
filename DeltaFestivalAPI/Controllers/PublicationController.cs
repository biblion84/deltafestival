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
        public List<Publication> GetAll()
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

        // Edit publication
        [HttpPut("{id}")]
        public bool Put(Publication publication)
        {
            try
            {
                Publication olderPublication = _publicationRepository.FindBy(c => c.Id == publication.Id).FirstOrDefault();

                #region Edit properties
                olderPublication.UserId = publication.UserId;
                olderPublication.Message = publication.Message;
                olderPublication.Like = publication.Like;
                olderPublication.Hashtag = publication.Hashtag;
                olderPublication.File = publication.File;
                olderPublication.Date = publication.Date;
                #endregion

                _publicationRepository.Save();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }

            return true;
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