using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LocalizeCulture.Models
{
    public class WebinarInvites
    {
        [Required(ErrorMessage ="Please enter your name")]
        [Display(Name ="Name")]
        public string Name { get; set; }

        [Required(ErrorMessage ="Please enter your email address")]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Display(Name = "Phone")]
        [Required(ErrorMessage ="Please enter your Phone number")]
        public string Phone { get; set; }

        [Display(Name = "Will Join")]
        [Required(ErrorMessage ="Please specify whether you'll join")]
        public bool? WillJoin { get; set; }
    }
}
