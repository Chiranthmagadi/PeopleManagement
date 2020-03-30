using Microsoft.Extensions.Logging;
using PeopleManagement.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PeopleManagement.Data
{
    public class PeopleRepository : IPeopleRepository
    {
        private readonly PeopleContext _context;
        public PeopleRepository(PeopleContext context)
        {
            _context = context;

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
                //_logger.LogError(ex.InnerException.ToString());
                throw ex;
            }
        }

        public IEnumerable<Person> GetAllPeople()
        {
            try
            {
                var result = _context.People
                                .OrderBy(p => p.FirstName)
                                .ToList();
                return result;
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public IEnumerable<Group> GetGroupsByGroupName(string groupName)
        {
            return _context.Groups
                            .Where(g => g.GroupName == groupName)
                            .ToList();
        }

        public bool SaveAll()
        {
            return _context.SaveChanges() > 0;
        }
    }
}
