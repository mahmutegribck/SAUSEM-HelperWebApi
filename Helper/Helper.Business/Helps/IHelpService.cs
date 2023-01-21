using Helper.Business.Helps.Dtos;
using Helper.Entites.Entites;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Helper.Business.Helps
{
    public interface IHelpService
    {
        Task<List<GetHelpDto>> GetAllHelps();

        Task<List<GetHelpDto>> GetAllUserHelps(string id);

        Task CreateHelp(string IdentityUserId, CreateHelpDto createHelpDto);

        Task DeleteHelp(string IdentityUserId, int deleteId);

        Task UpdateHelp(string IdentityUserId, UpdateHelpDto updateHelpDto);

        Task<GetHelpDto> GetHelpById(int id);

        
    }
}
