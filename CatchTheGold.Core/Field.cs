using System;

namespace CatchTheGold.Core
{
    public class Field
    {
        public static bool CheckWall(FieldElement[,] field, Direction direction, int x, int y)
        {
            bool move = false;

            switch (direction)
            {
                case Direction.Up:
                    {
                        if (y - 1 >= 0 && field[x, y - 1] != FieldElement.Wall) move = true;
                        break;
                    }

                case Direction.Down:
                    {
                        if (y + 1 <= (field.GetLength(0) - 1) && field[x, y + 1] != FieldElement.Wall) move = true;
                        break;
                    }

                case Direction.Right:
                    {
                        if (x + 1 <= (field.GetLength(1) - 1) && field[x + 1, y] != FieldElement.Wall) move = true;
                        break;
                    }

                case Direction.Left:
                    {
                        if (x - 1 >= 0 && field[x - 1, y] != FieldElement.Wall) move = true;
                        break;
                    }

                default:
                    throw new Exception("Invalid Direction !");
            }

            if (move) return true;
            else return false;          
        }
    }
}
