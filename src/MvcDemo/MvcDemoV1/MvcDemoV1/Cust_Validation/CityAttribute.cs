using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using MvcDemoV1.Models;

namespace MvcDemoV1.Cust_Validation
{
    public class CityAttribute:ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, 
                         ValidationContext validationContext)
        {
            var ud = (UserDetails)validationContext.ObjectInstance;
            if(ud.City==null)
            {
                return new ValidationResult("City cannot be null");
            }
            if(ud.City.ToLower().Equals("Noida")||ud.City.ToLower().Equals("Bangalore"))
            {
                return ValidationResult.Success;
            }

            return new ValidationResult("City can only be either Noida or Bangalore");
          //  return base.IsValid(value);
        }
    }
}
