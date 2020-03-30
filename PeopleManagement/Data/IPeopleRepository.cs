using PeopleManagement.Data.Entities;
using System.Collections.Generic;

namespace PeopleManagement.Data
{
    public interface IPeopleRepository
    {
        IEnumerable<Group> GetAllGroups();
        Group GetGroupsByGroupName(string groupName);
        IEnumerable<Person> GetAllPeople();
        void AddEntity(object model);
        bool SaveAll();
    }
}