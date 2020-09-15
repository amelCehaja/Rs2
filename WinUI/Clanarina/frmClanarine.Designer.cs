namespace WinUI.Clanarina
{
    partial class frmClanarine
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
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.dtpDatumDodavanja = new System.Windows.Forms.DateTimePicker();
            this.dtpDatumIsteka = new System.Windows.Forms.DateTimePicker();
            this.cmbTipClanarine = new System.Windows.Forms.ComboBox();
            this.btnSpremi = new System.Windows.Forms.Button();
            this.dgvClanarine = new System.Windows.Forms.DataGridView();
            this.Id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DatumDodavanja = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DatumIsteka = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TipClanarine = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Obrisi = new System.Windows.Forms.DataGridViewButtonColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgvClanarine)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(32, 62);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(21, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Od";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(34, 106);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(21, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Do";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(32, 152);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(68, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Tip clanarine";
            // 
            // dtpDatumDodavanja
            // 
            this.dtpDatumDodavanja.Location = new System.Drawing.Point(117, 56);
            this.dtpDatumDodavanja.Name = "dtpDatumDodavanja";
            this.dtpDatumDodavanja.Size = new System.Drawing.Size(200, 20);
            this.dtpDatumDodavanja.TabIndex = 3;
            this.dtpDatumDodavanja.ValueChanged += new System.EventHandler(this.dtpDatumDodavanja_ValueChanged);
            // 
            // dtpDatumIsteka
            // 
            this.dtpDatumIsteka.Enabled = false;
            this.dtpDatumIsteka.Location = new System.Drawing.Point(117, 99);
            this.dtpDatumIsteka.Name = "dtpDatumIsteka";
            this.dtpDatumIsteka.Size = new System.Drawing.Size(200, 20);
            this.dtpDatumIsteka.TabIndex = 4;
            // 
            // cmbTipClanarine
            // 
            this.cmbTipClanarine.FormattingEnabled = true;
            this.cmbTipClanarine.Location = new System.Drawing.Point(117, 149);
            this.cmbTipClanarine.Name = "cmbTipClanarine";
            this.cmbTipClanarine.Size = new System.Drawing.Size(200, 21);
            this.cmbTipClanarine.TabIndex = 5;
            this.cmbTipClanarine.SelectedIndexChanged += new System.EventHandler(this.cmbTipClanarine_SelectedIndexChanged);
            // 
            // btnSpremi
            // 
            this.btnSpremi.Location = new System.Drawing.Point(117, 208);
            this.btnSpremi.Name = "btnSpremi";
            this.btnSpremi.Size = new System.Drawing.Size(75, 23);
            this.btnSpremi.TabIndex = 6;
            this.btnSpremi.Text = "Spremi";
            this.btnSpremi.UseVisualStyleBackColor = true;
            this.btnSpremi.Click += new System.EventHandler(this.btnSpremi_Click);
            // 
            // dgvClanarine
            // 
            this.dgvClanarine.AllowUserToAddRows = false;
            this.dgvClanarine.AllowUserToDeleteRows = false;
            this.dgvClanarine.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvClanarine.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Id,
            this.DatumDodavanja,
            this.DatumIsteka,
            this.TipClanarine,
            this.Obrisi});
            this.dgvClanarine.Location = new System.Drawing.Point(386, 56);
            this.dgvClanarine.Name = "dgvClanarine";
            this.dgvClanarine.ReadOnly = true;
            this.dgvClanarine.Size = new System.Drawing.Size(464, 368);
            this.dgvClanarine.TabIndex = 7;
            this.dgvClanarine.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvClanarine_CellClick);
            // 
            // Id
            // 
            this.Id.DataPropertyName = "Id";
            this.Id.HeaderText = "Id";
            this.Id.Name = "Id";
            this.Id.ReadOnly = true;
            this.Id.Visible = false;
            // 
            // DatumDodavanja
            // 
            this.DatumDodavanja.DataPropertyName = "DatumDodavanja";
            this.DatumDodavanja.HeaderText = "Datum dodavanja";
            this.DatumDodavanja.Name = "DatumDodavanja";
            this.DatumDodavanja.ReadOnly = true;
            // 
            // DatumIsteka
            // 
            this.DatumIsteka.DataPropertyName = "DatumIsteka";
            this.DatumIsteka.HeaderText = "Datum isteka";
            this.DatumIsteka.Name = "DatumIsteka";
            this.DatumIsteka.ReadOnly = true;
            // 
            // TipClanarine
            // 
            this.TipClanarine.DataPropertyName = "TipClanarine";
            this.TipClanarine.HeaderText = "Tip clanarine";
            this.TipClanarine.Name = "TipClanarine";
            this.TipClanarine.ReadOnly = true;
            // 
            // Obrisi
            // 
            this.Obrisi.HeaderText = "Akcija";
            this.Obrisi.Name = "Obrisi";
            this.Obrisi.ReadOnly = true;
            this.Obrisi.Text = "Obrisi";
            this.Obrisi.UseColumnTextForButtonValue = true;
            // 
            // frmClanarine
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(897, 450);
            this.Controls.Add(this.dgvClanarine);
            this.Controls.Add(this.btnSpremi);
            this.Controls.Add(this.cmbTipClanarine);
            this.Controls.Add(this.dtpDatumIsteka);
            this.Controls.Add(this.dtpDatumDodavanja);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "frmClanarine";
            this.Text = "frmClanarine";
            this.Load += new System.EventHandler(this.frmClanarine_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvClanarine)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DateTimePicker dtpDatumDodavanja;
        private System.Windows.Forms.DateTimePicker dtpDatumIsteka;
        private System.Windows.Forms.ComboBox cmbTipClanarine;
        private System.Windows.Forms.Button btnSpremi;
        private System.Windows.Forms.DataGridView dgvClanarine;
        private System.Windows.Forms.DataGridViewTextBoxColumn Id;
        private System.Windows.Forms.DataGridViewTextBoxColumn DatumDodavanja;
        private System.Windows.Forms.DataGridViewTextBoxColumn DatumIsteka;
        private System.Windows.Forms.DataGridViewTextBoxColumn TipClanarine;
        private System.Windows.Forms.DataGridViewButtonColumn Obrisi;
    }
}