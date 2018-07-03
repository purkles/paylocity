using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit;
using NUnit.Framework;
using PaylocityBenefitsChallenge.Entities;

namespace PaylocityBenefitsChallenge
{
    [TestFixture]
     public class BenefitsManagerTests
    {

        [Test, Explicit]
        public void Test_GetBenefitsCostForEmployeeOnly()
        {
            BenefitEmployee employee = new BenefitEmployee();
            
            employee.Employee = new Person("John", "Doe");

            BenefitsManager benefitsManager = new BenefitsManager();
            var result = benefitsManager.GetBenefitsCostForEmployee(employee);

            Assert.AreEqual(1000.00m, result);

            return;
        }

        [Test, Explicit]
        public void Test_GetBenefitsCostForEmployeeOnlyWithDiscount()
        {
            BenefitEmployee employee = new BenefitEmployee();

            employee.Employee = new Person("Aaron", "Smith");

            BenefitsManager benefitsManager = new BenefitsManager();
            var result = benefitsManager.GetBenefitsCostForEmployee(employee);

            Assert.AreEqual(900.00m, result);

            return;
        }

        [Test, Explicit]
        public void Test_GetBenefitsCostForEmployeeWithOneDependentNoDiscount()
        {
            BenefitEmployee employee = new BenefitEmployee();

            employee.Employee = new Person("Sarah", "Lee");

            employee.Dependents = new List<Person>();
            employee.Dependents.Add(new Person("Bill", "Jones"));

            BenefitsManager benefitsManager = new BenefitsManager();
            var result = benefitsManager.GetBenefitsCostForEmployee(employee);

            Assert.AreEqual(1500.00m, result);

            return;
        }

        [Test, Explicit]
        public void Test_GetBenefitsCostForEmployeeWithOneDependentBothDiscounts()
        {
            BenefitEmployee employee = new BenefitEmployee();

            employee.Employee = new Person("Anna", "Waters");

            employee.Dependents = new List<Person>();
            employee.Dependents.Add(new Person("Andy", "Kirk"));

            BenefitsManager benefitsManager = new BenefitsManager();
            var result = benefitsManager.GetBenefitsCostForEmployee(employee);

            Assert.AreEqual(1350.00m, result);

            return;
        }

        [Test, Explicit]
        public void Test_GetBenefitsCostForEmployeeWithFiveDependentsNoDiscounts()
        {
            BenefitEmployee employee = new BenefitEmployee();

            employee.Employee = new Person("George", "Wright");

            employee.Dependents = new List<Person>();
            employee.Dependents.Add(new Person("Bob", "Wright"));
            employee.Dependents.Add(new Person("Billy", "Wright"));
            employee.Dependents.Add(new Person("Susan", "Wright"));
            employee.Dependents.Add(new Person("Mary", "Wright"));
            employee.Dependents.Add(new Person("Frank", "Wright"));

            BenefitsManager benefitsManager = new BenefitsManager();
            var result = benefitsManager.GetBenefitsCostForEmployee(employee);

            Assert.AreEqual(3500.00m, result);

            return;
        }

        [Test, Explicit]
        public void Test_GetBenefitsCostForEmployeeWithFiveDependentsWithDiscounts()
        {
            BenefitEmployee employee = new BenefitEmployee();

            employee.Employee = new Person("George", "Wright");

            employee.Dependents = new List<Person>();
            employee.Dependents.Add(new Person("Bob", "Wright"));
            employee.Dependents.Add(new Person("Allen", "Wright"));
            employee.Dependents.Add(new Person("Alice", "Wright"));
            employee.Dependents.Add(new Person("Mary", "Wright"));
            employee.Dependents.Add(new Person("Frank", "Wright"));

            BenefitsManager benefitsManager = new BenefitsManager();
            var result = benefitsManager.GetBenefitsCostForEmployee(employee);

            Assert.AreEqual(3400.00m, result);

            return;
        }

        [Test, Explicit]
        public void Test_GetEmployeeCostPerPayPeriod()
        {
            decimal benefitsCost = 1000.00m;

            BenefitsManager benefitsManager = new BenefitsManager();
            var result = benefitsManager.GetEmployeeCostPerPayPeriod(benefitsCost);

            Assert.AreEqual(2038.46m, result);
        }

        [Test, Explicit]
        public void Test_GetEmployeeCostPerPayPeriodUsingZeroCost()
        {
            decimal benefitsCost = 0.00m;

            BenefitsManager benefitsManager = new BenefitsManager();
            var result = benefitsManager.GetEmployeeCostPerPayPeriod(benefitsCost);

            Assert.AreEqual(2000.00m, result);
        }

        [Test, Explicit]
        public void Test_GetEmployeeCostPerPayPeriodUsingHighCost()
        {
            decimal benefitsCost = 8000.00m;

            BenefitsManager benefitsManager = new BenefitsManager();
            var result = benefitsManager.GetEmployeeCostPerPayPeriod(benefitsCost);

            Assert.AreEqual(2000.00m, result);
        }

        [Test, Explicit]
        public void Test_GetEmployeeCostPerYear()
        {
            decimal benefitsCost = 1000.00m;

            BenefitsManager benefitsManager = new BenefitsManager();
            var result = benefitsManager.GetEmployeeCostPerPayYear(benefitsCost);

            Assert.AreEqual(53000.00m, result);
        }

        [Test, Explicit]
        public void Test_GetEmployeeCostPerYearZeroBenefitsCost()
        {
            decimal benefitsCost = 0.00m;

            BenefitsManager benefitsManager = new BenefitsManager();
            var result = benefitsManager.GetEmployeeCostPerPayYear(benefitsCost);

            Assert.AreEqual(52000.00m, result);
        }
    }
}
