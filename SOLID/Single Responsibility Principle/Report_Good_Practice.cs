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
        /// Edits current (this) Report's data field
        /// </summary>
        abstract public void EditReport();

        /// <summary>
        /// Getter of Report's data
        /// </summary>
        /// <returns></returns>
        public string GetData()
        {
            return this.data;
        }
    }

    abstract class WriteReportToFile
    {
        private Report r;

        /// <summary>
        /// Setter for report field
        /// </summary>
        /// <param name="newReport">New instance to be assigned to field 'r'</param>
        public void SetReport(Report newReport)
        {
            r = newReport;
        }

        /// <summary>
        /// Saves Report to file at particular path
        /// </summary>
        /// <param name="filePath">Path to file where report will be saved</param>
        public abstract void SaveReport(string filePath);
    }
        
}
