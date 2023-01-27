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
        private readonly HelperDbContext _helperDbContext;
        public HelpRepository(HelperDbContext helperDbContext)
        {
            _helperDbContext = helperDbContext;
        }
        public async Task CreateHelp(Help help)
        {
            help.HelpDate = DateTime.Now;
            await _helperDbContext.Helps.AddAsync(help);
            await _helperDbContext.SaveChangesAsync();              
            
        }

        public async Task DeleteHelp(string IdentityUserId, int id)
        {
            
            var deleteHelp = await GetHelpById(id);

            if (deleteHelp != null)
            {
                if(deleteHelp.ApplicationUserId ==IdentityUserId)
                {
                    _helperDbContext.Helps.Remove(deleteHelp);
                    await _helperDbContext.SaveChangesAsync();
                }
                else
                {
                    throw new Exception("User can not delete this help.");
                }
            }
            else
            {
                throw new Exception("Not Found Answer");
            }
            
        }

        public async Task<List<Help>> GetAllHelps()
        {

            var helps = await _helperDbContext.Helps.OrderByDescending(h => h.HelpDate).ToListAsync();

            if (helps.Count > 0)
            {
                return helps;
            }
            else
            {
                throw new Exception("Not Found Help");
            }

        }

        public async Task<List<Help>> GetAllUserHelps(string id)
        {
            var userHelps = await _helperDbContext.Helps.Where(h => h.ApplicationUser.Id == id).OrderByDescending(h => h.HelpDate).ToListAsync();

            if (userHelps.Count > 0)
            {
                return userHelps;
            }
            else
            {
                throw new Exception("Not Found User Helps");
            }
        }

        public async Task<Help> GetHelpById(int id)
        {
            var help = await _helperDbContext.Helps.FindAsync(id);
            if(help != null)
            {
                return help;
            }
            else
            {
                throw new Exception("Not Found Help");
            }
        }

        public async Task UpdateHelp(string IdentityUserId, Help help)
        {

            var helpUpdate = await _helperDbContext.Helps.FindAsync(help.HelpId);

            if(helpUpdate != null )
            {
                if(helpUpdate.ApplicationUserId == IdentityUserId)
                {
                    _helperDbContext.Helps.Update(help);
                    await _helperDbContext.SaveChangesAsync();
                }
                else
                {
                    throw new Exception("User can not update this answer");
                }
            }
            else
            {
                throw new Exception("Not Found Answer");
            }
        }
    }
}
