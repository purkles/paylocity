using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace PaylocityBenefitsChallenge.Entities
{
    public class Person
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public bool IsEligibleForDiscount { get; private set; }
        public bool IsEmployee { get; private set; }


        public Person(string firstName, string lastName, bool? isEmployee = false)
        {
            FirstName = firstName;
            LastName = lastName;
            IsEmployee = isEmployee ?? false;

            // employees and dependents whose first or last name starts with the character A are eligible
            IsEligibleForDiscount = FirstName.ToLower().StartsWith("a") ||
                                    LastName.ToLower().StartsWith("a"); ;
        }
    }
}
