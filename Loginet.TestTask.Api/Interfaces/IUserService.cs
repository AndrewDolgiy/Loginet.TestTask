using TestTask.Loginet.Data.Entities;

namespace Loginet.TestTask.Api.Interfaces
{
    public interface IUserService
    {
        Task AddNewUsersById(List<int> userIds);
        Task<User> GetUserById(int Id);
        Task<List<User>> GetUsers();
    }
}