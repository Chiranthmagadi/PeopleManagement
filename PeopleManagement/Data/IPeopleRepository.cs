using PeopleManagement.Data.Entities;
using System.Collections.Generic;

namespace PeopleManagement.Data
{
    public interface IPeopleRepository
    {
        IEnumerable<Group> GetAllGroups();
        IEnumerable<Group> GetGroupsByGroupName(string groupName);
        IEnumerable<Person> GetAllPeople();
        void AddEntity(object model);
        bool SaveAll();
    }
}