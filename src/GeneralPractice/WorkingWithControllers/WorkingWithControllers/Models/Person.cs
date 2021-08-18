using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WorkingWithControllers.Models
{
    public class Person
    {

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime? DateOfBirth { get; set; } //nullable because it may not have been set

        // Returns a string that contains all property values of the class object
        //Not mandatory but prepared to display model data easily
        public override string ToString()
        {
            string dateOfBirthAsString = "Unknown!";
            if (DateOfBirth != null)
            {
                dateOfBirthAsString = DateOfBirth?.Date.ToShortTimeString();
            }
            return String.Format($"FirstName: {FirstName} LastName: {LastName} DateOfBirth: {dateOfBirthAsString}");
        }
    }
}
