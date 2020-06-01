using NUnit.Framework;

namespace StrategyLibrary.Transport
{
    [TestFixture]
    class TransportStrategyTests
    {
        Point A = new Point(0, 3);
        Point B = new Point(4, 0);

        [Test]
        public void RoadStrategyTest()
        {
            Navigator n1 = new Navigator(A, B);
            IRouteStrategy s1 = new RoadStrategy();
            n1.SetStrategy(s1);
            Assert.That(n1.GetRange(), Is.EqualTo(5.0));
            Assert.That(n1.GetMessage(), Is.EqualTo($"Road route between points (0, 3) and (4, 0) is build sucessfully."));
        }
    }
}
