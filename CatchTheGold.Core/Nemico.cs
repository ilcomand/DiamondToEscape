namespace CatchTheGold.Core
{
    public class Nemico
    {
        public string _name;
        public int X { get; private set; }
        public int Y { get; private set; }

        public bool direction; //Serve per farlo muovere una volta in y ed una in x.

        public Nemico(string name, int x, int y)
        {
            _name = name;
            X = x;
            Y = y;

            direction = false; //false -> si muove in y | true -> si muove in x.                 
        }

        public void Move(FieldElement[,] field, int EroeX, int EroeY)
        {
            if (direction)
            {
                if (X < EroeX)
                {
                    if (CheckWall(field, Direction.Right))
                    {
                        X += 1;
                    }
                }

                else
                {
                    if (CheckWall(field, Direction.Left))
                    {
                        X -= 1;
                    }
                }

                direction = false;
            }

            else
            {
                if (Y < EroeY)
                {
                    if (CheckWall(field, Direction.Down))
                    {
                        Y += 1;
                    }
                }

                else
                {
                    if (CheckWall(field, Direction.Up))
                    {
                        Y -= 1;
                    }
                }

                direction = true;
            }
        }

        private bool CheckWall(FieldElement[,] field, Direction direction)
        {
            return Field.CheckWall(field, direction, X, Y);
        }
    }
}
