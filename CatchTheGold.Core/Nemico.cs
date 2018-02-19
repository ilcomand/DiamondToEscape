namespace CatchTheGold.Core
{
    public class Nemico
    {
        public string _nome;
        public int x;
        public int y;

        public bool direction; //Serve per farlo muovere una volta in y ed una in x.

        public Nemico(string name, int _x, int _y)
        {
            _nome = name;
            x = _x;
            y = _y;

            direction = false; //false -> si muove in y | true -> si muove in x.                 
        }

        public bool move(char[,] field, int xeroe, int yeroe, ref int top, ref int left)
        {
            if (direction)
            {
                if (x < xeroe)
                {
                    if (x + 1 <= 10 && field[x + 1, y] != 'M')
                    {
                        x += 1;
                        left += 50;
                    }
                }

                else
                {
                    if (x - 1 >= 0 && field[x - 1, y] != 'M')
                    {
                        x -= 1;
                        left -= 50;
                    }
                }

                direction = false;
            }

            else
            {
                if (y < yeroe)
                {
                    if (y + 1 <= 10 && field[x, y + 1] != 'M')
                    {
                        y += 1;
                        top += 50;
                    }
                }

                else
                {
                    if (y - 1 >= 0 && field[x, y - 1] != 'M')
                    {
                        y -= 1;
                        top -= 50;
                    }
                }

                direction = true;
            }

            if ((x == xeroe) && (y == yeroe))
                return true;
            else
                return false;
        }
    }
}
