namespace _20180117_GiocoCatchTheGold
{
    partial class Form1
    {
        /// <summary>
        /// Variabile di progettazione necessaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Pulire le risorse in uso.
        /// </summary>
        /// <param name="disposing">ha valore true se le risorse gestite devono essere eliminate, false in caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Codice generato da Progettazione Windows Form

        /// <summary>
        /// Metodo necessario per il supporto della finestra di progettazione. Non modificare
        /// il contenuto del metodo con l'editor di codice.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblInfoFinale = new System.Windows.Forms.Label();
            this.lblExit = new System.Windows.Forms.Label();
            this.pictureBoxExit = new System.Windows.Forms.PictureBox();
            this.pictureBoxEND = new System.Windows.Forms.PictureBox();
            this.lblForza = new System.Windows.Forms.Label();
            this.txtForza = new System.Windows.Forms.TextBox();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.lblControl = new System.Windows.Forms.Label();
            this.pictureBoxStart = new System.Windows.Forms.PictureBox();
            this.pictureBoxNewGame = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtNEroe = new System.Windows.Forms.TextBox();
            this.txtNNemico = new System.Windows.Forms.TextBox();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.btnScegliImmagine1 = new System.Windows.Forms.Button();
            this.btnScegliImmagine2 = new System.Windows.Forms.Button();
            this.lblEroe = new System.Windows.Forms.Label();
            this.lblNemico = new System.Windows.Forms.Label();
            this.lblNomeGioco = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.lblSpiegazione = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxExit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxEND)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxStart)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxNewGame)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Transparent;
            this.panel1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("panel1.BackgroundImage")));
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Controls.Add(this.lblInfoFinale);
            this.panel1.Controls.Add(this.lblExit);
            this.panel1.Controls.Add(this.pictureBoxExit);
            this.panel1.Controls.Add(this.pictureBoxEND);
            this.panel1.Cursor = System.Windows.Forms.Cursors.Default;
            this.panel1.Location = new System.Drawing.Point(7, 19);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(557, 554);
            this.panel1.TabIndex = 0;
            // 
            // lblInfoFinale
            // 
            this.lblInfoFinale.BackColor = System.Drawing.Color.Transparent;
            this.lblInfoFinale.Font = new System.Drawing.Font("Mom´sTypewriter", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblInfoFinale.Location = new System.Drawing.Point(17, 443);
            this.lblInfoFinale.Name = "lblInfoFinale";
            this.lblInfoFinale.Size = new System.Drawing.Size(518, 36);
            this.lblInfoFinale.TabIndex = 6;
            this.lblInfoFinale.Text = "END";
            this.lblInfoFinale.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblInfoFinale.Visible = false;
            // 
            // lblExit
            // 
            this.lblExit.AutoSize = true;
            this.lblExit.BackColor = System.Drawing.Color.Black;
            this.lblExit.Font = new System.Drawing.Font("Mom´sTypewriter", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblExit.ForeColor = System.Drawing.Color.Tomato;
            this.lblExit.Location = new System.Drawing.Point(256, 3);
            this.lblExit.Name = "lblExit";
            this.lblExit.Size = new System.Drawing.Size(38, 14);
            this.lblExit.TabIndex = 7;
            this.lblExit.Text = "EXIT";
            // 
            // pictureBoxExit
            // 
            this.pictureBoxExit.BackColor = System.Drawing.Color.Black;
            this.pictureBoxExit.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBoxExit.Location = new System.Drawing.Point(250, -1);
            this.pictureBoxExit.Name = "pictureBoxExit";
            this.pictureBoxExit.Size = new System.Drawing.Size(50, 20);
            this.pictureBoxExit.TabIndex = 5;
            this.pictureBoxExit.TabStop = false;
            // 
            // pictureBoxEND
            // 
            this.pictureBoxEND.BackColor = System.Drawing.Color.Transparent;
            this.pictureBoxEND.Location = new System.Drawing.Point(-3, -3);
            this.pictureBoxEND.Name = "pictureBoxEND";
            this.pictureBoxEND.Size = new System.Drawing.Size(557, 555);
            this.pictureBoxEND.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBoxEND.TabIndex = 0;
            this.pictureBoxEND.TabStop = false;
            this.pictureBoxEND.Visible = false;
            // 
            // lblForza
            // 
            this.lblForza.AutoSize = true;
            this.lblForza.Font = new System.Drawing.Font("Mom´sTypewriter", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblForza.Location = new System.Drawing.Point(640, 484);
            this.lblForza.Name = "lblForza";
            this.lblForza.Size = new System.Drawing.Size(80, 22);
            this.lblForza.TabIndex = 2;
            this.lblForza.Text = "FORZA";
            this.lblForza.Visible = false;
            // 
            // txtForza
            // 
            this.txtForza.Enabled = false;
            this.txtForza.Location = new System.Drawing.Point(726, 485);
            this.txtForza.Name = "txtForza";
            this.txtForza.Size = new System.Drawing.Size(42, 20);
            this.txtForza.TabIndex = 3;
            this.txtForza.Visible = false;
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // lblControl
            // 
            this.lblControl.Font = new System.Drawing.Font("Mom´sTypewriter", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblControl.ForeColor = System.Drawing.Color.Black;
            this.lblControl.Location = new System.Drawing.Point(567, 529);
            this.lblControl.Name = "lblControl";
            this.lblControl.Size = new System.Drawing.Size(257, 31);
            this.lblControl.TabIndex = 4;
            this.lblControl.Text = "INFO FORZA";
            this.lblControl.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblControl.Visible = false;
            // 
            // pictureBoxStart
            // 
            this.pictureBoxStart.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBoxStart.Enabled = false;
            this.pictureBoxStart.Image = ((System.Drawing.Image)(resources.GetObject("pictureBoxStart.Image")));
            this.pictureBoxStart.Location = new System.Drawing.Point(596, 365);
            this.pictureBoxStart.Name = "pictureBoxStart";
            this.pictureBoxStart.Size = new System.Drawing.Size(215, 92);
            this.pictureBoxStart.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBoxStart.TabIndex = 5;
            this.pictureBoxStart.TabStop = false;
            this.pictureBoxStart.Click += new System.EventHandler(this.pictureBoxStart_Click);
            // 
            // pictureBoxNewGame
            // 
            this.pictureBoxNewGame.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBoxNewGame.Image = ((System.Drawing.Image)(resources.GetObject("pictureBoxNewGame.Image")));
            this.pictureBoxNewGame.Location = new System.Drawing.Point(596, 285);
            this.pictureBoxNewGame.Name = "pictureBoxNewGame";
            this.pictureBoxNewGame.Size = new System.Drawing.Size(215, 75);
            this.pictureBoxNewGame.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBoxNewGame.TabIndex = 6;
            this.pictureBoxNewGame.TabStop = false;
            this.pictureBoxNewGame.Click += new System.EventHandler(this.pictureBoxNewGame_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Mom´sTypewriter", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(592, 97);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(57, 19);
            this.label1.TabIndex = 7;
            this.label1.Text = "NOME";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Mom´sTypewriter", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(593, 205);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(57, 19);
            this.label2.TabIndex = 8;
            this.label2.Text = "NOME";
            // 
            // txtNEroe
            // 
            this.txtNEroe.Location = new System.Drawing.Point(660, 97);
            this.txtNEroe.Name = "txtNEroe";
            this.txtNEroe.Size = new System.Drawing.Size(79, 20);
            this.txtNEroe.TabIndex = 9;
            // 
            // txtNNemico
            // 
            this.txtNNemico.Location = new System.Drawing.Point(661, 205);
            this.txtNNemico.Name = "txtNNemico";
            this.txtNNemico.Size = new System.Drawing.Size(78, 20);
            this.txtNNemico.TabIndex = 10;
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // btnScegliImmagine1
            // 
            this.btnScegliImmagine1.Location = new System.Drawing.Point(700, 122);
            this.btnScegliImmagine1.Name = "btnScegliImmagine1";
            this.btnScegliImmagine1.Size = new System.Drawing.Size(81, 25);
            this.btnScegliImmagine1.TabIndex = 11;
            this.btnScegliImmagine1.Text = "SCEGLI";
            this.btnScegliImmagine1.UseVisualStyleBackColor = true;
            this.btnScegliImmagine1.Click += new System.EventHandler(this.btnScegliImmagine1_Click);
            // 
            // btnScegliImmagine2
            // 
            this.btnScegliImmagine2.Location = new System.Drawing.Point(700, 231);
            this.btnScegliImmagine2.Name = "btnScegliImmagine2";
            this.btnScegliImmagine2.Size = new System.Drawing.Size(81, 25);
            this.btnScegliImmagine2.TabIndex = 12;
            this.btnScegliImmagine2.Text = "SCEGLI";
            this.btnScegliImmagine2.UseVisualStyleBackColor = true;
            this.btnScegliImmagine2.Click += new System.EventHandler(this.btnScegliImmagine2_Click);
            // 
            // lblEroe
            // 
            this.lblEroe.AutoSize = true;
            this.lblEroe.Font = new System.Drawing.Font("Mom´sTypewriter", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEroe.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.lblEroe.Location = new System.Drawing.Point(592, 64);
            this.lblEroe.Name = "lblEroe";
            this.lblEroe.Size = new System.Drawing.Size(62, 19);
            this.lblEroe.TabIndex = 13;
            this.lblEroe.Text = "EROE:";
            // 
            // lblNemico
            // 
            this.lblNemico.AutoSize = true;
            this.lblNemico.Font = new System.Drawing.Font("Mom´sTypewriter", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNemico.ForeColor = System.Drawing.Color.DarkRed;
            this.lblNemico.Location = new System.Drawing.Point(593, 172);
            this.lblNemico.Name = "lblNemico";
            this.lblNemico.Size = new System.Drawing.Size(83, 19);
            this.lblNemico.TabIndex = 14;
            this.lblNemico.Text = "NEMICO:";
            // 
            // lblNomeGioco
            // 
            this.lblNomeGioco.AutoSize = true;
            this.lblNomeGioco.Font = new System.Drawing.Font("Mom´sTypewriter", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNomeGioco.ForeColor = System.Drawing.Color.DarkTurquoise;
            this.lblNomeGioco.Location = new System.Drawing.Point(575, 20);
            this.lblNomeGioco.Name = "lblNomeGioco";
            this.lblNomeGioco.Size = new System.Drawing.Size(246, 22);
            this.lblNomeGioco.TabIndex = 15;
            this.lblNomeGioco.Text = "DIAMOND TO ESCAPE";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Mom´sTypewriter", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(592, 126);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(104, 19);
            this.label3.TabIndex = 16;
            this.label3.Text = "IMMAGINE";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Mom´sTypewriter", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(593, 236);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(104, 19);
            this.label4.TabIndex = 17;
            this.label4.Text = "IMMAGINE";
            // 
            // lblSpiegazione
            // 
            this.lblSpiegazione.AutoSize = true;
            this.lblSpiegazione.Font = new System.Drawing.Font("Mom´sTypewriter", 8.249999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSpiegazione.Location = new System.Drawing.Point(570, 484);
            this.lblSpiegazione.Name = "lblSpiegazione";
            this.lblSpiegazione.Size = new System.Drawing.Size(252, 42);
            this.lblSpiegazione.TabIndex = 18;
            this.lblSpiegazione.Text = "1. NEW GAME -> GENERA IL CAMPO;\r\n\r\n2. START -> INIZIA LA PARTITA;";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(829, 585);
            this.Controls.Add(this.lblSpiegazione);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.lblNomeGioco);
            this.Controls.Add(this.lblNemico);
            this.Controls.Add(this.lblEroe);
            this.Controls.Add(this.btnScegliImmagine2);
            this.Controls.Add(this.btnScegliImmagine1);
            this.Controls.Add(this.txtNNemico);
            this.Controls.Add(this.txtNEroe);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pictureBoxNewGame);
            this.Controls.Add(this.pictureBoxStart);
            this.Controls.Add(this.lblControl);
            this.Controls.Add(this.txtForza);
            this.Controls.Add(this.lblForza);
            this.Controls.Add(this.panel1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxExit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxEND)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxStart)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxNewGame)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lblForza;
        private System.Windows.Forms.TextBox txtForza;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Label lblControl;
        private System.Windows.Forms.PictureBox pictureBoxEND;
        private System.Windows.Forms.PictureBox pictureBoxExit;
        private System.Windows.Forms.PictureBox pictureBoxStart;
        private System.Windows.Forms.PictureBox pictureBoxNewGame;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtNEroe;
        private System.Windows.Forms.TextBox txtNNemico;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Button btnScegliImmagine1;
        private System.Windows.Forms.Button btnScegliImmagine2;
        private System.Windows.Forms.Label lblEroe;
        private System.Windows.Forms.Label lblNemico;
        private System.Windows.Forms.Label lblNomeGioco;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lblInfoFinale;
        private System.Windows.Forms.Label lblExit;
        private System.Windows.Forms.Label lblSpiegazione;
    }
}

