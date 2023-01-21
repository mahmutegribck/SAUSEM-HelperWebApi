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

        Task<List<Answer>> GetAllUserAnswers(string id);


        Task<Answer> GetAnswerById(int id);

        Task CreateAnswer(Answer answer);
        Task UpdateAnswer(string IdentityUserId, Answer answer);
        Task DeleteAnswer(string IdentityUserId, int id);
    }
}
