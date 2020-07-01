﻿using MonteCarloMethod.Classes;
using NUnit.Framework;
using System.Linq;

namespace MonteCarloMethod.UnitTests
{
    [TestFixture]
    internal class UnitTests
    {
        [Test]
        public void TestLinqNumbersSelection()
        {
            var StringProcess = new Linq<string>();
            var Input = "10 20 30";
            var Values = Input.Split(' ');
            var NewValues = StringProcess.NumbersFromCollection(Values);
            Assert.That(NewValues.ToArray(), Is.EqualTo(new[] { "10", "20", "30" }));
        }
        
        [Test]
        public void TestTaskInitialization()
        {
            var Input = "10 20 30";
            var ConcreteTask = new Task(Input);
            Assert.That(ConcreteTask.Estimations[0], Is.EqualTo(10));
            Assert.That(ConcreteTask.Estimations[1], Is.EqualTo(20));
            Assert.That(ConcreteTask.Estimations[2], Is.EqualTo(30));
        }
    }
}