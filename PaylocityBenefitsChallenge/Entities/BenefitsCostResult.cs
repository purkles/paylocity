using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaylocityBenefitsChallenge.Entities
{
    public class BenefitsCostResult
    {
        public decimal BenefitsCostPerYear;
        public decimal TotalEmployeeCostPerPayPeriod;
        public decimal TotalEmployeeCostPerYear;

        public string ErrorDetails;
    }
}
