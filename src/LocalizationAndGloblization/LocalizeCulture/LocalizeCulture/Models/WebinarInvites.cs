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
        public string Name { get; set; }

        [Required(ErrorMessage ="Please enter your email address")]
        [EmailAddress]
        public string Email { get; set; }

        [Required(ErrorMessage ="Please enter your Phone number")]
        public string Phone { get; set; }

        [Required(ErrorMessage ="Please specify whether you'll join")]
        public bool? WillJoin { get; set; }
    }
}
