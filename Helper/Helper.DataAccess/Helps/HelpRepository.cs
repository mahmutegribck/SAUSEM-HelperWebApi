using Helper.DataAccess.Categories;
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
        private readonly ICategoryRepository _categoryRepository;
        public HelpRepository(HelperDbContext helperDbContext, ICategoryRepository categoryRepository)
        {
            _helperDbContext = helperDbContext;
            _categoryRepository = categoryRepository;
        }


        public async Task<List<Help>> GetAllHelps()
        {
            var helps = await _helperDbContext.Helps.OrderByDescending(h => h.HelpDate).ToListAsync();

            return helps;
        }

        public async Task<List<Help>> GetAllCheckedHelps()
        {
            var helps = await _helperDbContext.Helps.Where(h => h.HelpCheck == true).OrderByDescending(h => h.HelpDate).ToListAsync();

            return helps;
        }

        public async Task<List<Help>> GetAllUnCheckedHelps()
        {
            var helps = await _helperDbContext.Helps.Where(h => h.HelpCheck == false).OrderByDescending(h => h.HelpDate).ToListAsync();

            return helps;
        }

        public async Task<List<Help>> GetAllCheckedUserHelps(string id)
        {
            var userHelps = await _helperDbContext.Helps.Where(h => h.ApplicationUser.Id == id && h.HelpCheck == true).OrderByDescending(h => h.HelpDate).ToListAsync();

            return userHelps;
        }

        public async Task<List<Help>> GetAllUnCheckedUserHelps(string id)
        {
            var userHelps = await _helperDbContext.Helps.Where(h => h.ApplicationUser.Id == id && h.HelpCheck == false).OrderByDescending(h => h.HelpDate).ToListAsync();

            return userHelps;
        }

        public async Task<List<Help>> GetAllUserHelps(string id)
        {
            var userHelps = await _helperDbContext.Helps.Where(h => h.ApplicationUser.Id == id).OrderByDescending(h => h.HelpDate).ToListAsync();

            return userHelps;
        }

        public async Task<Help> GetHelpById(int id)
        {
            var help = await _helperDbContext.Helps.FindAsync(id);

            return help;
        }

        public async Task<List<Help>> GetHelpsByCategoryId(int id)
        {
            var categoryHelps = await _helperDbContext.Helps.Where(h => h.CategoryId == id && h.HelpCheck == true).ToListAsync();

            return categoryHelps;
        }


        public async Task<bool> CreateHelp(Help help)
        {
            await _helperDbContext.AddAsync(help);
            await _helperDbContext.SaveChangesAsync();
            return true;
        }

        public async Task UpdateHelp(int helpId, string IdentityUserId, Help help)
        {

            var helpUpdate = await _helperDbContext.Helps.FindAsync(helpId);

            if (helpUpdate.ApplicationUserId == IdentityUserId)
            {
                helpUpdate.HelpTitle = help.HelpTitle;
                helpUpdate.HelpText = help.HelpText;
                helpUpdate.HelpDate = help.HelpDate;
                
                if (await _categoryRepository.GetCategorypById(help.CategoryId) != null)
                {
                    helpUpdate.CategoryId = help.CategoryId;
                }
                
                _helperDbContext.Helps.Update(helpUpdate);
                await _helperDbContext.SaveChangesAsync();
            }
            else
            {
                throw new Exception("User can not update this answer");
            }
        }


        public async Task<bool> DeleteHelp(string IdentityUserId, int id)
        {

            var deleteHelp = await GetHelpById(id);

            if (deleteHelp != null)
            {
                if (deleteHelp.ApplicationUserId == IdentityUserId)
                {
                    _helperDbContext.Helps.Remove(deleteHelp);
                    await _helperDbContext.SaveChangesAsync();
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }

        public async Task SetCheckedHelp(Help help)
        {
            var setCheckedHelp = await _helperDbContext.Helps.FindAsync(help.HelpId);
            setCheckedHelp.HelpCheck = true;
            _helperDbContext.Helps.Update(setCheckedHelp);
            await _helperDbContext.SaveChangesAsync();
        }

        public async Task SetUnCheckedHelp(Help help)
        {
            var setUnCheckedHelp = await _helperDbContext.Helps.FindAsync(help.HelpId);
            setUnCheckedHelp.HelpCheck = false;
            _helperDbContext.Helps.Update(setUnCheckedHelp);
            await _helperDbContext.SaveChangesAsync();
        }

        
    }
}
