using Helper.Entites.Entites;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Helper.DataAccess.Helps
{
    public interface IHelpRepository
    {
        Task<List<Help>> GetAllHelps();
        Task<List<Help>> GetAllCheckedHelps();
        Task<List<Help>> GetAllUnCheckedHelps();
        Task<List<Help>> GetAllCheckedUserHelps(string id);
        Task<List<Help>> GetAllUnCheckedUserHelps(string id);
        Task<List<Help>> GetAllUserHelps(string id);
        Task<Help> GetHelpById(int id);
        Task<List<Help>> GetHelpsByCategoryId(int id);
        Task<bool> CreateHelp(Help help);
        Task UpdateHelp(int helpId, string IdentityUserId, Help help);
        Task<bool> DeleteHelp(string IdentityUserId, int id);
        Task SetCheckedHelp(Help help);
        Task SetUnCheckedHelp(Help help);
    }
}
