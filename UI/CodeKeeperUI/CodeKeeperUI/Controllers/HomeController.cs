﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CodeKeeperUI.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult Administrator()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult AddQuiz()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult UserDashboard()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult QuizView()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult AdminLanding()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}