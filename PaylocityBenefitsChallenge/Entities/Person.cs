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
        public decimal BenefitCostPerYear { get; internal set; }
        public bool IsEligibleForDiscount { get; protected set; }
        public bool IsEmployee { get; private set; }


        public Person(string firstName, string lastName, bool? isEmployee = false)
        {
            FirstName = firstName;
            LastName = lastName;
            IsEmployee = isEmployee ?? false;
            IsEligibleForDiscount = CheckIsEligibleForDiscount();
        }

        private bool CheckIsEligibleForDiscount()
        {
            return FirstName.ToLower().StartsWith("a") || 
                    LastName.ToLower().StartsWith("a") ? true : false;
        }
    }
}
