using AutoMapper;
using Helper.Business.Answers.Dtos;
using Helper.Business.Helps.Dtos;
using Helper.DataAccess.Helps;
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

        private readonly IMapper _mapper;

        public HelpService(IMapper mapper, IHelpRepository helpRepository)
        {
            _helpRepository = helpRepository;
            _mapper = mapper;
        }

        public async Task CreateHelp(string IdentityUserId, CreateHelpDto createHelpDto)
        {

            Help help = _mapper.Map<Help>(createHelpDto);
            help.IdentityUserId = IdentityUserId;
            await _helpRepository.CreateHelp(help);


        }

        public async Task DeleteHelp(string IdentityUserId, int id)
        {
            await _helpRepository.DeleteHelp(IdentityUserId, id);
        }

        public async Task<List<GetHelpDto>> GetAllHelps()
        {
            var helps = _mapper.Map<List<GetHelpDto>>(await _helpRepository.GetAllHelps());
            return helps.ToList();
            
        }

        public async Task<List<GetHelpDto>> GetAllUserHelps(string id)
        {
            var userHelps = _mapper.Map<List<GetHelpDto>>(await _helpRepository.GetAllUserHelps(id));
            return userHelps.ToList();
        }


        public async Task<GetHelpDto> GetHelpById(int id)
        {
            if (id > 0)
            {
                var userHelp = _mapper.Map<GetHelpDto>(await _helpRepository.GetHelpById(id));  
                return userHelp;
            }
            else
            {
                throw new Exception("Id can not be less than 1");
            }
        }

        public async Task UpdateHelp(string IdentityUserId, UpdateHelpDto updateHelpDto)
        {
            Help help = _mapper.Map<Help>(updateHelpDto);
            await _helpRepository.UpdateHelp(IdentityUserId, help); 

        }

        
    }
}
