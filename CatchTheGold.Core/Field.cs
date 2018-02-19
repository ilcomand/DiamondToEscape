namespace CatchTheGold.Core
{
    class Field
    {
        public static bool CheckWall(char[,] field, Direction direction, int x, int y)
        {
            bool f = false;

            switch (direction)
            {
                case Direction.Up:
                    {
                        if (field[x, y - 1] == 'M')
                            f = true;

                        break;
                    }

                case Direction.Down:
                    {
                        if (field[x, y + 1] == 'M')
                            f = true;

                        break;
                    }

                case Direction.Right:
                    {
                        if (field[x + 1, y] == 'M')
                            f = true;

                        break;
                    }

                case Direction.Left:
                    {
                        if (field[x - 1, y] == 'M')
                            f = true;

                        break;
                    }
            }

            if (f) return true;
            else return false;
        }
    }
}
