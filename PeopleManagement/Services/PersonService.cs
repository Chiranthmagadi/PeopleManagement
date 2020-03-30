using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PeopleManagement.Services
{
    public class PersonService : IPersonService
    {
        private readonly ILogger<PersonService> _logger;
        public PersonService(ILogger<PersonService> logger)
        {
            _logger = logger;
        }
        public void CreatePerson(String firstName, string lastName, string email, string address)
        {
            _logger.LogInformation($"Creating person detail:{firstName} {lastName}");

        }
    }
}
