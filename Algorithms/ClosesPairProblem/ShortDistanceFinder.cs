using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;

namespace ClosesPairProblem
{
    public class ShortDistanceFinder
    {
        private readonly Point[] _points;

        public ShortDistanceFinder(params Point[] points)
        {
            _points = points;
        }

        public double ShortestDistance()
        {
            // create a list of doubles, of distances
            var distances = new List<double>();

            // for t = 1 in points
            for (var i = 1; i < _points.Length; i++)
            {
                // calculate the distances of point[i] ... point[0]
                for (int j = i - 1; j >= 0; j--)
                {
                    var distance = Distance.CalculateDistance(_points[i], _points[j]);
                    distances.Add(distance);
                }
            }

            return distances.Min();
        }
    }
}