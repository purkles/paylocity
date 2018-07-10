using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using PaylocityBenefitsChallenge.Entities;

namespace PaylocityBenefitsChallenge
{
    public interface IBenefitsManager
    {
        BenefitsCostResult GetEmployeeCost(BenefitEmployee employee);
    }
}
