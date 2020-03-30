using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using PeopleManagement.Data;
using PeopleManagement.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PeopleManagement.Controllers
{
    public class PersonController :Controller
    {
        private readonly IPeopleRepository _repository;
        private readonly ILogger<PersonController> _logger;
        public PersonController(IPeopleRepository repository,ILogger<PersonController> logger)
        {
            _repository = repository;
            _logger = logger;
        }

        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                return Ok( _repository.GetAllPeople());
            }
            catch (Exception ex)
            {

                _logger.LogError($"Failed to get People: {ex}");
                return BadRequest("Failed to get people");
            }
        }
    }
}
