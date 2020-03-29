using MonteCarloMethod.Exceptions;
using System.Linq;

namespace MonteCarloMethod.Classes
{
    internal class Task
    {
        private static char Separator => ' ';
        private Linq<string> StringProcess { get; }
        public double[] Estimations { get; private set; }

        public Task(string input)
        {
            StringProcess = new Linq<string>();
            ParseData(input);
        }

        private void ParseData(string input)
        {
            string[] NewValues = StringProcess.NumbersFromCollection(input.Split(Separator)).ToArray();

            if (NewValues.Length == 0)
                throw new IncorrectTaskFormat("Incorrect formatting. Correct is: 10 20 30 ...");

            Estimations = new double[NewValues.Length];

            for (int I = 0; I < NewValues.Length; I++)
            {
                Estimations[I] = int.Parse(NewValues[I]);
                if (I > 0 && Estimations[I] < Estimations[I - 1])
                    throw new InvalidScenarioValueException("Next Estimation cannot be worst than Previous.");
            }
        }
    }
}
