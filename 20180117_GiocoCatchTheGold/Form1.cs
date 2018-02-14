using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _20180117_GiocoCatchTheGold
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        //Le prime due funzioni fanno sparire gli oggetti:
        public void NO_visible_Oggetti(PictureBox[] v, int n)
        {
            for (int i = 0; i < n; i++)
                v[i].Visible = false;
        }

        public void NO_visible_Personaggi(PictureBox p)
        {
            p.Visible = false;
        }

        //Questa elimina un'immagine (diamante) quando la si prende, cancellandola anche dal vettore di picture:
        public void elimina_Picture(PictureBox[] v, int x, ref int n)
        {
            for (int i = x; i < n - 1; i++)
            {
                v[i] = v[i + 1];
            }

            n--;
        }

        static char[,] campo;
        Eroe eroe;
        Nemico nemico;

        int ND;//Numero dei diamanti.
        PictureBox[] D;

        int NM; //Numero dei muri.
        PictureBox[] M;

        int x, y; //Coordinate per i diamanti e i muri (generate random - automaticamente).

        bool f = false; //Serve per fare un controllo quando si vuole iniziare una nuova partita.

        string nome_eroe, nome_nemico; //Salvano il nome dell'immagine che selezionata.

        //Spostamento dell'eroe:
        void MyKeyDown(object sender, KeyEventArgs e)
        {
            if (eroe.move(e, campo))
            {
                //Controlla se ha preso qualche diamente:
                for (int i = 0; i < ND; i++)
                {
                    if (eroe.x * 50 == D[i].Left && eroe.y * 50 == D[i].Top)
                    {
                        D[i].Visible = false;
                        elimina_Picture(D, i, ref ND);

                        if (eroe.forza == 30)
                            timer1.Interval = 250;

                        if (eroe.forza >= 40)
                            timer1.Interval = 200;
                    }
                }

                txtForza.Text = eroe.forza.ToString();
            }

            else
            {
                //Controlla se la partita viene vinta:
                if (eroe.win_pos(5, -1) && eroe.win_for())
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

                    eroe.Enabled = false;
                    nemico.Enabled = false;

                    pictureBoxStart.Enabled = false;
                    pictureBoxNewGame.Focus();
                }
            }

            //Se la forza è al max. avverte sullo schermo:
            if (eroe.forza == 50)
            {
                lblControl.Text = "FORZA OK !";
                lblControl.ForeColor = Color.Green;

                lblExit.ForeColor = Color.LightGreen;
            }
        }

        void MyPreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            e.IsInputKey = true; //Serve per dire che qualunque evento della tastiera deve essere preso come input (le frecce non le prende di base).
        }

        //Questo pulsante avvia effettivamente la partita:
        private void pictureBoxStart_Click(object sender, EventArgs e)
        {
            eroe.Focus();
            eroe.PreviewKeyDown += MyPreviewKeyDown;
            eroe.KeyDown += MyKeyDown;

            lblSpiegazione.Visible = false;
            lblControl.Visible = true;
            lblControl.Text = "FORZA INSUFFICIENTE !";
            lblControl.ForeColor = Color.DarkRed;
            timer1.Start();
            timer1.Interval = 300;
        }


        //Il pulsante genera il campo e i personaggi:
        private void pictureBoxNewGame_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(txtNEroe.Text) && nome_eroe != "" && !string.IsNullOrWhiteSpace(txtNNemico.Text) && nome_nemico != "")
            {
                //Al primo avvio del gioco gli oggetti non spariscono (se si preme di nuovo il NEW GAME si):
                if (f)
                {
                    NO_visible_Oggetti(D, ND);
                    NO_visible_Oggetti(M, NM);
                    NO_visible_Personaggi(eroe);
                    NO_visible_Personaggi(nemico);

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

                Random r = new Random();
                ND = 5;
                D = new PictureBox[ND];
                NM = 10;
                M = new PictureBox[NM];

                x = 0;
                y = 0;

                //Vengono generati i diamanti e i muri in posizioni diversi:
                for (int i = 0; i < ND; i++)
                {
                    x = r.Next(0, 11);
                    y = r.Next(0, 11);

                    if (x != 5 && y != 0 && campo[x, y] == '\0')
                    {
                        campo[x, y] = 'D';
                        D[i] = new PictureBox();

                        D[i].Width = 50;
                        D[i].Height = 50;
                        D[i].Top = y * 50;
                        D[i].Left = x * 50;

                        D[i].ImageLocation = "Diamante.png";
                        D[i].SizeMode = PictureBoxSizeMode.StretchImage;
                        D[i].Parent = panel1;
                    }

                    else i--;
                }

                for (int i = 0; i < NM; i++)
                {
                    x = r.Next(0, 11);
                    y = r.Next(0, 11);

                    if (x != 5 && y != 0 && campo[x, y] == '\0')
                    {
                        campo[x, y] = 'M';
                        M[i] = new PictureBox();

                        M[i].Width = 50;
                        M[i].Height = 50;
                        M[i].Top = y * 50;
                        M[i].Left = x * 50;

                        M[i].ImageLocation = "Muro.png";
                        M[i].SizeMode = PictureBoxSizeMode.StretchImage;
                        M[i].Parent = panel1;
                    }

                    else i--;
                }

                //Creo i personaggi:
                eroe = new Eroe(panel1, txtNEroe.Text.ToUpper(), campo, nome_eroe);
                nemico = new Nemico(panel1, txtNNemico.Text.ToUpper(), campo, nome_nemico);

                f = true;

                pictureBoxStart.Enabled = true;
                txtForza.Text = "0";
            }
            
            else
            {
                MessageBox.Show("ERRORE, INFORMAZIONI MANCANTI !");
            }           
        }

        //Le "mie" immagini sono nel Debug del progetto:
        private void btnScegliImmagine2_Click(object sender, EventArgs e)
        {
            openFileDialog1.Filter = "Immagine|*.png";
            openFileDialog1.Title = "Seleziona un'immagine (png)";
            openFileDialog1.FileName = "";

            if (openFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                nome_nemico = openFileDialog1.FileName;
            }
        }

        private void btnScegliImmagine1_Click(object sender, EventArgs e)
        {
            openFileDialog1.Filter = "Immagine|*.png";
            openFileDialog1.Title = "Seleziona un'immagine (png)";
            openFileDialog1.FileName = "";

            if (openFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                nome_eroe = openFileDialog1.FileName;
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (nemico.move(campo, eroe.x, eroe.y))
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

                eroe.Enabled = false;
                nemico.Enabled = false;

                pictureBoxStart.Enabled = false;
                pictureBoxNewGame.Focus();
            }
        }
    }
}
