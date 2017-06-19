using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PaySlipGenerator.Entities;

namespace PaySlipGenerator.CsvHelp
{
    public class csvWriter
    {
        //write payslips to a csv file
        public static void writeToCsv(string filePath, List<Entities.Payslip> paySlips)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("name,pay period,gross income,income tax,net income,super");
            foreach (var p in paySlips)
            {
                sb.AppendLine(p.Name + "," + p.PayPeriod + "," + p.GrossIncome + "," + p.IncomeTax + "," + p.NetIncome + "," + p.Super);
            }
            File.WriteAllText(filePath, sb.ToString());
        }
    }
}
