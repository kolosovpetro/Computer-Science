using System;
using System.Collections.Generic;
using SortAlgorithms.Interfaces;
using SortAlgorithms.Auxiliaries;
using SortAlgorithms.Arrays;
using System.IO;

namespace SortAlgorithms.SortMethods
{
    internal abstract class AbstractSort : ISort, IDataLogger
    {
        public int[] InitArray { get; }
        public int[] SortedArray { get; protected set; }
        protected string LogFilesPath { get; }
        public string Message { get; protected set; }
        public TimeSpan SortExecTime { get; protected set; }
        public string ArrayType { get; }
        public AbstractArray AbsArray { get; }

        protected AbstractSort(IEnumerable<int> Collection)
        {
            InitArray = (int[])Collection;
            LogFilesPath = "../../Benchmarks/";
            SetSortExecTime();
            Message = $"{GetType().Name}, Array Size: {InitArray.Length}, Sorted for {SortExecTime}";
        }

        protected AbstractSort(AbstractArray newAbsArray)
        {
            AbsArray = newAbsArray;
            InitArray = newAbsArray.GetArray();
            ArrayType = newAbsArray.GetArrayType();
            LogFilesPath = $"../../Benchmarks/{ArrayType}/{GetType().Name}/";
            SetSortExecTime();
            Message = $"{GetType().Name}, Array Type: {ArrayType}, Array Size: {newAbsArray.Size}, Sorted for {SortExecTime}";
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
            string ReportPath = LogFilesPath + "Report.txt";
            string DataPath = LogFilesPath + "Data.txt";

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
