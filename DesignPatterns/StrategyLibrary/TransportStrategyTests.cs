using NUnit.Framework;
using StrategyLibrary.Strategies;
using StrategyLibrary.Transport;

namespace StrategyLibrary
{
    [TestFixture]
    internal class TransportStrategyTests
    {
        private readonly Point _a = new Point(0, 3);
        private readonly Point _b = new Point(4, 0);

        [Test]
        public void RoadStrategyTest()
        {
            var n1 = new Navigator(_a, _b);
            IRouteStrategy s1 = new RoadStrategy();
            n1.SetStrategy(s1);
            Assert.That(n1.GetRange(), Is.EqualTo(5.0));
            Assert.That(n1.GetMessage(), Is.EqualTo($"Road route between points (0, 3) and (4, 0) is build successfully."));
        }
    }
}
