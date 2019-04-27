using MultiPlayerQuiz.Models;
using MultiPlayerQuiz.Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace MultiPlayerQuiz.Api.Controllers
{
   // [Authorize]
   [RoutePrefix("api/Questions")]
    public class QuestionsController : ApiController
    {
        private readonly IQuestionService _questionService;

        //public QuestionsController()
        //{

        //}

        public QuestionsController(IQuestionService questionService)
        {
            _questionService = questionService;
        }

        [Route("get")]
        [HttpGet]
        public async Task<HttpResponseMessage> GetAll()
        {
            try
            {
                var questions = await _questionService.GetAllAsync();
                return Request.CreateResponse<List<QuestionModel>>(HttpStatusCode.OK, questions);
            }
            catch (Exception ex)
            {
                return new HttpResponseMessage(HttpStatusCode.InternalServerError);
            }
        }

        [Route("get/{id}")]
        [HttpGet]
        public async Task<HttpResponseMessage> GetQuestion(int id)
        {
            try
            {
                if (id == 0)
                {
                    return new HttpResponseMessage(HttpStatusCode.BadRequest);
                }

                var question = await _questionService.GetByIdAsync(id);

                if (question == null)
                {
                    return new HttpResponseMessage(HttpStatusCode.NotFound);
                }

                return Request.CreateResponse(HttpStatusCode.OK, question);
            }
            catch (Exception ex)
            {
                return new HttpResponseMessage(HttpStatusCode.InternalServerError);
            }
        }

        [Route("add")]
        [HttpPost]
        public async Task<HttpResponseMessage> Addquestion([FromBody] QuestionModel question)
        {
            try
            {
                var questionResult = await _questionService.AddAsync(question);
                return Request.CreateResponse(HttpStatusCode.OK, questionResult);
            }
            catch (Exception ex)
            {
                return new HttpResponseMessage(HttpStatusCode.InternalServerError);
            }
        }

        [Route("update")]
        [HttpPut]
        public async Task<HttpResponseMessage> Updatequestion([FromBody] QuestionModel question)
        {
            try
            {
                if (question.Id == 0)
                {
                    return new HttpResponseMessage(HttpStatusCode.BadRequest);
                }

                var questionResult = await _questionService.UpdateAsync(question);

                if (questionResult == null)
                {
                    return new HttpResponseMessage(HttpStatusCode.NotFound);
                }

                return Request.CreateResponse(HttpStatusCode.OK, questionResult);
            }
            catch (Exception ex)
            {
                return new HttpResponseMessage(HttpStatusCode.InternalServerError);
            }
        }
       
        [Route("delete")]
        [HttpDelete]
        public async Task<HttpResponseMessage> Deletequestion(int id)
        {
            try
            {
                if (id == 0)
                {
                    return new HttpResponseMessage(HttpStatusCode.BadRequest);
                }

                var result = await _questionService.DeleteAsync(id);

                if (!result)
                {
                    return new HttpResponseMessage(HttpStatusCode.BadRequest);
                }

                return new HttpResponseMessage(HttpStatusCode.OK);
            }
            catch (Exception ex)
            {
                return new HttpResponseMessage(HttpStatusCode.InternalServerError);
            }
        }
    }
}
