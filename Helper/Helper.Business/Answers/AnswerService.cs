using AutoMapper;
using Helper.Business.Answers.Dtos;
using Helper.Business.Helps.Dtos;
using Helper.DataAccess.Answers;
using Helper.Entites.Entites;
using Helper.Entites.Identity;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Helper.Business.Answers
{
    public class AnswerService : IAnswerService
    {
        private readonly IMapper _mapper;
        private readonly IAnswerRepository _answerRepository;
        private readonly UserManager<ApplicationUser> _userManager;

        public AnswerService(IMapper mapper, IAnswerRepository answerRepository, UserManager<ApplicationUser> userManager)
        {
            _mapper = mapper;
            _answerRepository = answerRepository;
            _userManager = userManager;
        }

        public async Task CreateAnswer(string IdentityUserId, CreateAnswerDto createAnswerDto)
        {

            Answer answer = _mapper.Map<Answer>(createAnswerDto);
            answer.ApplicationUserId = IdentityUserId;
            await _answerRepository.CreateAnswer(answer);

            //await Task.CompletedTask;
        }

        public async Task DeleteAnswer(string IdentityUserId, int id)
        {
            await _answerRepository.DeleteAnswer(IdentityUserId, id);
        }

        public async Task<List<GetAnswerDto>> GetAllAnswers()
        {
            var answers = _mapper.Map<List<GetAnswerDto>>(await _answerRepository.GetAllAnswers());
            return answers.ToList();
            
        }

        public async Task<List<GetAnswerDto>> GetAllUserAnswers(string id)
        {
            var userAnswers = _mapper.Map<List<GetAnswerDto>>(await _answerRepository.GetAllUserAnswers(id));
            return userAnswers.ToList();
        }



        public async Task<GetAnswerDto> GetAnswerById(int id)
        {

            if (id > 0)
            {
                var userAnswer = _mapper.Map<GetAnswerDto>(await _answerRepository.GetAnswerById(id));
                return userAnswer;
            }
            else
            {
                throw new Exception("Id can not be less than 1");
            }
        }



        public async Task UpdateAnswer(string IdentityUserId, UpdateAnswerDto updateAnswerDto)
        {
            Answer answer = _mapper.Map<Answer>(updateAnswerDto);
            //answer.IdentityUserId = IdentityUserId;
            await _answerRepository.UpdateAnswer(IdentityUserId, answer);
        }


    }
}
