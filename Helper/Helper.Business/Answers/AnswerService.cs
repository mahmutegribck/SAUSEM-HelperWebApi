using AutoMapper;
using Helper.Business.Answers.Dtos;
using Helper.DataAccess.Answers;
using Helper.Entites.Entites;
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

        public AnswerService(IMapper mapper, IAnswerRepository answerRepository)
        {
            _mapper = mapper;
            _answerRepository = answerRepository;
        }

        public async Task CreateAnswer(int helpId, CreateAnswerDto createAnswerDto)
        {
            var answer = _mapper.Map<Answer>(createAnswerDto);

            await _answerRepository.CreateAnswer(helpId, answer);

            //await Task.CompletedTask;
        }

        public async Task DeleteAnswer(int id)
        {
            await _answerRepository.DeleteAnswer(id);
        }

        public async Task<List<AnswerAllListDto>> GetAllAnswers()
        {
            var answers = _mapper.Map<List<AnswerAllListDto>>(await _answerRepository.GetAllAnswers());
            return answers.ToList();

            //return answers;
            //return await _answerRepository.GetAllAnswers();
        }

        public async Task<Answer> GetAnswerById(int id)
        {
            return await _answerRepository.GetAnswerById(id);
        }

        public async Task UpdateAnswer(UpdateAnswerDto updateAnswerDto)
        {
            Answer answer = _mapper.Map<Answer>(updateAnswerDto);
            await _answerRepository.UpdateAnswer(answer);
        }


    }
}
