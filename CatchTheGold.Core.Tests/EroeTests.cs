using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CatchTheGold.Core.Tests
{
    [TestFixture]
    public class EroeTests
    {
        [TestCase(Direction.Up, 2, 0, 2, 0)]
        [TestCase(Direction.Up, 0, 1, 0, 0)]
        [TestCase(Direction.Up, 1, 2, 1, 2)]
        [TestCase(Direction.Left, 0, 4, 0, 4)]
        [TestCase(Direction.Down, 1, 4, 1, 4)]
        [TestCase(Direction.Right, 2, 0, 2, 0)]
        [TestCase(Direction.Right, 0, 1, 0, 1)]

        public void Move(Direction direction, int startX, int startY, int expectedX, int expectedY)
        {
            Eroe eroe = new Eroe("", startX, startY);

            var field = new[,] {
                {FieldElement.Empty, FieldElement.Empty, FieldElement.Empty },
                {FieldElement.Empty, FieldElement.Wall, FieldElement.Wall },
                {FieldElement.Wall, FieldElement.Empty, FieldElement.Empty },
                {FieldElement.Diamond, FieldElement.Diamond, FieldElement.Empty },
                {FieldElement.Empty, FieldElement.Empty, FieldElement.Diamond },
            };

            eroe.Move(direction, field);
            Assert.AreEqual(expectedX, eroe.X);
            Assert.AreEqual(expectedY, eroe.Y);
        }
    }
}
