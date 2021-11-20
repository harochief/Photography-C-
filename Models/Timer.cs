using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Identity4Example.Models
{
    public class Timer
    {

        public int ID { get; set; }


        public DateTime GetDate { get; set; }

        public int Days { get; set; }
    }
}