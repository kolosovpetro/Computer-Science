using System.Collections.Generic;
using System.Linq;

namespace MonteCarloMethod.Classes
{
    class Bucket
    {
        private int Step { get; set; }
        private Plan Tasks { get; set; }
        public int Size { get; private set; }
        private double[] Assessments { get; set; }
        public int Count { get; private set; }
        public double Min { get { return this.Assessments.Min(); } }
        public double Max { get { return this.Assessments.Max(); } }
        public double Avg { get { return this.Assessments.Average(); } }
        public Dictionary<double, double> Probabilities { get; private set; }
        public Dictionary<double, double> AccumProbabilities { get; private set; }

        public Bucket(Plan newTasks, int newSize = 1000)
        {
            this.Step = 12;
            this.Tasks = newTasks;
            this.Size = newSize;
            this.Assessments = new double[newSize];

            for (int i = 0; i < Assessments.Length; i++)
            {
                this.Assessments[i] = Tasks.GetRandomEstimations();
            }

            this.Count = (int)(Max - Min) / Step + 1;
            this.Probabilities = new Dictionary<double, double>();
            this.AccumProbabilities = new Dictionary<double, double>();
            this.SetProbabilities();
        }

        private int LesserCount(double Value)
        {
            return this.Assessments.Where(p => p <= Value).Count();
        }

        private double Chance(double CurrentCount)
        {
            return CurrentCount / this.Assessments.Length * 100;
        }

        private void SetProbabilities()
        {
            for (int i = 0; i < this.Count; i++)
            {
                double Time = this.Assessments.Min() + Step * i;
                int Count = this.LesserCount(Time);
                double CurrentChance = Chance(Count);
                AccumProbabilities.Add(Time, CurrentChance);
            }

            for (int i = 0; i < this.Count; i++)
            {
                double Time = this.Assessments.Min() + Step * i;
                int Actual = LesserCount(Time);
                double ActualChance = Chance(Actual);
                int Previous = LesserCount(Time - Step);
                var PreviousChance = Chance(Previous);
                Probabilities.Add(Time, ActualChance - PreviousChance);
            }
        }

    }
}
