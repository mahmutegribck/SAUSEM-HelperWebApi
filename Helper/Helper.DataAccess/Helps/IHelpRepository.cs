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
        Task<Help> GetHelpById(int id);

        Task<Help> CreateHelp(int categoryId, int userId, Help help);
        Task<Help> UpdateHelp(Help help);
        Task DeleteHelp(int id);
    }
}
