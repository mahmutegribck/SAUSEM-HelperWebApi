using Helper.DataAccess.Helps;
using Helper.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Helper.Business.Helps
{
    public class HelpService :IHelpService
    {
        private IHelpRepository _helpRepository;

        public HelpService(IHelpRepository helpRepository)
        {
            _helpRepository = helpRepository;
        }

        public async Task<Help> CreateHelp(Help help)
        {
            return await _helpRepository.CreateHelp(help);
        }

        public async Task DeleteHelp(int id)
        {
            await _helpRepository.DeleteHelp(id);
        }

        public async Task<List<Help>> GetAllHelps()
        {
            return await _helpRepository.GetAllHelps();
        }

        public async Task<Help> GetHelpById(int id)
        {
            if (id > 0)
            {
                return await _helpRepository.GetHelpById(id);
            }
            else
            {
                throw new Exception("Id can not be less than 1");
            }
        }

        public async Task<Help> UpdateHelp(Help help)
        {
            return await _helpRepository.UpdateHelp(help);
        }
    }
}
