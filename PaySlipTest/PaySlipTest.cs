using System;
using PaySlipGenerator;
using PaySlipGenerator.Entities;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace PaySlipTest
{
    [TestClass]
    public class PaySlipTest
    {
        [TestMethod]
        public void IncomeTaxTest()
        {
            Assert.AreEqual(0, calIncomeTax(-2147483648));
            Assert.AreEqual(0, calIncomeTax(0));
            Assert.AreEqual(0, calIncomeTax(18200));
            Assert.AreEqual(298, calIncomeTax(37000));
            Assert.AreEqual(1462, calIncomeTax(80000));
            Assert.AreEqual(4546, calIncomeTax(180000));
            Assert.AreEqual(80528432, calIncomeTax(2147483647));
        }

        private void PaySlipGenerateTest1()
        {
            // Given
            string firstName = "David";
            string lastName = "Rudd";
            int annualSalary = 60050;
            double superRate = 9;
            string paymentStartDate = "01 March - 31 March";

            //Generate Payslip
            Payslip payslip = PaySlipCal.generate(new Employee(firstName, lastName, annualSalary, superRate, paymentStartDate));

            // Check
            Assert.AreEqual(payslip.Name, string.Concat(firstName, " ", lastName));
            Assert.AreEqual(payslip.GrossIncome, 5004);
            Assert.AreEqual(payslip.IncomeTax, 922);
            Assert.AreEqual(payslip.NetIncome, 4082);
            Assert.AreEqual(payslip.PayPeriod, paymentStartDate);
            Assert.AreEqual(payslip.Super, 450);
        }

        private void PaySlipGenerateTest2()
        {
            // Given
            string firstName = "Ryan";
            string lastName = "Chen";
            int annualSalary = 120000;
            double superRate = 10;
            string paymentStartDate = "01 March - 31 March";

            //Generate Payslip
            Payslip payslip = PaySlipCal.generate(new Employee(firstName, lastName, annualSalary, superRate, paymentStartDate));

            // Check
            Assert.AreEqual(payslip.Name, string.Concat(firstName, " ", lastName));
            Assert.AreEqual(payslip.GrossIncome, 10000);
            Assert.AreEqual(payslip.IncomeTax, 2696);
            Assert.AreEqual(payslip.NetIncome, 7304);
            Assert.AreEqual(payslip.PayPeriod, paymentStartDate);
            Assert.AreEqual(payslip.Super, 1000);
        }

        private int calIncomeTax(int annualSalary)
        {
            int incomeTax = 0;

            if (0 < annualSalary && annualSalary <= 18200)
            {
                incomeTax = 0;
            }
            else if (18200 < annualSalary && annualSalary <= 37000)
            {
                incomeTax = Convert.ToInt32(Math.Round((annualSalary - 18200) * 0.19) / 12);
            }
            else if (37000 < annualSalary && annualSalary <= 80000)
            {
                incomeTax = Convert.ToInt32(Math.Round(3572 + (annualSalary - 37000) * 0.325) / 12);
            }
            else if (80000 < annualSalary && annualSalary <= 180000)
            {
                incomeTax = Convert.ToInt32(Math.Round(17547 + (annualSalary - 80000) * 0.37) / 12);
            }
            else if (annualSalary > 180000)
            {
                incomeTax = Convert.ToInt32(Math.Round(54547 + (annualSalary - 180000) * 0.45) / 12);
            }

            return incomeTax;
        }
    }
}
