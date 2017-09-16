using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CypherMVC.Helpers
{
    public class DueDate : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            try
            {
                return ((DateTime)value).Date > DateTime.Now.Date;
            }
            catch
            {
                return false;
            }
        }
    }
}