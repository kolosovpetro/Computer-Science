using MonteCarloMethod.Exceptions;
using System;
using System.Collections.Generic;

namespace MonteCarloMethod.Classes
{
    internal class Plan
    {
        private readonly Random _rand;
        private readonly List<Task> _newPlan;
        public int Count { get; private set; }
        public int Size { get; private set; }

        public Plan()
        {
            _rand = new Random();
            _newPlan = new List<Task>();
        }

        public void AddTask(Task task)
        {
            if (Count > 0 && task.Estimations.Length != Size)
            {
                throw new InvalidTaskCaseException("Next task estimations size must be same as in previous task.");
            }

            _newPlan.Add(task);
            Count++;

            if (Count == 1)
            {
                Size = task.Estimations.Length;
            }

        }

        public double GetRandomEstimations()
        {
            double Value = default;

            for (int I = 0; I < this.Count; I++)
            {
                int CaseIndex = _rand.Next(0, Size);
                Value += _newPlan[I].Estimations[CaseIndex];
            }

            return Value;
        }

        public void CheckSize()
        {
            if (Size > _newPlan.Count)
                throw new InvalidTaskCaseException("Number of Tasks should be the same as task estimations size.");
        }
    }
}
