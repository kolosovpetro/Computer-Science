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
        protected string LogFilesPath { get; }
        public TimeSpan SearchExecTime { get; protected set; }
        public string Message { get; protected set; }

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
            string reportPath = LogFilesPath + $"{GetType().Name}Report.txt";
            string dataPath = LogFilesPath + $"{GetType().Name}Data.txt";

            using (var sw = new StreamWriter(reportPath, append: true))
            {
                sw.WriteLine(Message);
            }

            using (var sw = new StreamWriter(dataPath, append: true))
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
