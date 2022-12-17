using Helper.Entites.Entites;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Helper.DataAccess.Helps
{
    public class HelpRepository : IHelpRepository
    {
        //private readonly HelperDbContext _helperDbContext;
        //public HelpRepository(HelperDbContext helperDbContext)
        //{
        //    _helperDbContext = helperDbContext;
        //}
        public async Task<Help> CreateHelp(int categoryId, int userId, Help help)
        {
            using (var helperDbContext = new HelperDbContext())
            {
                var helpCategoryClient = await helperDbContext.Categories.Where(c => c.CategoryId == categoryId).FirstOrDefaultAsync();
                var helpUserClient = await helperDbContext.Users.Where(u => u.UserID == userId).FirstOrDefaultAsync();

                var helpCategory = new Help()
                {
                    Category = helpCategoryClient,
                };
                helperDbContext.Add(helpCategory);

                // var helpUser = new Help()
                //{ User = helpUserClient, };

                // helperDbContext.Add(helpUser);
                helperDbContext.Add(help);

                // _helperDbContext.Helps.Add(help);
                // await _helperDbContext.SaveChangesAsync();
                return help;
            }
        }

        public async Task DeleteHelp(int id)
        {
            using (var helperDbContext = new HelperDbContext())
            {
                var deleteHelp = await GetHelpById(id);
                helperDbContext.Helps.Remove(deleteHelp);
                await helperDbContext.SaveChangesAsync();
            }
        }

        public async Task<List<Help>> GetAllHelps()
        {
            using (var helperDbContext = new HelperDbContext())
            {
                return await helperDbContext.Helps.ToListAsync();
            }
        }

        public async Task<Help> GetHelpById(int id)
        {
            using (var helperDbContext = new HelperDbContext())
            {
                return await helperDbContext.Helps.FindAsync(id);
            }
        }

        public async Task<Help> UpdateHelp(Help help)
        {
            using (var helperDbContext = new HelperDbContext())
            {
                helperDbContext.Helps.Update(help);
                await helperDbContext.SaveChangesAsync();
                return help;

            }
        }
    }
}
