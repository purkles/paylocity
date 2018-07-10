using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PaylocityBenefitsChallenge.Entities
{
    public class BenefitsCostResult
    {
        public decimal BenefitCostForEmployeeOnly;
        public decimal BenefitCostForDependentsOnly;

        public decimal BenefitsCostPerYear;
        public decimal TotalEmployeeCostPerPayPeriod;
        public decimal TotalEmployeeCostPerYear;

        public string ErrorDetails;
    }
}
