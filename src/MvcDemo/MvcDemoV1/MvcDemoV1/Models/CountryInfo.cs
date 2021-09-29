using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;

namespace MvcDemoV1.Models
{
    public class CountryInfo
    {

        public int CountryID { get; set; }

        public IList<SelectListItem> Countries { get; set; } = new List<SelectListItem>();

       
    }

   
}
