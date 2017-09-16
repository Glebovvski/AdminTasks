using CypherMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CypherMVC.Controllers
{
    public class MessagesController : Controller
    {
        private FeedbackContext context;

        public MessagesController(FeedbackContext _context)
        {
            context = _context;
        }

        public ActionResult ViewAll()
        {
            var messages = context.Threads
                                  .SelectMany(x => x.Messages)
                                  .OrderByDescending(x => x.Created)
                                  .ToList()
                                  .GroupBy(g => g.MessageThreadId)
                                  .Select(g => g.FirstOrDefault()).ToList();
            return View(messages);
        }

        public ActionResult Reply(int id)
        {
            var threads = context.Threads.First(x => x.MessageThreadId == id)
                                         .Messages.OrderBy(x => x.Created)
                                         .ToList();
            if (threads != null)
            {
                ReplyVM vm = new ReplyVM()
                {
                    Messages = threads,
                    Subject = threads.FirstOrDefault().Subject,
                    MessageThreadId = id
                };
                return View(vm);
            }
            return RedirectToAction("Index", "Home");
        }

        [HttpPost]
        public ActionResult Reply(int id, string content)
        {
            var threads = context.Threads.FirstOrDefault(x => x.MessageThreadId == id);

            if (threads != null)
            {
                var msg = new Message();
                
                    msg.Subject = threads.Messages.First().Subject;
                    msg.Created = DateTime.Now;
                    msg.Content = content;
                    msg.MessageThreadId = id;
                    var index = HttpContext.User.Identity.Name.IndexOf("\\") + 1;
                    msg.Author = HttpContext.User.Identity.Name.Substring(index);

                context.Messages.Add(msg);
                context.SaveChanges();
            }

            return RedirectToAction("ViewAll"); 
        }
    }
}