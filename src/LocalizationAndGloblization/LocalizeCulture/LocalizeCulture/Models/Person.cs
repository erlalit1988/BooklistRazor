using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LocalizeCulture.Models
{
    public class Person
    {
        [Required(ErrorMessage ="Name is Requried")]
        [Display(Name ="First Name")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Last Name is Requried")]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Date of birth is Requried")]
        [Display(Name = "Date of Birth")]
        [DisplayFormat(ApplyFormatInEditMode =true, DataFormatString ="{0:dd/MM/yyyy}")]
        public string DateOfBirth { get; set; }
       
    }
}
