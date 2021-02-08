
namespace WinUI.Clanovi
{
    partial class frmListaClanova
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnPretrazi = new System.Windows.Forms.Button();
            this.txtSearchPrezime = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.txtSearchIme = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.dgvClanovi = new System.Windows.Forms.DataGridView();
            this.Id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Slika = new System.Windows.Forms.DataGridViewImageColumn();
            this.Ime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Prezime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Spol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BrojKartice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Uredi = new System.Windows.Forms.DataGridViewButtonColumn();
            this.Članarine = new System.Windows.Forms.DataGridViewButtonColumn();
            this.button1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvClanovi)).BeginInit();
            this.SuspendLayout();
            // 
            // btnPretrazi
            // 
            this.btnPretrazi.Location = new System.Drawing.Point(415, 10);
            this.btnPretrazi.Name = "btnPretrazi";
            this.btnPretrazi.Size = new System.Drawing.Size(100, 23);
            this.btnPretrazi.TabIndex = 34;
            this.btnPretrazi.Text = "Pretrazi";
            this.btnPretrazi.UseVisualStyleBackColor = true;
            this.btnPretrazi.Click += new System.EventHandler(this.btnPretrazi_Click);
            // 
            // txtSearchPrezime
            // 
            this.txtSearchPrezime.Location = new System.Drawing.Point(250, 12);
            this.txtSearchPrezime.Name = "txtSearchPrezime";
            this.txtSearchPrezime.Size = new System.Drawing.Size(148, 20);
            this.txtSearchPrezime.TabIndex = 33;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(200, 19);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(44, 13);
            this.label9.TabIndex = 32;
            this.label9.Text = "Prezime";
            // 
            // txtSearchIme
            // 
            this.txtSearchIme.Location = new System.Drawing.Point(37, 12);
            this.txtSearchIme.Name = "txtSearchIme";
            this.txtSearchIme.Size = new System.Drawing.Size(148, 20);
            this.txtSearchIme.TabIndex = 31;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(7, 19);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(24, 13);
            this.label7.TabIndex = 30;
            this.label7.Text = "Ime";
            // 
            // dgvClanovi
            // 
            this.dgvClanovi.AllowUserToAddRows = false;
            this.dgvClanovi.AllowUserToDeleteRows = false;
            this.dgvClanovi.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvClanovi.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Id,
            this.Slika,
            this.Ime,
            this.Prezime,
            this.Spol,
            this.BrojKartice,
            this.Uredi,
            this.Članarine});
            this.dgvClanovi.Location = new System.Drawing.Point(10, 54);
            this.dgvClanovi.Name = "dgvClanovi";
            this.dgvClanovi.ReadOnly = true;
            this.dgvClanovi.RowTemplate.Height = 70;
            this.dgvClanovi.Size = new System.Drawing.Size(767, 384);
            this.dgvClanovi.TabIndex = 35;
            this.dgvClanovi.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvClanovi_CellContentClick);
            // 
            // Id
            // 
            this.Id.DataPropertyName = "Id";
            this.Id.HeaderText = "Id";
            this.Id.Name = "Id";
            this.Id.ReadOnly = true;
            this.Id.Visible = false;
            // 
            // Slika
            // 
            this.Slika.DataPropertyName = "Slika";
            this.Slika.HeaderText = "Slika";
            this.Slika.ImageLayout = System.Windows.Forms.DataGridViewImageCellLayout.Zoom;
            this.Slika.Name = "Slika";
            this.Slika.ReadOnly = true;
            // 
            // Ime
            // 
            this.Ime.DataPropertyName = "Ime";
            this.Ime.HeaderText = "Ime";
            this.Ime.Name = "Ime";
            this.Ime.ReadOnly = true;
            // 
            // Prezime
            // 
            this.Prezime.DataPropertyName = "Prezime";
            this.Prezime.HeaderText = "Prezime";
            this.Prezime.Name = "Prezime";
            this.Prezime.ReadOnly = true;
            // 
            // Spol
            // 
            this.Spol.DataPropertyName = "Spol";
            this.Spol.HeaderText = "Spol";
            this.Spol.Name = "Spol";
            this.Spol.ReadOnly = true;
            // 
            // BrojKartice
            // 
            this.BrojKartice.DataPropertyName = "BrojKartice";
            this.BrojKartice.HeaderText = "Broj kartice";
            this.BrojKartice.Name = "BrojKartice";
            this.BrojKartice.ReadOnly = true;
            // 
            // Uredi
            // 
            this.Uredi.HeaderText = "Uredi";
            this.Uredi.Name = "Uredi";
            this.Uredi.ReadOnly = true;
            this.Uredi.Text = "Uredi";
            this.Uredi.ToolTipText = "Uredi";
            this.Uredi.UseColumnTextForButtonValue = true;
            // 
            // Članarine
            // 
            this.Članarine.HeaderText = "Članarine";
            this.Članarine.Name = "Članarine";
            this.Članarine.ReadOnly = true;
            this.Članarine.Text = "Članarine";
            this.Članarine.ToolTipText = "Članarine";
            this.Članarine.UseColumnTextForButtonValue = true;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(623, 453);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(154, 36);
            this.button1.TabIndex = 36;
            this.button1.Text = "Dodaj novog clana";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // frmListaClanova
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(794, 501);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.dgvClanovi);
            this.Controls.Add(this.btnPretrazi);
            this.Controls.Add(this.txtSearchPrezime);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.txtSearchIme);
            this.Controls.Add(this.label7);
            this.Name = "frmListaClanova";
            this.Text = "frmListaClanova";
            this.Load += new System.EventHandler(this.frmListaClanova_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvClanovi)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnPretrazi;
        private System.Windows.Forms.TextBox txtSearchPrezime;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtSearchIme;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.DataGridView dgvClanovi;
        private System.Windows.Forms.DataGridViewTextBoxColumn Id;
        private System.Windows.Forms.DataGridViewImageColumn Slika;
        private System.Windows.Forms.DataGridViewTextBoxColumn Ime;
        private System.Windows.Forms.DataGridViewTextBoxColumn Prezime;
        private System.Windows.Forms.DataGridViewTextBoxColumn Spol;
        private System.Windows.Forms.DataGridViewTextBoxColumn BrojKartice;
        private System.Windows.Forms.DataGridViewButtonColumn Uredi;
        private System.Windows.Forms.DataGridViewButtonColumn Članarine;
        private System.Windows.Forms.Button button1;
    }
}