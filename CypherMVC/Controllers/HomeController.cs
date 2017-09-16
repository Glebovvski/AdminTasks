using CypherMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CypherMVC.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            var context = new FeedbackContext();

            var dash = new DashBoardVM()
            {
                Messages = context.Threads
                                  .SelectMany(x => x.Messages)
                                  .OrderByDescending(c => c.Created)
                                  .ToList()
                                  .GroupBy(y => y.MessageThreadId)
                                  .Select(g => g.FirstOrDefault())
                                  .ToList()
                                  .Take(5),
                Tasks = context.Tasks.OrderByDescending(c => c.Created).Take(5)
            };
            return View(dash);

        }

        public ActionResult Survey()
        {
            var context = new FeedbackContext();
            var admins = context.Admins.OrderByDescending(a => a.Votes.Count).ToList();
            if (Session["HasVoted"] != null)
            {
                return PartialView("SurveyResults", admins);
            }
            return PartialView(admins);
        }

        [HttpPost]
        public ActionResult Survey(int adminId)
        {
            var context = new FeedbackContext();
            
            context.Votes.Add(new Vote { AdminId = adminId });
            context.SaveChanges();
            var admins = context.Admins.OrderByDescending(a => a.Votes.Count).ToList();
            Session["HasVoted"] = true;
            return PartialView("SurveyResults",admins);
        }

        public ActionResult Suggestion()
        {
            return PartialView();
        }

        [HttpPost]
        public ActionResult Suggestion(string suggestion)
        {
            var emailSent = true;
            return PartialView("SuggestionResult", emailSent);
        }
    }
}