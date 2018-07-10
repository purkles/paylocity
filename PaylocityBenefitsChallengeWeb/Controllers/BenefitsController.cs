using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PaylocityBenefitsChallenge;
using PaylocityBenefitsChallenge.Entities;
using PaylocityBenefitsChallengeWeb.Models;

namespace PaylocityBenefitsChallengeWeb.Controllers
{
    public class BenefitsController : Controller
    {
        public Lazy<IBenefitsManager> benefitsMgr = new Lazy<IBenefitsManager>(() => new BenefitsManager());
       

        public ActionResult Calculate()
        {
           var employee = new BenefitsEmployeeModel();           
           return View(employee);
        }

        [HttpPost]
        public ActionResult Calculate(BenefitsEmployeeModel model)
        {
            if (!ModelState.IsValid)
            {
                return View("Calculate", model);
            }

            var benefitsEmployee = new BenefitEmployee(model.Employee.FirstName, model.Employee.LastName);

            if (model.Dependents != null && model.Dependents.Count > 0)
            {
                var dependents = new List<PaylocityBenefitsChallenge.Entities.Person>();
                foreach (var dependent in model.Dependents)
                {
                    var employeeDependent = new Person(dependent.FirstName, dependent.LastName);
                    dependents.Add(employeeDependent);
                }

                benefitsEmployee.Dependents = dependents;
            }

            var response = benefitsMgr.Value.GetEmployeeCost(benefitsEmployee);

            EmployeeCostModel responseModel = new EmployeeCostModel();
            responseModel.TotalBenefitCost = response.BenefitsCostPerYear;
            responseModel.EmployeeCostPerPayPeriod = response.TotalEmployeeCostPerPayPeriod;
            responseModel.EmployeeCostPerYear = response.TotalEmployeeCostPerYear;

            return View("ViewEmployeeCost", responseModel);
        }

        public ActionResult AddNewDependent()
        {
            var dependent = new PersonModel();
            return PartialView("_Dependent", dependent);
        }
    }
}