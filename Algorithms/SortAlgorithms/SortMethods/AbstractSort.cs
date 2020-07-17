using System;
using System.Collections.Generic;
using SortAlgorithms.Interfaces;
using SortAlgorithms.Auxiliaries;
using SortAlgorithms.Arrays;
using System.IO;
using System.Linq;

namespace SortAlgorithms.SortMethods
{
    internal abstract class AbstractSort : ISort, IDataLogger
    {
        protected int[] InitArray { get; }
        public int[] SortedArray { get; protected set; }
        private string LogFilesPath { get; }
        public string Message { get; }
        private TimeSpan SortExecTime { get; set; }
        private string ArrayType { get; }

        protected AbstractSort(IEnumerable<int> collection)
        {
            InitArray = collection.ToArray();
            LogFilesPath = "../../Benchmarks/";
            SetSortExecTime();
            Message = $"{GetType().Name}, Array Size: {InitArray.Length}, Sorted for {SortExecTime}";
        }

        protected AbstractSort(AbstractArray array)
        {
            InitArray = array.GetArray();
            ArrayType = array.GetArrayType();
            LogFilesPath = $"../../Benchmarks/{ArrayType}/{GetType().Name}/";
            SetSortExecTime();
            Message = $"{GetType().Name}, Array Type: {ArrayType}, Array Size: {array.Size}, Sorted for {SortExecTime}";
        }

        public abstract void GetSortedArray();

        private void SetSortExecTime()
        {
            void Action() => GetSortedArray();
            SortExecTime = Measurements.Measure(Action);
        }

        public virtual void GetBenchmark()
        {
            Directory.CreateDirectory(LogFilesPath);
            var ReportPath = LogFilesPath + "Report.txt";
            var DataPath = LogFilesPath + "Data.txt";

            using (var sw = new StreamWriter(ReportPath, append: true))
            {
                sw.WriteLine(Message);
            }

            using (var sw = new StreamWriter(DataPath, append: true))
            {
                sw.WriteLine(SortExecTime);
            }
        }
    }
}
