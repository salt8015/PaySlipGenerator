using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PaySlipGenerator.Entities;

namespace PaySlipTest
{
    [TestClass]
    public class EntitiesTest
    {
        [TestMethod]
        public void CreateNewEmployee()
        {
            // Given
            string firstName = "David";
            string lastName = "Rudd";
            int annualSalary = 60050;
            double superRate = 9;
            string paymentStartDate = "01 March - 31 March";

            //Create a new employee
            Employee employee = new Employee(firstName, lastName, annualSalary, superRate, paymentStartDate);

            //Test
            Assert.AreEqual(firstName, employee.FirstName);
            Assert.AreEqual(lastName, employee.LastName);
            Assert.AreEqual(annualSalary, employee.AnnualSalary);
            Assert.AreEqual(superRate, employee.SuperRate);
            Assert.AreEqual(paymentStartDate, employee.PaymentStartDate);
        }

        [TestMethod]
        public void CreateNewPayslip()
        {
            // Given
            string name = "David Rudd";
            string payPeriod = "01 March - 31 March";
            int grossIncome = 5004;
            int incomeTax = 922;
            int netIncome = 4082;
            int super = 9;

            // When
            Payslip payslip = new Payslip(name, payPeriod, grossIncome, incomeTax, super);

            // Then 
            Assert.AreEqual(payslip.Name, name);
            Assert.AreEqual(payslip.PayPeriod, payPeriod);
            Assert.AreEqual(payslip.GrossIncome, grossIncome);
            Assert.AreEqual(payslip.IncomeTax, incomeTax);
            Assert.AreEqual(payslip.NetIncome, netIncome);
            Assert.AreEqual(payslip.Super, super);
        }
    }
}
