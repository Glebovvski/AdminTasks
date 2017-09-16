using CypherMVC.Helpers;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CypherMVC.Models
{
    [Bind(Exclude = "AssignedTo, AssociatedMessage, Category")]
    public class Task
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime? DueDate { get; set; }
        public int AssignedToId { get; set; }
        public int CategoryId { get; set; }
        public int AssociatedMessageId { get; set; }
        public DateTime? Created { get; set; }
        public string Notes { get; set; }
        public bool Completed { get; set; }

        //Navigation Properties
        public virtual Admin AssignedTo { get; set; }
        public virtual Message AssociatedMessage { get; set; }
        public virtual Category Category { get; set; }

    }
}