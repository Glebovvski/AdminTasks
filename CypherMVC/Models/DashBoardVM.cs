using CypherMVC.Models;
using System.Collections.Generic;

namespace CypherMVC.Models
{
    public class DashBoardVM
    {
        public IEnumerable<Message> Messages { get; set; }
        public IEnumerable<Task> Tasks { get; set; }
    }
}