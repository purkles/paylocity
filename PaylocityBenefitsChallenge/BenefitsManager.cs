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


        public BenefitsCostResult GetEmployeeCost(BenefitEmployee employeeData)
        {
            BenefitsCostResult benefitsCostResult = new BenefitsCostResult();

            try
            {
                GetTotalBenefitsCostsForEmployee(employeeData);

                benefitsCostResult.BenefitCostForEmployeeOnly = employeeData.Employee.BenefitCostPerYear;

                if (employeeData.Dependents != null && employeeData.Dependents.Count > 0)
                {
                    foreach (var dependent in employeeData.Dependents)
                    {
                        benefitsCostResult.BenefitCostForDependentsOnly += dependent.BenefitCostPerYear;
                    }
                }

                benefitsCostResult.BenefitsCostPerYear = benefitsCostResult.BenefitCostForEmployeeOnly +
                                                         benefitsCostResult.BenefitCostForDependentsOnly;

                benefitsCostResult.TotalEmployeeCostPerPayPeriod =
                    GetEmployeeCostPerPayPeriod(benefitsCostResult.BenefitsCostPerYear);
                benefitsCostResult.TotalEmployeeCostPerYear =
                    GetEmployeeCostPerYear(benefitsCostResult.BenefitsCostPerYear);
            }
            catch (Exception ex)
            {
                benefitsCostResult.ErrorDetails = ex.Message;
            }

            return benefitsCostResult;
        }


        public decimal GetTotalBenefitsCostsForEmployee(BenefitEmployee employeeData)
        {
            decimal cost = 0.0m;

            try
            {              
                cost = GetBenefitsCost(employeeData.Employee);

                employeeData.Employee.BenefitCostPerYear = cost;

                if (employeeData.Dependents != null && employeeData.Dependents.Count > 0)
                {
                    foreach (var dependent in employeeData.Dependents)
                    {
                        dependent.BenefitCostPerYear = GetBenefitsCost(dependent);
                        cost += dependent.BenefitCostPerYear;
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
