using System;
using System.Collections.Generic;
using System.Linq;
using LumenWorks.Framework.IO.Csv;
using System.IO;
using PaySlipGenerator.Entities;
using System.Text.RegularExpressions;

namespace PaySlipGenerator.CsvHelp
{
    public class csvReader
    {
        //Read CSV
        public static List<Employee> ReadCsvFile(string filepath)
        {
            if (!filepath.ToLower().Contains(".csv"))
                throw new Exception("File must be a valid CSV file");

            var records = new List<Employee>();

            try
            {
                using (var csv = new CsvReader(new StreamReader(filepath), true))
                {
                    int fieldCount = csv.FieldCount;

                    var headers = csv.GetFieldHeaders().Select(x => x.ToLowerInvariant().Replace(" ", string.Empty)).ToArray();
                    while (csv.ReadNextRecord())
                    {
                        records.Add(CreateEmployeeItem(headers, csv));
                    }
                }
            }
            catch (Exception e)
            {
                throw;
            }
            return records;
        }

        //Read each row in the csv and create employee
        private static Employee CreateEmployeeItem(string[] headers, CsvReader csv)
        {
            string firstName = string.Empty;
            string lastName = string.Empty;
            int annualSalary = new int();
            double superRate = new double();
            string paymentStartDate = string.Empty;

            var index = 0;

            try
            {
                foreach (var header in headers)
                {
                    if (string.IsNullOrEmpty(csv[index]))
                        throw new Exception("Missing a value in the field '" + header + "'");

                    switch (header)
                    {
                        case "firstname":
                            firstName = csv[index];
                            break;
                        case "lastname":
                            lastName = csv[index];
                            break;
                        case "annualsalary":
                            if(!Regex.IsMatch(csv[index], @"\d"))
                            {
                                throw new Exception("Annualsalary need to be a number");
                            }
                            annualSalary = Convert.ToInt32(Regex.Replace(csv[index], "[^0-9.]", string.Empty));
                            break;
                        case "superrate(%)":
                            if (!Regex.IsMatch(csv[index], @"\d"))
                            {
                                throw new Exception("Super rate need to be a percentage");
                            }
                            superRate = Convert.ToDouble(Regex.Replace(csv[index], "[^0-9.]", string.Empty));
                            break;
                        case "paymentstartdate":
                            paymentStartDate = csv[index];
                            break;
                    }
                    index++;
                }
            }
            catch(Exception e)
            {
                throw;
            }
            return new Employee(firstName, lastName, annualSalary, superRate, paymentStartDate);
        }
    }
}
