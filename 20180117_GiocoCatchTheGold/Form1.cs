using System;
using System.Drawing;
using System.Windows.Forms;
using CatchTheGold.Core;


namespace _20180117_GiocoCatchTheGold
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        public void NO_visible_Personaggi(PictureBox personaggio)
        {
            personaggio.Visible = false;
        }

        public void NO_visible_Oggetti(PictureBox[] v, int ne)
        {
            for (int i = 0; i < ne; i++)
                v[i].Visible = false;
        }

        public void crea_Personaggio(PictureBox personaggio, Control parent, int dimension, int top, int left, string imagepath)
        {
            personaggio.Width = dimension;
            personaggio.Height = dimension;
            personaggio.Top = top;
            personaggio.Left = left;

            personaggio.ImageLocation = imagepath;
            personaggio.SizeMode = PictureBoxSizeMode.StretchImage;

            personaggio.Parent = parent;
            personaggio.BringToFront();
        }

        public void crea_Pictures(PictureBox[] oggetti, int ne, Control parent, int NOx, int NOy, FieldElement indicator, string path)
        {
            Random r = new Random();
            int x = 0;
            int y = 0;

            for (int i = 0; i < ne; i++)
            {
                x = r.Next(0, 11);
                y = r.Next(0, 11);

                if (x != NOx && y != NOy && field[x, y] == FieldElement.Empty)
                {
                    field[x, y] = indicator;
                    oggetti[i] = new PictureBox();

                    oggetti[i].Width = dimension;
                    oggetti[i].Height = dimension;
                    oggetti[i].Top = y * dimension;
                    oggetti[i].Left = x * dimension;

                    oggetti[i].ImageLocation = path;
                    oggetti[i].SizeMode = PictureBoxSizeMode.StretchImage;
                    oggetti[i].Parent = parent;
                }

                else i--;
            }
        }

        public void elimina_Picture(PictureBox[] v, int x, ref int ne)
        {
            for (int i = x; i < ne - 1; i++)
            {
                v[i] = v[i + 1];
            }

            ne--;
        }

        public void Image_Select(OpenFileDialog ofd, ref string name)
        {
            {
                ofd.Filter = "Immagine|*.png";
                ofd.Title = "Seleziona un'immagine (png)";
                ofd.FileName = "";

                if (ofd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    name = ofd.FileName;
                }
            }
        }

        public int Find_Diamond(PictureBox[] v, int ne, int dimension)
        {
            for (int i = 0; i < ne; i++)
            {
                if (Eroe.X * dimension == v[i].Left && Eroe.Y * dimension == v[i].Top)
                {
                    return i;
                }
            }

            return -1;
        }

        public bool Check_MaxPower(int max)
        {
            if (Eroe.GetPower == max) return true;
            else return false;
        }

        public bool Check_WinGame(int x, int y)
        {
            if (Logic.YouWin(x, y)) return true;
            else return false;
        }

        static FieldElement[,] field;
        GameLogic Logic;

        PictureBox[] Diamonds;
        PictureBox[] Walls;
        int ND, NM;

        Eroe Eroe;
        PictureBox pbEroe;
        int topEroe, leftEroe;

        Nemico Nemico;
        PictureBox pbNemico;
        int topNemico, leftNemico;

        int dimension = 50;
        bool new_game = false;
        string path_eroe, path_nemico;

        private void pictureBoxNewGame_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(txtNEroe.Text) && path_eroe != "" && !string.IsNullOrWhiteSpace(txtNNemico.Text) && path_nemico != "")
            {
                if (new_game)
                {
                    NO_visible_Personaggi(pbEroe);
                    NO_visible_Personaggi(pbNemico);
                    NO_visible_Oggetti(Diamonds, ND);
                    NO_visible_Oggetti(Walls, NM);

                    txtForza.Text = "";
                    lblControl.Text = "";
                }

                timer1.Stop();

                lblSpiegazione.Visible = true;
                lblInfoFinale.Visible = false;
                lblForza.Visible = true;
                txtForza.Visible = true;
                pictureBoxEND.Visible = false;
                lblExit.ForeColor = Color.Tomato;

                field = new FieldElement[11, 11];
                Logic = new GameLogic();

                ND = 5;
                Diamonds = new PictureBox[ND];

                NM = 15;
                Walls = new PictureBox[NM];

                pbEroe = new PictureBox();
                topEroe = 450;
                leftEroe = 250;

                pbNemico = new PictureBox();
                topNemico = 50;
                leftNemico = 50;

                Eroe = new Eroe(txtNEroe.Text, 5, 9);
                crea_Personaggio(pbEroe, panel1, dimension, topEroe, leftEroe, path_eroe);

                Nemico = new Nemico(txtNNemico.Text, 1, 1);
                crea_Personaggio(pbNemico, panel1, dimension, topNemico, leftNemico, path_nemico);

                crea_Pictures(Diamonds, ND, panel1, 5, 0, FieldElement.Diamond, "Diamante.png");
                crea_Pictures(Walls, NM, panel1, 5, 0, FieldElement.Wall, "Muro.png");

                new_game = true;

                pictureBoxStart.Enabled = true;
                txtForza.Text = "0";
            }

            else
            {
                MessageBox.Show("ERRORE, INFORMAZIONI MANCANTI !");
            }
        }

        private void pictureBoxStart_Click(object sender, EventArgs e)
        {
            pbEroe.Focus();
            pbEroe.PreviewKeyDown += OnPreviewKeyDown;
            pbEroe.KeyDown += OnKeyDown;

            lblSpiegazione.Visible = false;
            lblControl.Visible = true;
            lblControl.Text = "FORZA INSUFFICIENTE !";
            lblControl.ForeColor = Color.DarkRed;
            timer1.Start();
            timer1.Interval = 300;
        }

        void OnKeyDown(object sender, KeyEventArgs e)
        {
            var direction = ToDirection(e.KeyCode);
            if (!direction.HasValue) return;

            Eroe.Move(direction.Value, field);

            pbEroe.Top = dimension * Eroe.Y;
            pbEroe.Left = dimension * Eroe.X;

            if (Check_WinGame(Eroe.X, Eroe.Y))
            {
                pictureBoxEND.Visible = true;
                pictureBoxEND.BringToFront();
                pictureBoxEND.ImageLocation = "You Win.gif";

                lblInfoFinale.Visible = true;
                lblInfoFinale.Parent = pictureBoxEND;
                lblInfoFinale.ForeColor = Color.BlueViolet;
                lblInfoFinale.Text = txtNEroe.Text + " E' FUGGITO DA " + txtNNemico.Text + " !";

                lblForza.Visible = false;
                txtForza.Visible = false;
                lblControl.Visible = false;

                pbEroe.Enabled = false;
                pbNemico.Enabled = false;

                pictureBoxStart.Enabled = false;
                pictureBoxNewGame.Focus();
            }

            else
            {
                if (Logic.CheckPower(field, Eroe.X, Eroe.Y, Eroe.GetPower))
                {
                    int i = Find_Diamond(Diamonds, ND, dimension);

                    if (i != -1)
                    {
                        Diamonds[i].Visible = false;
                        elimina_Picture(Diamonds, i, ref ND);
                    }

                    txtForza.Text = Eroe.GetPower.ToString();

                    if (Eroe.GetPower == 30)
                        timer1.Interval = 250;

                    if (Eroe.GetPower >= 40)
                        timer1.Interval = 200;

                    if (Check_MaxPower(50))
                    {
                        lblControl.Text = "FORZA OK !";
                        lblControl.ForeColor = Color.Green;
                        lblExit.ForeColor = Color.LightGreen;
                    }
                }
            }
        }

        void OnPreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            e.IsInputKey = true;
        }

        private void btnScegliImmagine2_Click(object sender, EventArgs e)
        {
            Image_Select(openFileDialog1, ref path_nemico);
        }

        private void btnScegliImmagine1_Click(object sender, EventArgs e)
        {
            Image_Select(openFileDialog1, ref path_eroe);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            Nemico.Move(field, Eroe.X, Eroe.Y);

            pbNemico.Top = dimension * Nemico.Y;
            pbNemico.Left = dimension * Nemico.X;

            if (Logic.YouLose(Nemico.X, Nemico.Y, Eroe.X, Eroe.Y))
            {
                timer1.Stop();

                pictureBoxEND.Visible = true;
                pictureBoxEND.BringToFront();
                pictureBoxEND.ImageLocation = "Game Over.gif";

                lblInfoFinale.Visible = true;
                lblInfoFinale.Parent = pictureBoxEND;
                lblInfoFinale.ForeColor = Color.Red;
                lblInfoFinale.Text = txtNNemico.Text + " HA UCCISO " + txtNEroe.Text + " !";

                lblForza.Visible = false;
                txtForza.Visible = false;
                lblControl.Visible = false;
                lblSpiegazione.Visible = true;

                pbEroe.Enabled = false;
                pbNemico.Enabled = false;

                pictureBoxStart.Enabled = false;
                pictureBoxNewGame.Focus();
            }
        }
           
        private Direction? ToDirection(Keys keyCode)
        {
            switch (keyCode)
            {
                case Keys.Up:
                    return Direction.Up;
                case Keys.Down:
                    return Direction.Down;
                case Keys.Left:
                    return Direction.Left;
                case Keys.Right:
                    return Direction.Right;
                default:
                    return null;
            }
        }
    } 
}
