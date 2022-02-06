using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace htmlHelpers.Models
{
    public class student
    {

        [Key]
        [Display(Name = "student Id")]
        public int stud_id { get; set; }

        [Display(Name = "student name")]
        [Required]

        public string sname { get; set; }

        [Display(Name = "student Phone Number")]
        [Required]
        public Nullable<long> phone { get; set; }
        [Display(Name = "student address")]
        [Required]
        public string address { get; set; }
        [Display(Name = "student gender")]
        [Required]
        public string gender { get; set; }
    }
}