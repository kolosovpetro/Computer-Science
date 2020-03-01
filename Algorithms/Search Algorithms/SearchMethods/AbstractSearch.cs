using System;
using System.Collections.Generic;
using System.IO;
using SearchAlgorithms.Interfaces;

namespace SearchAlgorithms.SearchMethods
{
    abstract class AbstractSearch : ISearch, IDataLogger
    {
        protected int SearchValue { get; private set; }
        protected int[] Array { get; private set; }
        protected string LogFilesPath { get; private set; }
        public TimeSpan SearchExecTime { get; protected set; }
        public string Message { get; protected set; }

        public AbstractSearch(IEnumerable<int> newCollection, int newSearchValue)
        {
            SearchValue = newSearchValue;
            Array = (int[])newCollection;
            LogFilesPath = $"../../Benchmarks/{GetType().Name}/";
            SetExecTime();
            Message = $"{GetType().Name}, Array Size: {Array.Length}, Search val: {SearchValue}, Result: {DoSearch()}, Exec time: {SearchExecTime}";
        }

        public virtual bool DoSearch()
        {
            return false;
        }

        public virtual void GetBenchmark()
        {
            Directory.CreateDirectory(LogFilesPath);
            string ReportPath = LogFilesPath + $"{GetType().Name}Report.txt";
            string DataPath = LogFilesPath + $"{GetType().Name}Data.txt";

            using (StreamWriter sw = new StreamWriter(ReportPath, append: true))
            {
                sw.WriteLine(Message);
            }
            using (StreamWriter sw = new StreamWriter(DataPath, append: true))
            {
                sw.WriteLine(SearchExecTime);
            }
        }

        private void SetExecTime()
        {
            Action a = () => DoSearch();
            SearchExecTime = Auxiliaries.Measurements.Measure(a);
        }
    }
}
