namespace CatchTheGold.Core
{
    public class Eroe
    {
        private string _name;
        static private int _power;
        public int X { get; private set; }
        public int Y { get; private set; }

        public Eroe(string name, int x, int y)
        {
            _name = name;
            _power = 0;
            X = x;
            Y = y;
        }

        public void Move(Direction direction, FieldElement[,] field)
        {
            switch (direction)
            {
                case Direction.Up:
                    {
                        if (CheckWall(field, direction) || (IsWinPosition() && HasPowerToWin()))
                        {
                            Y -= 1;
                        }

                        break;
                    }

                case Direction.Down:
                    {
                        if (CheckWall(field, direction))
                        {
                            Y += 1;
                        }

                        break;
                    }

                case Direction.Right:
                    {
                        if (CheckWall(field, direction))
                        {
                            X += 1;
                        }

                        break;
                    }

                case Direction.Left:
                    {
                        if (CheckWall(field, direction))
                        {
                            X -= 1;
                        }

                        break;
                    }
            }
        }

        private bool CheckWall(FieldElement[,] field, Direction direction)
        {
            return Field.CheckWall(field, direction, X, Y);
        }

        static public void ModPower()
        {
            _power += 10;
        }

        private bool IsWinPosition()
        {
            return GameLogic.IsWinPosition(X, Y);
        }

        private bool HasPowerToWin()
        {
            return GameLogic.HasPowerToWin(_power);
        }

        public int GetPower
        {
            get
            {
                return _power;
            }
        }
    }
}
