﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _20180117_GiocoCatchTheGold
{
    class Eroe
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

        public bool move(KeyEventArgs e, char[,] field, ref int top, ref int left)
        {
            switch (e.KeyCode)
            {
                case Keys.Up:
                    {
                        if ((y - 1 >= 0 && !check_wall(field, "Top")) || (win_position(xExit, yExit + 1) && win_for()))
                        {
                            top -= 50;
                            y -= 1;
                        }

                        break;
                    }

                case Keys.Down:
                    {
                        if (y + 1 <= 10 && !check_wall(field, "Down"))
                        {
                            top += 50;
                            y += 1;
                        }

                        break;
                    }

                case Keys.Right:
                    {
                        if (x + 1 <= 10 && !check_wall(field, "Right"))
                        {
                            left += 50;
                            x += 1;
                        }

                        break;
                    }

                case Keys.Left:
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

    class Nemico
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
