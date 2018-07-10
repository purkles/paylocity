using System;
using PaylocityBenefitsChallenge.Entities;

namespace PaylocityBenefitsChallenge
{
    public class BenefitsManager : IBenefitsManager
    {
        public const decimal PayAmount = 2000.00m;
        public const int PayPeriods = 26;
        public const decimal EmployeeBenefitsCostPerYear = 1000.00m;
        public const decimal DependentBenefitsCostPerYear = 500.00m;

        public BenefitsCostResult costResult = new BenefitsCostResult();


        public BenefitsCostResult GetEmployeeCost(BenefitEmployee employeeData)
        {    
            try
            {
                costResult.TotalBenefitsCostPerYear = GetTotalBenefitsCostsForEmployee(employeeData);

                costResult.TotalEmployeeCostPerPayPeriod =
                    GetEmployeeCostPerPayPeriod(costResult.TotalBenefitsCostPerYear);
                costResult.TotalEmployeeCostPerYear =
                    GetEmployeeCostPerYear(costResult.TotalBenefitsCostPerYear);
            }
            catch (Exception ex)
            {
                costResult.ErrorDetails = ex.Message;
            }

            return costResult;
        }


        public decimal GetTotalBenefitsCostsForEmployee(BenefitEmployee employeeData)
        {
            decimal cost = 0.0m;

            try
            {              
                cost = GetBenefitsCost(employeeData.Employee);

                costResult.BenefitCostForEmployeeOnly = cost;

                if (employeeData.Dependents != null && employeeData.Dependents.Count > 0)
                {
                    foreach (var dependent in employeeData.Dependents)
                    {
                        costResult.BenefitCostForDependentsOnly += GetBenefitsCost(dependent);
                    }
                }

                cost += costResult.BenefitCostForDependentsOnly;
            }
            catch (Exception ex)
            {
                cost = -1.0m;
                throw;
            }

            return cost;
        }

        private decimal ApplyDiscount(decimal cost)
        {

           return cost * .9m;

        }

        private decimal GetBenefitsCost(Person person)
        {
            decimal result = 0.0m;

            try
            {
                result = person.IsEmployee ? EmployeeBenefitsCostPerYear : DependentBenefitsCostPerYear;
                
                if (person.IsEligibleForDiscount)
                {
                    result = ApplyDiscount(result);
                }
            }
            catch (Exception ex)
            {
                result = -1.0m;
                throw;
            }

            return result;

        }

        public decimal GetEmployeeCostPerPayPeriod(decimal benefitsCost)
        {
            decimal totalCostPerPayPeriod = 0.0m;

            try
            {
                decimal benefitsCostPerPayPeriod = Math.Round(benefitsCost / PayPeriods, 2);

                totalCostPerPayPeriod = PayAmount + benefitsCostPerPayPeriod;
            }
            catch (Exception ex)
            {
                totalCostPerPayPeriod = -1.0m;
                throw;
            }

            return totalCostPerPayPeriod;
        }

        public decimal GetEmployeeCostPerYear(decimal benefitsCostPerYear)
        {
            decimal totalCostPerYear = 0.0m;

            try
            {
                decimal totalPay = Math.Round(PayAmount * PayPeriods, 2);

                totalCostPerYear = totalPay + benefitsCostPerYear;
            }
            catch (Exception ex)
            {
                throw;
            }

            return totalCostPerYear;
        }
    }
}
