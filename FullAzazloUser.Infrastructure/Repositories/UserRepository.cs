using FullAzazloUser.Domain.Entities;
using FullAzazloUser.Domain.Interfaces;
using FullAzazloUser.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace FullAzazloUser.Infrastructure.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly FullAzazloDBContext _dbContext;
        public UserRepository(FullAzazloDBContext dBContext)
        {
            _dbContext = dBContext;
        }
        public async Task<IEnumerable<User>> GetAllUsersAsync()
        {
            var allU = await _dbContext.Users.ToListAsync();
            if(allU == null)
            {
                return null;
            }
            return allU;
        }
        public async Task<User> GetUserByIdAsync(int id)
        {
            return await _dbContext.Users.FindAsync(id);
        }
        public async Task CreateUserAsync(User user)
        {
            await _dbContext.Users.AddAsync(user);
            await _dbContext.SaveChangesAsync();
        }
        public async Task UpdateUserAsync(User user)
        {
            _dbContext.Users.Update(user);
            await _dbContext.SaveChangesAsync();
        }
        public async Task DeleteUserAsync(int id)
        {
            var user = await _dbContext.Users.FindAsync(id);
            if(user != null)
            {
                _dbContext.Users.Remove(user);
                await _dbContext.SaveChangesAsync();
            }
        }
    }
}
