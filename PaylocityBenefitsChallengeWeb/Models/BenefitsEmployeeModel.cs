using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PaylocityBenefitsChallengeWeb.Models
{
    public class BenefitsEmployeeModel
    {
        public BenefitsEmployeeModel(string firstName, string lastName)
        {
            Employee = new PersonModel(){FirstName = firstName, LastName = lastName};
            Dependents = new List<PersonModel>();
        }

        public BenefitsEmployeeModel()
        {
            Employee = new PersonModel();
            Dependents = new List<PersonModel>();
        }


        [Required]
        public PersonModel Employee { get; set; }
      
        public List<PersonModel> Dependents { get; set; }
    }

   
    public class PersonModel
    {
        [Display(Name = "First Name")]
        [Required]
        public string FirstName { get; set; }
        [Display(Name = "Last Name")]
        [Required]
        public string LastName { get; set; }
    }
}