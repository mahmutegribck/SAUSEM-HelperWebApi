using Helper.Entities.Entities;
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

        Task<Help> CreateHelp(Help help);
        Task<Help> UpdateHelp(Help help);
        Task DeleteHelp(int id);
    }
}
