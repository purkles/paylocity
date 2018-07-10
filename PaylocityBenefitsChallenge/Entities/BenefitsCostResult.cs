using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PaylocityBenefitsChallenge.Entities
{
    public class BenefitsCostResult
    {
        public BenefitEmployee EmployeeData { get; set; }
        public decimal BenefitCostForEmployeeOnly { get; internal set; }
        public decimal BenefitCostForDependentsOnly;

        public decimal TotalBenefitsCostPerYear { get; internal set; }
        public decimal TotalEmployeeCostPerPayPeriod { get; internal set; }
        public decimal TotalEmployeeCostPerYear { get; internal set; }

        public string ErrorDetails;
    }
}
