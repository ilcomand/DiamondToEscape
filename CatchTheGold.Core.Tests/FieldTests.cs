using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CatchTheGold.Core.Tests
{
    [TestFixture]
    public class FieldTests
    {
        [TestCase(Direction.Up, 0, 2, ExpectedResult = false)]
        [TestCase(Direction.Up, 1, 2, ExpectedResult = true)]
        [TestCase(Direction.Down, 2, 0, ExpectedResult = false)]
        [TestCase(Direction.Left, 3, 2, ExpectedResult = false)]
        [TestCase(Direction.Down, 2, 1, ExpectedResult = false)]
        [TestCase(Direction.Down, 4, 0, ExpectedResult = false)]
        [TestCase(Direction.Left, 0, 3, ExpectedResult = false)]
        [TestCase(Direction.Right, 2, 4, ExpectedResult = false)]
        public bool CheckWall(Direction direction, int x, int y)
        {
            var field = new[,] {
                {FieldElement.Empty, FieldElement.Empty, FieldElement.Empty },
                {FieldElement.Empty, FieldElement.Wall, FieldElement.Wall },
                {FieldElement.Wall, FieldElement.Empty, FieldElement.Empty },
                {FieldElement.Diamond, FieldElement.Diamond, FieldElement.Empty },
                {FieldElement.Empty, FieldElement.Empty, FieldElement.Diamond },
            };
            
            var result = Field.CheckWall(field, direction, x, y);
            return result;
        }
    }
}
