using MonteCarloMethod.Exceptions;
using System;
using System.Collections.Generic;

namespace MonteCarloMethod.Classes
{
    class Plan
    {
        private Random Rand;
        private List<Task> NewPlan;
        public int Count { get; private set; }
        public int Size { get; private set; }

        public Plan()
        {
            this.Rand = new Random();
            this.NewPlan = new List<Task>();
        }

        public void AddTask(Task Task)
        {
            if (this.Count > 0 && Task.Estimations.Length != this.Size)
            {
                throw new InvalidTaskCaseException("Next task estimations size must be same as in previous task.");
            }

            this.NewPlan.Add(Task);
            this.Count++;

            if (Count == 1)
            {
                this.Size = Task.Estimations.Length;
            }

        }

        public double GetRandomEstimations()
        {
            double Value = default;

            for (int i = 0; i < this.Count; i++)
            {
                int CaseIndex = Rand.Next(0, Size);
                Value += NewPlan[i].Estimations[CaseIndex];
            }

            return Value;
        }

        public void CheckSize()
        {
            if (Size > NewPlan.Count)
                throw new InvalidTaskCaseException("Number of Tasks should be the same as task estimations size.");
        }
    }
}
