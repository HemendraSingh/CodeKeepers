using CodeKeeperUI.Helpers;
using CodeKeeperUI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;

namespace CodeKeeperUI.Controllers
{
    public class QuizController : Controller
    {
        // GET: Quiz
        public ActionResult Index(string userId, int quizId)
        {

            ViewBag.UserId = userId;
            ViewBag.QuizId = quizId;
            return View();
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public JsonResult SubmitAnswer(UserAnswer userAnswer)
        {
            JavaScriptSerializer js = new JavaScriptSerializer();
            string jsonData = js.Serialize(userAnswer);
            ServiceBusHelper.MainAsync(jsonData);
            return new JsonResult()
            {
                Data = true
            };
        }
    }

    public class UserAnswer
    {
        public int UserQuizId { get; set; }

        public int QuestionId { get; set; }

        public string Answer { get; set; }
    }
}