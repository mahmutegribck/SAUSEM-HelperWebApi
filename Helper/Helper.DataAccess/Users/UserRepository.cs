using Helper.Entites.Entites;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Helper.DataAccess.Users
{
    public class UserRepository : IUserRepository
    {
        public async Task<User> CreateUser(User user)
        {
            using (var helperDbContext = new HelperDbContext())
            {
                helperDbContext.Users.Add(user);
                await helperDbContext.SaveChangesAsync();
                return user;
            }
        }

        public async Task DeleteUser(int id)
        {
            using (var helperDbContext = new HelperDbContext())
            {
                var deleteUser = await GetUserById(id);
                helperDbContext.Users.Remove(deleteUser);
                await helperDbContext.SaveChangesAsync();
            }
        }

        public async Task<List<User>> GetAllUsers()
        {
            using (var helperDbContext = new HelperDbContext())
            {
                return await helperDbContext.Users.OrderBy(u => u.UserID).ToListAsync();
            }
        }

        public async Task<User> GetUserById(int id)
        {
            using (var helperDbContext = new HelperDbContext())
            {
                return await helperDbContext.Users.FindAsync(id);
            }
        }

        public async Task<User> UpdateUser(User user)
        {
            using (var helperDbContext = new HelperDbContext())
            {
                helperDbContext.Users.Update(user);
                await helperDbContext.SaveChangesAsync();
                return user;

            }
        }
    }
}
