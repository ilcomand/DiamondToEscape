using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace _20180117_GiocoCatchTheGold
{
    class Eroe : PictureBox
    {
        private string _nome;
        private int _forza;
        public int x;
        public int y;

        public Eroe(Control parent, string nome, char[,] field, string imagepath)
        {
            Width = 50;
            Height = 50;
            Top = 450;
            Left = 250;

            ImageLocation = imagepath;
            SizeMode = PictureBoxSizeMode.StretchImage;

            Parent = parent;

            _nome = nome;
            _forza = 0;

            x = 5;
            y = 9;

            BringToFront();
        }

        //Movimento dell'eroe:
        public bool move(KeyEventArgs e, char[,] field)
        {
            switch (e.KeyCode)
            {
                case Keys.Up:
                    {
                        //Viene controllato che se è possibile vincere (posizione e forza) mi fa uscire altrimenti si blocca sui limiti del campo:
                        if ((y - 1 >= 0 && !check_wall(field, "Top")) || (win_pos(5,0) && win_for()))
                        {
                            Top -= 50;
                            y -= 1;
                        }

                        break;
                    }

                case Keys.Down:
                    {
                        if (y + 1 <= 10 && !check_wall(field, "Down"))
                        {
                            Top += 50;
                            y += 1;
                        }

                        break;
                    }

                case Keys.Right:
                    {
                        if (x + 1 <= 10 && !check_wall(field, "Right"))
                        {
                            Left += 50;
                            x += 1;
                        }

                        break;
                    }

                case Keys.Left:
                    {
                        if (x - 1 >= 0 && !check_wall(field, "Left"))
                        {
                            Left -= 50;
                            x -= 1;
                        }

                        break;
                    }
            }

            //Se si riesce a uscire dal gioco (vincere) ritorna false in modo che dal Main dice che si è vinto:
            if (x == 5 && y <= -1)
            {
                return false;
            }

            else
            {
                if (power(field)) return true; //Ritorna true se la forza viene modificata.
                else return false;
            }
        }

        //Controlla se nella direzione dove si vuole andare c'è un muro:
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

        //Controlla se viene preso un diamante e quindi modifica la forza:
        public bool power(char[,] field)
        {
            if (field[x, y] == 'D')
            {
                field[x, y] = '\0';
                mod_forza();
                return true;
            }

            else return false;
        }

        public void mod_forza()
        {
            _forza += 10;
        }

        public int forza
        {
            get
            {
                return _forza;
            }
        }

        //Controlla se la posizione dell'eroe coincide con quella della porta:
        public bool win_pos(int x_exit, int y_exit)
        {
            if (x == x_exit && y == y_exit)
                return true;

            else
                return false;
        }

        //Controlla se la forza è al max.:
        public bool win_for()
        {
            if (_forza == 50)
                return true;
            else
                return false;
        }
    }

    class Nemico : PictureBox
    {
        public string _nome;
        public int x;
        public int y;

        public bool d; //Serve per farlo muovere una volta in y ed una in x.

        public Nemico(Control parent, string nome, char[,] field, string imagepath)
        {
            Width = 50;
            Height = 50;
            Top = 50;
            Left = 50;

            ImageLocation = imagepath;
            SizeMode = PictureBoxSizeMode.StretchImage;

            Parent = parent;

            BringToFront();

            _nome = nome;

            x = 1;
            y = 1;

            d = false; //false -> si muove in y | true -> si muove in x.
                  
        }

        //Movimento del nemico (i codici commentati erano solo per far muovere sempre il nemico, ovvero se c'era un ostacolo nella direzione dove doveva muoversi; così se non può andarci aspetta il prossimo tick):
        public bool move(char[,] field, int xe, int ye)
        {
            if (d)
            {
                //Spostamento in x (quando è MINORE dell'eroe):
                if (x < xe)
                {
                    if (x + 1 <= 10 && field[x + 1, y] != 'M')
                    {
                        x += 1;
                        Left += 50;
                    }

                    //Se lo spostamento in x è ostruito si muove in y:
                    //else
                    //{
                    //    if (y < ye)
                    //    {
                    //        if (y + 1 <= 10 && field[x, y + 1] != 'M')
                    //        {
                    //            y += 1;
                    //            Top += 50;
                    //        }
                    //    }

                    //    else
                    //    {
                    //        if (y - 1 >= 0 && field[x, y - 1] != 'M')
                    //        {
                    //            y -= 1;
                    //            Top -= 50;
                    //        }
                    //    }
                    //}
                }

                //Spostamento in x (quando è MAGGIORE dell'eroe):
                else
                {
                    if (x - 1 >= 0 && field[x - 1, y] != 'M')
                    {
                        x -= 1;
                        Left -= 50;
                    }

                    //Se lo spostamento in x è ostruito si muove in y:
                    //else
                    //{
                    //    if (y < ye)
                    //    {
                    //        if (y + 1 <= 10 && field[x, y + 1] != 'M')
                    //        {
                    //            y += 1;
                    //            Top += 50;
                    //        }
                    //    }

                    //    else
                    //    {
                    //        if (y - 1 >= 0 && field[x, y - 1] != 'M')
                    //        {
                    //            y -= 1;
                    //            Top -= 50;
                    //        }
                    //    }
                    //}
                }

                d = false;
            }

            //Spostamento in y (quando è MINORE dell'eroe):
            else
            {
                if (y < ye)
                {
                    if (y + 1 <= 10 && field[x, y + 1] != 'M')
                    {
                        y += 1;
                        Top += 50;
                    }

                    //Se lo spostamento in y è ostruito si muove in x:
                    //else
                    //{
                    //    if (x < xe)
                    //    {
                    //        if (x + 1 <= 10 && field[x + 1, y] != 'M')
                    //        {
                    //            x += 1;
                    //            Left += 50;
                    //        }
                    //    }

                    //    else
                    //    {
                    //        if (x - 1 >= 0 && field[x - 1, y] != 'M')
                    //        {
                    //            x -= 1;
                    //            Left -= 50;
                    //        }
                    //    }
                    //}
                }

                //Spostamento in y (quando è MAGGIORE dell'eroe):
                else
                {
                    if (y - 1 >= 0 && field[x, y - 1] != 'M')
                    {
                        y -= 1;
                        Top -= 50;
                    }

                    //Se lo spostamento in y è ostruito si muove in x:
                    //else
                    //{
                    //    if (x < xe)
                    //    {
                    //        if (x + 1 <= 10 && field[x + 1, y] != 'M')
                    //        {
                    //            x += 1;
                    //            Left += 50;
                    //        }
                    //    }

                    //    else
                    //    {
                    //        if (x - 1 >= 0 && field[x - 1, y] != 'M')
                    //        {
                    //            x -= 1;
                    //            Left -= 50;
                    //        }
                    //    }
                    //}
                }

                d = true;
            }

            //Controlla se la posizione del nemico coincide con quella dell'eroe:
            if ((x == xe) && (y == ye))
                return true;
            else
                return false;
        }
    }
}
