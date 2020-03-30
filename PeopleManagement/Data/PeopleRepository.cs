using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using PeopleManagement.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PeopleManagement.Data
{
    public class PeopleRepository : IPeopleRepository
    {
        private readonly PeopleContext _context;
        private readonly ILogger<PeopleRepository> _logger;
        public PeopleRepository(PeopleContext context, ILogger<PeopleRepository> logger )
        {
            _context = context;
            _logger = logger;
        }

        public void AddEntity(object model)
        {
            _context.Add(model);
        }

        public IEnumerable<Group> GetAllGroups()
        {
            try
            {
                return _context.Groups
                        .OrderBy(g => g.GroupId)
                        .ToList();
            }
            catch (Exception ex)
            {
                //_logger.LogError($" Error loading group {ex}");
                throw;
            }
        }

        [HttpGet]
        public IEnumerable<Person> GetAllPeople()
        {
            try
            {
                var result = _context.People
                                     .Include(p=>p.Group);
                return result;
            }
            catch (Exception ex)
            {
                //_logger.LogError($" {ex}");
                //return BadRequestResult;
                throw;
            }
        }

        public Group GetGroupsByGroupName(string groupName)
        {
            return _context.Groups.Where(g => g.GroupName == groupName).FirstOrDefault();
        }

        public bool SaveAll()
        {
            return _context.SaveChanges() > 0;
        }
    }
}
