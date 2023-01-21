using Helper.Entites.Entites;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Helper.DataAccess.Helps
{
    public interface IHelpRepository
    {
        Task<List<Help>> GetAllHelps();

        Task<List<Help>> GetAllUserHelps(string id);

        Task<Help> GetHelpById(int id);

        Task CreateHelp(Help help);

        Task UpdateHelp(string IdentityUserId, Help help);

        Task DeleteHelp(string IdentityUserId, int id);

    }
}
