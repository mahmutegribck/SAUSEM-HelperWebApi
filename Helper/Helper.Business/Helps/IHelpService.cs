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
        Task<List<GetHelpDto>> GetAllCheckedHelps();
        Task<List<GetHelpDto>> GetAllUnCheckedHelps();
        Task<List<GetHelpDto>> GetAllCheckedUserHelps(string id);
        Task<List<GetHelpDto>> GetAllUnCheckedUserHelps(string id);
        Task<List<GetHelpDto>> GetAllUserHelps(string id);
        Task<GetHelpDto> GetHelpById(int id);
        Task<List<GetHelpDto>> GetHelpsByCategoryId(int id);
        Task<bool> CreateHelp(string IdentityUserId, CreateHelpDto createHelpDto);
        Task UpdateHelp(int helpId, string IdentityUserId, UpdateHelpDto updateHelpDto);
        Task<bool> DeleteHelp(string IdentityUserId, int deleteId);
        Task SetCheckedHelp(GetHelpDto checkedHelp);
        Task SetUnCheckedHelp(GetHelpDto unCheckedHelp);
    }
}
