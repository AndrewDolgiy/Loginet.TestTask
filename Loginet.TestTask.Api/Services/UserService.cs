using Loginet.TestTask.Api.Interfaces;
using Microsoft.EntityFrameworkCore;
using TestTask.Loginet.Data.Database;
using TestTask.Loginet.Data.Entities;

namespace Loginet.TestTask.Api.Services
{
    public class UserService : IUserService
    {
        private AppDbContext _context;
        private IJsonPlaceHolderApi _api;

        public UserService(IJsonPlaceHolderApi api, AppDbContext context)
        {
            _api = api;
            _context = context;
        }

        public async Task<List<User>> GetUsers()
        {
            var dbUsers = await _context.Users.ToListAsync();
            if (dbUsers.Count == 0)
            {
                dbUsers = await UpdateDbUsersFromApi();
            }
            return dbUsers;
        }
        private async Task<List<User>>  UpdateDbUsersFromApi()
        {
            var users = await _api.GetUsers();
            var newUsers = new List<User>();
            if (users.Count != 0)
            {
                newUsers = users.Select(x => x.MapToDb()).ToList();
                await _context.Users.AddRangeAsync(newUsers);
                await _context.SaveChangesAsync();
            }
            return newUsers;
        }


        public async Task<User> GetUserById(int Id)
        {
            var user = await _context.Users.FirstOrDefaultAsync(x => x.Id == Id);
            if (user == null)
            {
                user = await UpdateDbUserFromApi(Id);
            }
            return user;
        }
        private async Task<User> UpdateDbUserFromApi(int Id)
        {
            var newUser = await _api.GetUser(Id);
            if (newUser == null)
            {
                throw new ArgumentNullException(nameof(newUser));
            }
            var user = newUser.MapToDb();
            await _context.Users.AddAsync(user);
            await _context.SaveChangesAsync();
            return user;
        }


        public async Task AddNewUsersById(List<int> userIds)
        {
            foreach (var id in userIds)
            {
                await GetUserById(id);
            }
        }
    }
}