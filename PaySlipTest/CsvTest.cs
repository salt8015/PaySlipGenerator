using Microsoft.VisualStudio.TestTools.UnitTesting;
using PaySlipGenerator.CsvHelp;
using PaySlipGenerator.Entities;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaySlipTest
{
    [TestClass]
    public class CsvTest
    {
        [TestMethod]
        public void CsvReaderTest()
        {
            List<Employee> expectEmployees = new List<Employee>();
            expectEmployees.Add(new Employee("David", "Rudd", 60050,9, "01 March - 31 March"));
            expectEmployees.Add(new Employee("Ryan", "Chen", 120000,10, "01 March - 31 March"));

            List<Employee> actualEmployees = csvReader.ReadCsvFile("c:\\users\\tony\\downloads\\employee.csv");

            CollectionAssert.AreEqual(expectEmployees, actualEmployees, new CustomEmployeeComparer());
        }
    }

    //CustomeComparer for comparing two lists
    internal class CustomEmployeeComparer : IComparer, IComparer<Employee>
    {
        public int Compare(object x, object y)
        {
            if (x is Employee && y is Employee)
            {
                return this.Compare((Employee)x, (Employee)y);
            }
            else
            {
                throw new ArgumentException("Not Equal");
            }
        }

        public int Compare(Employee x, Employee y)
        {
            if (x.FirstName.CompareTo(y.FirstName) != 0)
            {
                return x.FirstName.CompareTo(y.FirstName);
            }
            else if (x.LastName.CompareTo(y.LastName) != 0)
            {
                return x.LastName.CompareTo(y.LastName);
            }
            else if (x.AnnualSalary.CompareTo(y.AnnualSalary) != 0)
            {
                return x.AnnualSalary.CompareTo(y.AnnualSalary);
            }
            else if (x.SuperRate.CompareTo(y.SuperRate) != 0)
            {
                return x.SuperRate.CompareTo(y.SuperRate);
            }
            else if (x.PaymentStartDate.CompareTo(y.PaymentStartDate) != 0)
            {
                return x.PaymentStartDate.CompareTo(y.PaymentStartDate);
            }
            else
            {
                return 0;
            }
        }
    }
}
