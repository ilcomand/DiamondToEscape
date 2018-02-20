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
        [TestCase(Direction.Up, 2, 2, ExpectedResult = false)]
        [TestCase(Direction.Down, 2, 2, ExpectedResult = true)]
        [TestCase(Direction.Left, 2, 2, ExpectedResult = true)]
        [TestCase(Direction.Right, 2, 2, ExpectedResult = false)]

        public bool CheckWall(Direction direction, int x, int y)
        {
            var field = new[,] {
                {FieldElement.Empty, FieldElement.Empty, FieldElement.Empty },
                {FieldElement.Empty, FieldElement.Wall, FieldElement.Wall },
                {FieldElement.Wall, FieldElement.Empty, FieldElement.Empty },
                {FieldElement.Diamond, FieldElement.Diamond, FieldElement.Empty },
                {FieldElement.Empty, FieldElement.Empty, FieldElement.Diamond },
            };

            //var a = field[]
            
            var result = Field.CheckWall(field, direction, x, y);
            return result;
        }
    }
}
