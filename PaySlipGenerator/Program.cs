using PaySlipGenerator.CsvHelp;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PaySlipGenerator.Entities;

namespace PaySlipGenerator
{
    class Program
    {
        static void Main(string[] args)
        {
            //Read a csv file
            Console.WriteLine("Please enter the path of the import file:");
            string importFilePath = Console.ReadLine();
            var employees = csvReader.ReadCsvFile(importFilePath);

            //Create payslips
            List<Payslip> payslips = new List<Payslip>();
            foreach (var e in employees)
            {
                payslips.Add(PaySlipCal.generate(e));
            }

            //Save the paylips in a csv file
            Console.WriteLine("Please enter the path of the export file:");
            string exportFilePath = Console.ReadLine();
            csvWriter.writeToCsv(exportFilePath, payslips);
        }
    }
}
