using Helper.Entites.Entites;
using Microsoft.AspNetCore.Identity;
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
        private readonly HelperDbContext _helperDbContext;

        public AnswerRepository(HelperDbContext helperDbContext)
        {
            _helperDbContext = helperDbContext;
        }


        public async Task<List<Answer>> GetAllAnswers()
        {
            var answers=  await _helperDbContext.Answers.OrderByDescending(a => a.AnswerDate).ToListAsync();

            if(answers.Count > 0 ) 
            {
                return answers; 
            }
            else
            {
                throw new Exception("Not Found Answer");
            }
                

        }


        public async Task<List<Answer>> GetAllUserAnswers(string id)
        {
            var userAnswers =  await _helperDbContext.Answers.Where(a => a.ApplicationUser.Id == id).OrderByDescending(a => a.AnswerDate).ToListAsync();

            if(userAnswers.Count > 0 ) 
            {
                return userAnswers;
            }
            else
            {
                throw new Exception("Not Found Answer");
            }

        }

        public async Task CreateAnswer(Answer answer)
        {
            //var help = await _helperDbContext.Helps.Where(h => h.HelpId == helpId).FirstOrDefaultAsync();
            // await helperDbContext.Categories.Where(c => c.CategoryId == categoryId).FirstOrDefaultAsync();

            //if (help != null)
            //{

                //answer.HelpId = helpId;
                answer.AnswerDate = DateTime.Now;   
                await _helperDbContext.Answers.AddAsync(answer);
                await _helperDbContext.SaveChangesAsync();

          //  }
           // else
           // {
           //     throw new Exception("Not Found Help");
           // }
        //
        }

        public async Task DeleteAnswer(string IdentityUserId, int id)
        {
            var deleteAnswer = await GetAnswerById(id);
            

            if (deleteAnswer != null)
            {
                if (deleteAnswer.ApplicationUserId == IdentityUserId)
                {
                    _helperDbContext.Answers.Remove(deleteAnswer);
                    await _helperDbContext.SaveChangesAsync();
                }
                else
                {
                    throw new Exception("User can not delete this answer");
                }
                
            }
            else
            {
                throw new Exception("Not Found Answer");
            }
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

        public async Task UpdateAnswer(string IdentityUserId, Answer answer)
        {
            var answerUpdate = await _helperDbContext.Answers.FindAsync(answer.AnswerId);
            //var answerUpdateHelp = await _helperDbContext.Helps.FindAsync(answer.HelpId);
            //if (answerUpdateHelp != null && answerUpdate != null && answerUpdate.HelpId == answerUpdateHelp.HelpId)
            //{


            if (answerUpdate != null)
            {
                if (answerUpdate.ApplicationUserId == IdentityUserId)
                {
                    _helperDbContext.Answers.Update(answerUpdate);
                    await _helperDbContext.SaveChangesAsync();
                }
                else
                {
                    throw new Exception("User can not update this answer");
                }

            }
            else
            {
                throw new Exception("Not Found Answer");
            }
        }
    }
}
