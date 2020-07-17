using System;
using System.Collections.Generic;
using System.IO;
using SearchAlgorithms.Interfaces;

namespace SearchAlgorithms.SearchMethods
{
    internal abstract class AbstractSearch : ISearch, IDataLogger
    {
        protected int SearchValue { get; }
        protected int[] Array { get; }
        private string LogFilesPath { get; }
        private TimeSpan SearchExecTime { get; set; }
        public string Message { get; }

        protected AbstractSearch(IEnumerable<int> collection, int searchValue)
        {
            SearchValue = searchValue;
            Array = (int[])collection;
            LogFilesPath = $"../../Benchmarks/{GetType().Name}/";
            SetExecTime();
            Message = $"{GetType().Name}, " +
                      $"Array Size: {Array.Length}, " +
                      $"Search val: {SearchValue}, " +
                      $"Result: {DoSearch()}, " +
                      $"Exec time: {SearchExecTime}";
        }

        public abstract bool DoSearch();

        public virtual void GetBenchmark()
        {
            Directory.CreateDirectory(LogFilesPath);
            var reportPath = LogFilesPath + $"{GetType().Name}Report.txt";
            var dataPath = LogFilesPath + $"{GetType().Name}Data.txt";

            using (var sw = new StreamWriter(reportPath, true))
            {
                sw.WriteLine(Message);
            }

            using (var sw = new StreamWriter(dataPath, true))
            {
                sw.WriteLine(SearchExecTime);
            }
        }

        private void SetExecTime()
        {
            void Action() => DoSearch();
            SearchExecTime = Auxiliaries.Measurements.Measure(Action);
        }
    }
}
