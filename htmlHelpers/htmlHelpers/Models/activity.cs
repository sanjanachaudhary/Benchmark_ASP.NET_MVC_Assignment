using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace htmlHelpers.Models
{
    public class activity
    {
        [Key]
        public int aid { get; set; }
        public string activity1 { get; set; }
        public Nullable<int> cost { get; set; }
        public Nullable<int> stud_id { get; set; }
        public string photo { get; set; }

        public virtual student student { get; set; }
    }
}