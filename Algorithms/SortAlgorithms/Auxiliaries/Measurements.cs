using System;
using System.Diagnostics;

namespace SortAlgorithms.Auxiliaries
{
    internal static class Measurements
    {
        public static TimeSpan Measure(Action method)
        {
            var stopwatch = new Stopwatch();
            stopwatch.Start();
            method.Invoke();
            stopwatch.Stop();
            return stopwatch.Elapsed;
        }
    }
}
