using AutoMapper;
using Helper.Business.Answers.Dtos;
using Helper.Business.Helps.Dtos;
using Helper.Business.Users.Dtos;
using Helper.DataAccess.Helps;
using Helper.DataAccess.Users;
using Helper.Entites.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Helper.Business.Helps
{
    public class HelpService : IHelpService
    {
        private readonly IHelpRepository _helpRepository;
        private readonly IUserRepository _userRepository;

        private readonly IMapper _mapper;

        public HelpService(IMapper mapper, IHelpRepository helpRepository, IUserRepository userRepository)
        {
            _helpRepository = helpRepository;
            _mapper = mapper;
            _userRepository = userRepository;
        }


        public async Task<List<GetHelpDto>> GetAllHelps()
        {     
            var helps = _mapper.Map<List<GetHelpDto>>(await _helpRepository.GetAllHelps());
            return helps.ToList();
        }

        public async Task<List<GetHelpDto>> GetAllCheckedHelps()
        {
            var helps = _mapper.Map<List<GetHelpDto>>(await _helpRepository.GetAllCheckedHelps());
            return helps.ToList();
        }

        public async Task<List<GetHelpDto>> GetAllUnCheckedHelps()
        {
            var helps = _mapper.Map<List<GetHelpDto>>(await _helpRepository.GetAllUnCheckedHelps());
            return helps.ToList();
        }

        public async Task<List<GetHelpDto>> GetAllCheckedUserHelps(string id)
        {
            var helps = _mapper.Map<List<GetHelpDto>>(await _helpRepository.GetAllCheckedUserHelps(id));
            return helps.ToList();
        }

        public async Task<List<GetHelpDto>> GetAllUnCheckedUserHelps(string id)
        {
            var helps = _mapper.Map<List<GetHelpDto>>(await _helpRepository.GetAllUnCheckedUserHelps(id));
            return helps.ToList();
        }

        public async Task<List<GetHelpDto>> GetAllUserHelps(string id)
        {
            var userHelps = _mapper.Map<List<GetHelpDto>>(await _helpRepository.GetAllUserHelps(id));
            return userHelps.ToList();
        }

        public async Task<GetHelpDto> GetHelpById(int id)
        {
            var userHelp = _mapper.Map<GetHelpDto>(await _helpRepository.GetHelpById(id));
            return userHelp;
        }

        public async Task<List<GetHelpDto>> GetHelpsByCategoryId(int id)
        {
            var categoryHelps = _mapper.Map<List<GetHelpDto>>(await _helpRepository.GetHelpsByCategoryId(id));
            return categoryHelps;
        }

        public async Task<bool> CreateHelp(string IdentityUserId, CreateHelpDto createHelpDto, List<string> tags)
        {
            Help help = _mapper.Map<Help>(createHelpDto);
            help.ApplicationUserId = IdentityUserId;
            help.HelpDate = DateTime.Now;
            foreach (var tag in tags)
            {
                Tag tagHelp= _mapper.Map<Tag>(tag);
                help.Tags.Add(tagHelp);
            }
            return await _helpRepository.CreateHelp(help);
        }

        public async Task UpdateHelp(int helpId, string IdentityUserId, UpdateHelpDto updateHelpDto)
        {
            Help help = _mapper.Map<Help>(updateHelpDto);
            await _helpRepository.UpdateHelp(helpId, IdentityUserId, help);

        }

        public async Task<bool> DeleteHelp(string IdentityUserId, int id)
        {
            return await _helpRepository.DeleteHelp(IdentityUserId, id);
        }

        public async Task SetCheckedHelp(GetHelpDto checkedHelp)
        {
            Help help = _mapper.Map<Help>(checkedHelp);
            await _helpRepository.SetCheckedHelp(help);
        }

        public async Task SetUnCheckedHelp(GetHelpDto unCheckedHelp)
        {
            Help help = _mapper.Map<Help>(unCheckedHelp);
            await _helpRepository.SetUnCheckedHelp(help);
        }

        
    }
}
