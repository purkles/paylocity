using System;
using System.Collections.Generic;
using System.Text;
using PaylocityBenefitsChallenge.Entities;

namespace PaylocityBenefitsChallenge
{
    public class BenefitsManager
    {
        public const decimal PayAmount = 2000.00m;
        public const int PayPeriods = 26;


        public BenefitsCostResult GetEmployeeCost(BenefitEmployee employee)
        {
            BenefitsCostResult benefitsCostResult = new BenefitsCostResult();

            try
            {
                benefitsCostResult.BenefitsCostPerYear = GetBenefitsCostForEmployee(employee);
                benefitsCostResult.TotalEmployeeCostPerPayPeriod =
                    GetEmployeeCostPerPayPeriod(benefitsCostResult.BenefitsCostPerYear);
                benefitsCostResult.TotalEmployeeCostPerYear =
                    GetEmployeeCostPerPayYear(benefitsCostResult.BenefitsCostPerYear);
            }
            catch (Exception ex)
            {
                benefitsCostResult.ErrorDetails = ex.Message;
            }

            return benefitsCostResult;
        }


        public decimal GetBenefitsCostForEmployee(BenefitEmployee employee)
        {
            decimal cost = 0.0m;

            try
            {

                cost = GetBenefitsCost(employee.Employee);

                if (employee.Dependents != null && employee.Dependents.Count > 0)
                {
                    foreach (var dependent in employee.Dependents)
                    {
                        // set isDependent = true
                        cost += GetBenefitsCost(dependent, true);
                    }
                }
            }
            catch (Exception ex)
            {
                cost = -1.0m;
                throw;
            }

            return cost;
        }

        public decimal CalculateDiscount(decimal cost)
        {

           return cost * .9m;

        }

        private decimal GetBenefitsCost(Person person, bool isDependent = false)
        {
            decimal result = 0.0m;

            try
            {
                if (isDependent)
                {
                    result = 500.00m;

                }
                else
                {
                    result = 1000.00m;
                }

                if (person.FirstName.ToLower().StartsWith("a"))
                {
                    result = CalculateDiscount(result);
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

        public decimal GetEmployeeCostPerPayYear(decimal benefitsCostPerYear)
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
