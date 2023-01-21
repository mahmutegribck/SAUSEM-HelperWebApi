using Helper.Business.Answers.Dtos;
using Helper.Entites.Entites;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Helper.Business.Answers
{
    public interface IAnswerService
    {
        Task<List<GetAnswerDto>> GetAllUserAnswers(string id);

        Task<List<GetAnswerDto>> GetAllAnswers();

        Task CreateAnswer(string IdentityUserId, CreateAnswerDto createAnswerDto);

        Task DeleteAnswer(string IdentityUserId, int answerId);

        Task UpdateAnswer(string IdentityUserId, UpdateAnswerDto updateAnswerDto);

        Task<GetAnswerDto> GetAnswerById(int id);
      
    }
}
