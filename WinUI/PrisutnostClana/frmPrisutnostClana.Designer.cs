namespace WinUI.PrisutnostClana
{
    partial class frmPrisutnostClana
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
            this.label1 = new System.Windows.Forms.Label();
            this.txtBrojKartice = new System.Windows.Forms.TextBox();
            this.btnSpremi = new System.Windows.Forms.Button();
            this.dgvPrisutnost = new System.Windows.Forms.DataGridView();
            this.Id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Slika = new System.Windows.Forms.DataGridViewImageColumn();
            this.Ime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Prezime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.VrijemeDolaska = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TipClanarine = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.VrijediDo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Aktivan = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPrisutnost)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(28, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(60, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Broj kartice";
            // 
            // txtBrojKartice
            // 
            this.txtBrojKartice.Location = new System.Drawing.Point(108, 24);
            this.txtBrojKartice.Name = "txtBrojKartice";
            this.txtBrojKartice.Size = new System.Drawing.Size(142, 20);
            this.txtBrojKartice.TabIndex = 1;
            // 
            // btnSpremi
            // 
            this.btnSpremi.Location = new System.Drawing.Point(256, 22);
            this.btnSpremi.Name = "btnSpremi";
            this.btnSpremi.Size = new System.Drawing.Size(75, 23);
            this.btnSpremi.TabIndex = 2;
            this.btnSpremi.Text = "Spremi";
            this.btnSpremi.UseVisualStyleBackColor = true;
            this.btnSpremi.Click += new System.EventHandler(this.btnSpremi_Click);
            // 
            // dgvPrisutnost
            // 
            this.dgvPrisutnost.AllowUserToAddRows = false;
            this.dgvPrisutnost.AllowUserToDeleteRows = false;
            this.dgvPrisutnost.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPrisutnost.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Id,
            this.Slika,
            this.Ime,
            this.Prezime,
            this.VrijemeDolaska,
            this.TipClanarine,
            this.VrijediDo,
            this.Aktivan});
            this.dgvPrisutnost.Location = new System.Drawing.Point(26, 65);
            this.dgvPrisutnost.Name = "dgvPrisutnost";
            this.dgvPrisutnost.ReadOnly = true;
            this.dgvPrisutnost.RowTemplate.Height = 70;
            this.dgvPrisutnost.Size = new System.Drawing.Size(653, 426);
            this.dgvPrisutnost.TabIndex = 3;
            // 
            // Id
            // 
            this.Id.DataPropertyName = "VrijemeDolaska";
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
            // VrijemeDolaska
            // 
            this.VrijemeDolaska.DataPropertyName = "VrijemeDolaska";
            this.VrijemeDolaska.HeaderText = "VrijemeDolaska";
            this.VrijemeDolaska.Name = "VrijemeDolaska";
            this.VrijemeDolaska.ReadOnly = true;
            // 
            // TipClanarine
            // 
            this.TipClanarine.DataPropertyName = "TipClanarine";
            this.TipClanarine.HeaderText = "Tip Clanarine";
            this.TipClanarine.Name = "TipClanarine";
            this.TipClanarine.ReadOnly = true;
            // 
            // VrijediDo
            // 
            this.VrijediDo.DataPropertyName = "VrijediDo";
            this.VrijediDo.HeaderText = "Vrijedi do";
            this.VrijediDo.Name = "VrijediDo";
            this.VrijediDo.ReadOnly = true;
            // 
            // Aktivan
            // 
            this.Aktivan.DataPropertyName = "Aktivan";
            this.Aktivan.HeaderText = "Aktivan";
            this.Aktivan.Name = "Aktivan";
            this.Aktivan.ReadOnly = true;
            this.Aktivan.Visible = false;
            // 
            // frmPrisutnostClana
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(694, 503);
            this.Controls.Add(this.dgvPrisutnost);
            this.Controls.Add(this.btnSpremi);
            this.Controls.Add(this.txtBrojKartice);
            this.Controls.Add(this.label1);
            this.Name = "frmPrisutnostClana";
            this.Text = "frmPrisutnostClana";
            this.Load += new System.EventHandler(this.frmPrisutnostClana_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvPrisutnost)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtBrojKartice;
        private System.Windows.Forms.Button btnSpremi;
        private System.Windows.Forms.DataGridView dgvPrisutnost;
        private System.Windows.Forms.DataGridViewTextBoxColumn Id;
        private System.Windows.Forms.DataGridViewImageColumn Slika;
        private System.Windows.Forms.DataGridViewTextBoxColumn Ime;
        private System.Windows.Forms.DataGridViewTextBoxColumn Prezime;
        private System.Windows.Forms.DataGridViewTextBoxColumn VrijemeDolaska;
        private System.Windows.Forms.DataGridViewTextBoxColumn TipClanarine;
        private System.Windows.Forms.DataGridViewTextBoxColumn VrijediDo;
        private System.Windows.Forms.DataGridViewTextBoxColumn Aktivan;
    }
}