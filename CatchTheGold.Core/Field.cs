using System;

namespace CatchTheGold.Core
{
    public class Field
    {
        public static bool CheckWall(FieldElement[,] field, Direction direction, int x, int y)
        {
            switch (direction)
            {
                case Direction.Up:                    
                    return (y - 1 >= 0 && field[x, y - 1] == FieldElement.Wall);

                case Direction.Down:
                    return (y + 1 <= (field.GetLength(0) - 1) && field[x, y + 1] == FieldElement.Wall);

                case Direction.Right:
                    return (x + 1 <= (field.GetLength(1) - 1) && field[x + 1, y] == FieldElement.Wall);

                case Direction.Left:
                    return (x - 1 >= 0 && field[x - 1, y] == FieldElement.Wall);

                default:
                    throw new Exception("Invalid direction");
            }            
        }
    }
}
