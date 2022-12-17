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
        Task<List<AnswerAllListDto>> GetAllAnswers();
        Task<Answer> GetAnswerById(int id);

        Task CreateAnswer(int helpId, CreateAnswerDto createAnswerDto);
        Task UpdateAnswer(UpdateAnswerDto updateAnswerDto);
        Task DeleteAnswer(int id);
    }
}
