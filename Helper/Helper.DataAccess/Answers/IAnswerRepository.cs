using Helper.Entites.Entites;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Helper.DataAccess.Answers
{
    public interface IAnswerRepository
    {
        Task<List<Answer>> GetAllAnswers();
        Task<Answer> GetAnswerById(int id);

        Task CreateAnswer(int helpId, Answer answer);
        Task UpdateAnswer(Answer answer);
        Task DeleteAnswer(int id);
    }
}
