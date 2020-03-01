using MonteCarloMethod.Exceptions;
using System.Linq;

namespace MonteCarloMethod.Classes
{
    class Task
    {
        private char Separator { get { return ' '; } }
        private LINQ<string> StringProcess { get; set; }
        public double[] Estimations { get; private set; }

        public Task(string Input)
        {
            StringProcess = new LINQ<string>();
            ParseData(Input);
        }

        private void ParseData(string Input)
        {
            string[] NewValues = StringProcess.NumbersFromCollection(Input.Split(Separator)).ToArray();

            if (NewValues.Length == 0)
                throw new IncorrectTaskFormat("Incorrect formatting. Correct is: 10 20 30 ...");

            this.Estimations = new double[NewValues.Length];

            for (int i = 0; i < NewValues.Length; i++)
            {
                Estimations[i] = int.Parse(NewValues[i]);
                if (i > 0 && Estimations[i] < Estimations[i - 1])
                    throw new InvalidScenarioValueException("Next Estimation cannot be worst than Previous.");
            }
        }
    }
}
