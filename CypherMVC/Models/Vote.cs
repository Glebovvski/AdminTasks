using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace CypherMVC.Models
{
    public class Vote
    {
        public int Id { get; set; }
        public int AdminId { get; set; }

        //Navigation Property
        public Admin Admin { get; set; }
    }
}