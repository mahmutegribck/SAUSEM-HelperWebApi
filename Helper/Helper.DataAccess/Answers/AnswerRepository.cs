using Helper.Entites.Entites;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Helper.DataAccess.Answers
{
    public class AnswerRepository : IAnswerRepository
    {
        HelperDbContext _helperDbContext = new HelperDbContext();

        //public AnswerRepository(HelperDbContext helperDbContext)
        //{
        //    _helperDbContext = helperDbContext;
        //}

        public async Task CreateAnswer(int helpId, Answer answer)
        {
            var help = await _helperDbContext.Helps.Where(h => h.HelpId == helpId).FirstOrDefaultAsync();
            // await helperDbContext.Categories.Where(c => c.CategoryId == categoryId).FirstOrDefaultAsync();

            if (help != null)
            {

                answer.HelpId = helpId;
                await _helperDbContext.Answers.AddAsync(answer);
                await _helperDbContext.SaveChangesAsync();

            }
            else
            {
                throw new Exception("Not Found Help");
            }

        }

        public async Task DeleteAnswer(int id)
        {
            var deleteAnswer = await GetAnswerById(id);
            if (deleteAnswer != null)
            {
                _helperDbContext.Answers.Remove(deleteAnswer);
                await _helperDbContext.SaveChangesAsync();
            }
            else
            {
                throw new Exception("Not Found Answer");
            }
        }

        public async Task<List<Answer>> GetAllAnswers()
        {
            return await _helperDbContext.Answers.ToListAsync();
        }

        public async Task<Answer> GetAnswerById(int id)
        {
            var answer = await _helperDbContext.Answers.FindAsync(id);
            if (answer != null)
            {
                return answer;
            }
            else
            {
                throw new Exception("Not Found Answer");
            }
        }

        public async Task UpdateAnswer(Answer answer)
        {
            var answerUpdate = await _helperDbContext.Answers.FindAsync(answer.AnswerId);
            var answerUpdateHelp = await _helperDbContext.Helps.FindAsync(answer.HelpId);
            if (answerUpdateHelp != null && answerUpdate != null && answerUpdate.HelpId == answerUpdateHelp.HelpId)
            {
                _helperDbContext.Answers.Update(answerUpdate);
                await _helperDbContext.SaveChangesAsync();
            }
            else
            {
                throw new Exception("Not Found");
            }

        }
    }
}
