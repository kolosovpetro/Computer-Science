using System;

namespace SOLID.SRP
{
    // class in context of usual report, provided by worker
    class BadPracticeReport
    {
        public string ReportData { get; set; }      // entire contents of report

        public void WriteReport(string newText)     // writes report, adding text
        {
            this.ReportData += newText;
        }

        public void PrintReport()                   // prints report on printer
        {
            Console.WriteLine(this.ReportData);
        }

        public void SaveReport()                    // saves report in particular file format
        {
            Console.WriteLine($"Report is saved. Format is txt.");
        }

        public void EditReport()                    // edits report
        {
            Console.WriteLine($"Report has been edited by program PDF reader.");
        }

        // Current class strongly breaks SRP principle, since it is contains context of all the methods in it
        // Future extension of such "god-pattern" anti-patter will lead to overcomplicated spaghetti code
        // It is more convenient to place each method under particular interface, see GoodPractice class
    }
}
