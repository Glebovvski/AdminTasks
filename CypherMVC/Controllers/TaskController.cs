using AutoMapper;
using CypherMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace CypherMVC.Controllers
{
    public class TaskController : Controller
    {
        public ActionResult ViewAll()
        {
            var context = new FeedbackContext();
            var tasks = context.Tasks.OrderByDescending(x => x.Created).ToList();
            return View(tasks);
        }

        public ActionResult CreateEdit(int Id = 0)
        {
            var context = new FeedbackContext();
            ViewBag.Categories = context.Categories.Select(
                    x => new SelectListItem() { Text = x.Name, Value = x.Id.ToString() }).ToList();

            if (Id != 0)
            {
                var task = context.Tasks.FirstOrDefault(x => x.Id == Id);
                var mapperTask = Mapper.Map<TaskVM>(task);
                mapperTask.AssociatedMessageDisplay = task.AssociatedMessage.Subject;
                return View(mapperTask);
            }

            return View();
        }

        [HttpPost]
        public ActionResult CreateEdit(TaskVM task)
        {
            var context = new FeedbackContext();
            if (ModelState.IsValid)
            {
                var editTask = context.Tasks.FirstOrDefault(x => x.Id == task.Id);
                if (editTask != null)
                {
                    //Updating Task
                    editTask.Title = task.Title;
                    editTask.Description = task.Description;
                    editTask.CategoryId = task.CategoryId;
                    editTask.AssignedToId = task.AssignedToId;
                    editTask.DueDate = task.DueDate;
                    editTask.AssociatedMessageId = task.AssociatedMessageId;
                    editTask.Completed = task.Completed;
                    editTask.Notes = task.Notes;
                    context.Entry(editTask).State = System.Data.Entity.EntityState.Modified;
                }
                else
                {
                    //New Task
                    var newTask = Mapper.Map<Models.Task>(task);
                    newTask.Created = DateTime.Now;
                    context.Tasks.Add(newTask);
                }
                context.SaveChanges();
                return RedirectToAction("ViewAll");
            }

            ViewBag.Categories = context.Categories.Select(
                    x => new SelectListItem() { Text = x.Name, Value = x.Id.ToString() }).ToList();
            return View(task);
        }

        public ActionResult MessageSuggestions(string term)
        {
            var context = new FeedbackContext();
            var messages = context.Messages
                                  .Where(x => x.Subject.Contains(term))
                                  .Select(x => new { Label = x.Subject, Id = x.Id }).ToList();
            return Json(messages, JsonRequestBehavior.AllowGet);
        }
    }
}