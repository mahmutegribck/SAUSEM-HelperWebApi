using Helper.Entities.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Helper.DataAccess.Helps
{
    public class HelpRepository : IHelpRepository
    {
        public async Task<Help> CreateHelp(Help help)
        {
            using (var helperDbContext = new HelperDbContext())
            {
                helperDbContext.Helps.Add(help);
                await helperDbContext.SaveChangesAsync();
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
