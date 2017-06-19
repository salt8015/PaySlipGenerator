using PaySlipGenerator.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaySlipGenerator
{
    public class PaySlipCal
    {
        public static Payslip generate(Employee employee)
        {
            return new Payslip(getName(employee.FirstName, employee.LastName),
                employee.PaymentStartDate,
                calGrossIncome(employee.AnnualSalary),
                calIncomeTax(employee.AnnualSalary),
                calSuper(calGrossIncome(employee.AnnualSalary), employee.SuperRate)
                );
        }

        private static string getName(string firstName, string lastName)
        {
            return string.Concat(firstName, " ", lastName);
        }

        private static int calGrossIncome(int annualSalary)
        {
            return Convert.ToInt32(Math.Round(Convert.ToDouble(annualSalary / 12)));
        }

        private static int calIncomeTax(int annualSalary)
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

        private static int calSuper(int grossIncome, double superRate)
        {
            return Convert.ToInt32(Math.Round(Convert.ToDouble(grossIncome * superRate / 100)));
        }
    }
}
