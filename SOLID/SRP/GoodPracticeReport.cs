namespace SOLID.SRP
{
    internal class GoodPracticeReport
    {
        public GoodPracticeReport(string reportData)
        {
            ReportData = reportData;
        }

        public IWriter Writer { get; set; }
        public IEditor Editor { get; set; }
        public ISaver Saver { get; set; }
        public IPrinter Printer { get; set; }
        public string ReportData { get; set; }

        public void WriteReport(string newText)     // writes report, adding text
        {
            Writer.WriteReport(newText);
        }

        public void PrintReport()                   // prints report on printer
        {
            Printer.PrintReport();
        }

        public void SaveReport()                    // saves report in particular file format
        {
            Saver.SaveReport();
        }

        public void EditReport()                    // edits report
        {
            Editor.EditReport();
        }

        // Now, every responsibility is stored under interface and current class doesn't have any info on it.
        // Here is only responsibility - is to work over reports, however, any details on the tools like
        // Printers, Writers, Savers, etc
    }
}
