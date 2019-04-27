using AutoMapper;
using MultiPlayerQuiz.Models;
using MultiPlayerQuiz.Repository.Contracts;
using MultiPlayerQuiz.Repository.Models;
using MultiPlayerQuiz.Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiPlayerQuiz.Services.Implementations
{
    public class QuestionService : IQuestionService
    {
        private readonly IGenericRepository<Question> _questionsRepository;

        public QuestionService(IGenericRepository<Question> questionsRepository)
        {
            _questionsRepository = questionsRepository;
        }

        public async Task<QuestionModel> AddAsync(QuestionModel question)
        {
            Question questionData = Mapper.Map<Question>(question);
            var questionResult = await _questionsRepository.Insert(questionData);
            return Mapper.Map<QuestionModel>(questionResult);
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var result = await _questionsRepository.Delete(id);
            return result;
        }

        public async Task<List<QuestionModel>> GetAllAsync()
        {
            var questionResult = await _questionsRepository.AllInclude(q => q.QuestionOptions);
            return Mapper.Map<List<QuestionModel>>(questionResult);
        }

        public async Task<QuestionModel> GetByIdAsync(int id)
        {
            var questionResult = await _questionsRepository.FindByInclude(q => q.Id == id, q => q.QuestionOptions);
            return Mapper.Map<QuestionModel>(questionResult);
        }

        public async Task<QuestionModel> UpdateAsync(QuestionModel question)
        {
            Question questionData = Mapper.Map<Question>(question);
            var questionResult = await _questionsRepository.Update(questionData);
            return Mapper.Map<QuestionModel>(questionResult);
        }
    }
}
