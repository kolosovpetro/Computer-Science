using System.Collections.Generic;
using System.Linq;

namespace MonteCarloMethod.Classes
{
    internal class Bucket
    {
        private int Step { get; }
        private Plan Tasks { get; }
        public int Size { get; }
        private double[] Assessments { get; }
        private int Count { get; }
        public double Min => Assessments.Min();
        public double Max => Assessments.Max();
        public double Avg => Assessments.Average();
        public Dictionary<double, double> Probabilities { get; }
        public Dictionary<double, double> AccumulatedProbabilities { get; }

        public Bucket(Plan plan, int size = 1000)
        {
            Step = 12;
            Tasks = plan;
            Size = size;
            Assessments = new double[size];

            for (var I = 0; I < Assessments.Length; I++) 
                Assessments[I] = Tasks.GetRandomEstimations();

            Count = (int)(Max - Min) / Step + 1;
            Probabilities = new Dictionary<double, double>();
            AccumulatedProbabilities = new Dictionary<double, double>();
            SetProbabilities();
        }

        private int LesserCount(double value)
        {
            return Assessments.Count(p => p <= value);
        }

        private double Chance(double currentCount)
        {
            return currentCount / Assessments.Length * 100;
        }

        private void SetProbabilities()
        {
            for (var J = 0; J < Count; J++)
            {
                var Time = Assessments.Min() + Step * J;
                var CurrentCount = LesserCount(Time);
                var CurrentChance = Chance(CurrentCount);
                AccumulatedProbabilities.Add(Time, CurrentChance);
            }

            for (var I = 0; I < Count; I++)
            {
                var Time = Assessments.Min() + Step * I;
                var Actual = LesserCount(Time);
                var ActualChance = Chance(Actual);
                var Previous = LesserCount(Time - Step);
                var PreviousChance = Chance(Previous);
                Probabilities.Add(Time, ActualChance - PreviousChance);
            }
        }

    }
}
