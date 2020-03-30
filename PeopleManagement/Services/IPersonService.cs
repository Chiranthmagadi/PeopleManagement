namespace PeopleManagement.Services
{
    public interface IPersonService
    {
        void CreatePerson(string firstName, string lastName, string email, string address);
    }
}