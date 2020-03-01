using System;
using System.Collections.Generic;
using SortAlgorithms.Interfaces;
using SortAlgorithms.Auxiliaries;
using SortAlgorithms.Arrays;
using System.IO;

namespace SortAlgorithms.SortMethods
{
    abstract class AbstractSort : ISort, IDataLogger
    {
        public int[] InitArray { get; private set; }
        public int[] SortedArray { get; protected set; }
        protected string LogFilesPath { get; }
        public string Message { get; protected set; }
        public TimeSpan SortExecTime { get; protected set; }
        public string ArrayType { get; private set; }
        public AbstractArray AbsArray { get; private set; }

        public AbstractSort(IEnumerable<int> Collection)
        {
            InitArray = (int[])Collection;
            LogFilesPath = "../../Benchmarks/";
            SetSortExecTime();
            Message = $"{GetType().Name}, Array Size: {InitArray.Length}, Sorted for {SortExecTime}";
        }

        public AbstractSort(AbstractArray newAbsArray)
        {
            AbsArray = newAbsArray;
            InitArray = newAbsArray.GetArray();
            ArrayType = newAbsArray.GetArrayType();
            LogFilesPath = $"../../Benchmarks/{ArrayType}/{GetType().Name}/";
            SetSortExecTime();
            Message = $"{GetType().Name}, Array Type: {ArrayType}, Array Size: {newAbsArray.Size}, Sorted for {SortExecTime}";
        }
        public virtual void GetSortedArray()
        {
            return;
        }

        private void SetSortExecTime()
        {
            Action a = () => GetSortedArray();
            this.SortExecTime = Measurements.Measure(a);
        }

        public virtual void GetBenchmark()
        {
            Directory.CreateDirectory(LogFilesPath);
            string ReportPath = LogFilesPath + "Report.txt";
            string DataPath = LogFilesPath + "Data.txt";

            using (StreamWriter sw = new StreamWriter(ReportPath, append: true))
            {
                sw.WriteLine(Message);
            }
            using (StreamWriter sw = new StreamWriter(DataPath, append: true))
            {
                sw.WriteLine(SortExecTime);
            }
        }
    }
}
