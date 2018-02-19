using CatchTheGold.Core;
using System;
using System.Drawing;
using System.Windows.Forms;


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

        public void crea_Pictures(PictureBox[] oggetti, int ne, Control parent, int NOx, int NOy, char indicator, string path)
        {
            Random r = new Random();
            int x = 0;
            int y = 0;

            for (int i = 0; i < ne; i++)
            {
                x = r.Next(0, 11);
                y = r.Next(0, 11);

                if (x != NOx && y != NOy && campo[x, y] == '\0')
                {
                    campo[x, y] = indicator;
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

        public bool Check_Diamond(PictureBox[] v, int ne, int dimension, ref int pos)
        {
            bool f = false;

            for (int i = 0; i < ne; i++)
            {
                if (Eroe.x * dimension == v[i].Left && Eroe.y * dimension == v[i].Top)
                {
                    f = true;
                    pos = i;
                }
            }

            if (f) return true;
            else return false;
        }

        public bool Check_MaxPower(int max)
        {
            if (Eroe.power == max) return true;
            else return false;
        }

        public bool Check_WinGame(int x, int y)
        {
            if (Eroe.win_position(x, y) && Eroe.win_for()) return true;
            else return false;
        }

        static char[,] campo;

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

                campo = new char[11, 11];

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

                crea_Pictures(Diamonds, ND, panel1, 5, 0, 'D', "Diamante.png");
                crea_Pictures(Walls, NM, panel1, 5, 0, 'M', "Muro.png");

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
            pbEroe.PreviewKeyDown += MyPreviewKeyDown;
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
            int i = 0;

            var direction = ToDirection(e.KeyCode);
            if (!direction.HasValue) return;

            if (Eroe.move(direction.Value, campo, ref topEroe, ref leftEroe))
            {
                if(Check_Diamond(Diamonds, ND, dimension, ref i))
                {
                    Diamonds[i].Visible = false;
                    elimina_Picture(Diamonds, i, ref ND);

                    if (Eroe.power == 30)
                        timer1.Interval = 250;

                    if (Eroe.power >= 40)
                        timer1.Interval = 200;
                }

                txtForza.Text = Eroe.power.ToString();
            }

            else
            {
                if (Check_WinGame(5, -1))
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
            }

            pbEroe.Top = topEroe;
            pbEroe.Left = leftEroe;

            if (Check_MaxPower(50))
            {
                lblControl.Text = "FORZA OK !";
                lblControl.ForeColor = Color.Green;
                lblExit.ForeColor = Color.LightGreen;
            }
        }

        void MyPreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
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
            if (Nemico.move(campo, Eroe.x, Eroe.y, ref topNemico, ref leftNemico))
            {
                pbNemico.Top = topNemico;
                pbNemico.Left = leftNemico;

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

            pbNemico.Top = topNemico;
            pbNemico.Left = leftNemico;
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
