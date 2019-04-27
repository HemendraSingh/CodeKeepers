using MultiPlayerQuiz.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiPlayerQuiz.Services.Contracts
{
    public interface IQuestionService
    {
        Task<QuestionModel> AddAsync(QuestionModel question);

        Task<bool> DeleteAsync(int id);

        Task<List<QuestionModel>> GetAllAsync();

        Task<QuestionModel> GetByIdAsync(int id);

        Task<QuestionModel> UpdateAsync(QuestionModel question);
    }
}
