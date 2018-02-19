
namespace CatchTheGold.Core
{
    public class Eroe
    {
        private string _nome;
        private int _forza;
        public int x;
        public int y;
        public int xExit;
        public int yExit;

        public Eroe(string name, int _x, int _y)
        {
            _nome = name;
            _forza = 0;
            x = _x;
            y = _y;
            xExit = 5;
            yExit = -1;
        }

        public bool move(Direction direction, char[,] field, ref int top, ref int left)
        {
            switch (direction)
            {
                case Direction.Up:
                    {
                        if ((y - 1 >= 0 && !check_wall(field, "Top")) || (win_position(xExit, yExit + 1) && win_for()))
                        {
                            top -= 50;
                            y -= 1;
                        }

                        break;
                    }

                case Direction.Down:
                    {
                        if (y + 1 <= 10 && !check_wall(field, "Down"))
                        {
                            top += 50;
                            y += 1;
                        }

                        break;
                    }

                case Direction.Right:
                    {
                        if (x + 1 <= 10 && !check_wall(field, "Right"))
                        {
                            left += 50;
                            x += 1;
                        }

                        break;
                    }

                case Direction.Left:
                    {
                        if (x - 1 >= 0 && !check_wall(field, "Left"))
                        {
                            left -= 50;
                            x -= 1;
                        }

                        break;
                    }
            }

            if (x == xExit && y <= yExit)
            {
                return false;
            }

            else
            {
                if (check_power(field)) return true;
                else return false;
            }
        }

        public bool Move(Direction direction, FieldElement[,] field, ref int top, ref int left)
        {
            switch (direction)
            {
                case Direction.Up:
                    {
                        if ((y - 1 >= 0 && !check_wall(field, direction)) || (win_position(xExit, yExit + 1) && win_for()))
                        {
                            top -= 50;
                            y -= 1;
                        }

                        break;
                    }

                case Direction.Down:
                    {
                        if (y + 1 <= 10 && !check_wall(field, direction))
                        {
                            top += 50;
                            y += 1;
                        }

                        break;
                    }

                case Direction.Right:
                    {
                        if (x + 1 <= 10 && !check_wall(field, direction))
                        {
                            left += 50;
                            x += 1;
                        }

                        break;
                    }

                case Direction.Left:
                    {
                        if (x - 1 >= 0 && !check_wall(field, direction))
                        {
                            left -= 50;
                            x -= 1;
                        }

                        break;
                    }
            }

            if (x == xExit && y <= yExit)
            {
                return false;
            }

            else
            {
                if (CheckPower(field)) return true;
                else return false;
            }
        }

        private bool check_wall(FieldElement[,] field, Direction direction)
        {
            return Field.CheckWall(field, direction, x, y);
        }

        public bool check_wall(char[,] field, string direction)
        {
            bool f = false;

            switch(direction)
            {
                case "Top":
                    {
                        if (field[x, y - 1] == 'M')
                            f = true;

                        break;
                    }

                case "Down":
                    {
                        if (field[x, y + 1] == 'M')
                            f = true;

                        break;
                    }

                case "Right":
                    {
                        if (field[x + 1, y] == 'M')
                            f = true;

                        break;
                    }

                case "Left":
                    {
                        if (field[x - 1, y] == 'M')
                            f = true;

                        break;
                    }
            }

            if (f) return true;
            else return false;
        }

        public bool check_power(char[,] field)
        {
            if (field[x, y] == 'D')
            {
                field[x, y] = '\0';
                mod_power();
                return true;
            }

            else return false;
        }

        public bool CheckPower(FieldElement[,] field)
        {
            if (field[x, y] == FieldElement.Diamond)
            {
                field[x, y] = FieldElement.Empty;
                mod_power();
                return true;
            }

            else return false;
        }

        public void mod_power()
        {
            _forza += 10;
        }

        public int power
        {
            get
            {
                return _forza;
            }
        }

        public bool win_position(int x_exit, int y_exit)
        {
            if (x == x_exit && y == y_exit)
                return true;

            else
                return false;
        }

        public bool win_for()
        {
            if (_forza == 50)
                return true;
            else
                return false;
        }
    }

    
}
