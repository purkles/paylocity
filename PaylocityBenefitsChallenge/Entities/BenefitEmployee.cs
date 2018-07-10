using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PaylocityBenefitsChallenge.Entities
{
    public class BenefitEmployee
    {
        public BenefitEmployee(string firstName, string lastName)
        {
            Employee = new Person(firstName, lastName, true); 
        }

        public Person Employee { get; set; }

        public List<Person> Dependents { get; set; }
    }
}
