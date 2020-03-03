namespace SOLID.SRP
{
    abstract class Report
    {
        private string data;

        /// <summary>
        /// Writes report and saves it to data field
        /// </summary>
        abstract public void WriteReport();

        /// <summary>
        /// Edits the data of any existing report class instance
        /// </summary>
        abstract public void EditReport(Report r);

        /// <summary>
        /// Saves current (this) report to file by path
        /// </summary>
        abstract public void SaveReportToFile(string path);
    }
}
