namespace WinUI.PlanIProgram
{
    partial class frmPlanDetails
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
            this.planIProgramNaziv = new System.Windows.Forms.Label();
            this.dgvDani = new System.Windows.Forms.DataGridView();
            this.Dan = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DanId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnDodajDan = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.cmbVjezbe = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cmbRedniBroj = new System.Windows.Forms.ComboBox();
            this.btnSpremi = new System.Windows.Forms.Button();
            this.dgvVjezbe = new System.Windows.Forms.DataGridView();
            this.grbDan = new System.Windows.Forms.GroupBox();
            this.Id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Vjezba = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.RedniBroj = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Detalji = new System.Windows.Forms.DataGridViewButtonColumn();
            this.Obrisi = new System.Windows.Forms.DataGridViewButtonColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDani)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvVjezbe)).BeginInit();
            this.grbDan.SuspendLayout();
            this.SuspendLayout();
            // 
            // planIProgramNaziv
            // 
            this.planIProgramNaziv.AutoSize = true;
            this.planIProgramNaziv.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.planIProgramNaziv.Location = new System.Drawing.Point(28, 30);
            this.planIProgramNaziv.Name = "planIProgramNaziv";
            this.planIProgramNaziv.Size = new System.Drawing.Size(137, 25);
            this.planIProgramNaziv.TabIndex = 0;
            this.planIProgramNaziv.Text = "Plan i program";
            // 
            // dgvDani
            // 
            this.dgvDani.AllowUserToAddRows = false;
            this.dgvDani.AllowUserToDeleteRows = false;
            this.dgvDani.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDani.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Dan,
            this.DanId});
            this.dgvDani.Location = new System.Drawing.Point(12, 58);
            this.dgvDani.Name = "dgvDani";
            this.dgvDani.ReadOnly = true;
            this.dgvDani.Size = new System.Drawing.Size(153, 437);
            this.dgvDani.TabIndex = 1;
            this.dgvDani.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvDani_CellDoubleClick);
            // 
            // Dan
            // 
            this.Dan.DataPropertyName = "Naziv";
            this.Dan.HeaderText = "Dan";
            this.Dan.Name = "Dan";
            this.Dan.ReadOnly = true;
            // 
            // DanId
            // 
            this.DanId.DataPropertyName = "Id";
            this.DanId.HeaderText = "Id";
            this.DanId.Name = "DanId";
            this.DanId.ReadOnly = true;
            this.DanId.Visible = false;
            // 
            // btnDodajDan
            // 
            this.btnDodajDan.Location = new System.Drawing.Point(90, 501);
            this.btnDodajDan.Name = "btnDodajDan";
            this.btnDodajDan.Size = new System.Drawing.Size(75, 23);
            this.btnDodajDan.TabIndex = 2;
            this.btnDodajDan.Text = "Dodaj dan";
            this.btnDodajDan.UseVisualStyleBackColor = true;
            this.btnDodajDan.Click += new System.EventHandler(this.btnDodajDan_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 29);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(39, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Vjezba";
            // 
            // cmbVjezbe
            // 
            this.cmbVjezbe.FormattingEnabled = true;
            this.cmbVjezbe.Location = new System.Drawing.Point(88, 26);
            this.cmbVjezbe.Name = "cmbVjezbe";
            this.cmbVjezbe.Size = new System.Drawing.Size(144, 21);
            this.cmbVjezbe.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(7, 71);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(55, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Redni broj";
            // 
            // cmbRedniBroj
            // 
            this.cmbRedniBroj.FormattingEnabled = true;
            this.cmbRedniBroj.Location = new System.Drawing.Point(88, 68);
            this.cmbRedniBroj.Name = "cmbRedniBroj";
            this.cmbRedniBroj.Size = new System.Drawing.Size(144, 21);
            this.cmbRedniBroj.TabIndex = 6;
            // 
            // btnSpremi
            // 
            this.btnSpremi.Location = new System.Drawing.Point(157, 114);
            this.btnSpremi.Name = "btnSpremi";
            this.btnSpremi.Size = new System.Drawing.Size(75, 23);
            this.btnSpremi.TabIndex = 7;
            this.btnSpremi.Text = "Spremi";
            this.btnSpremi.UseVisualStyleBackColor = true;
            this.btnSpremi.Click += new System.EventHandler(this.btnSpremi_Click);
            // 
            // dgvVjezbe
            // 
            this.dgvVjezbe.AllowUserToAddRows = false;
            this.dgvVjezbe.AllowUserToDeleteRows = false;
            this.dgvVjezbe.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvVjezbe.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Id,
            this.Vjezba,
            this.RedniBroj,
            this.Detalji,
            this.Obrisi});
            this.dgvVjezbe.Location = new System.Drawing.Point(253, 26);
            this.dgvVjezbe.Name = "dgvVjezbe";
            this.dgvVjezbe.ReadOnly = true;
            this.dgvVjezbe.Size = new System.Drawing.Size(445, 437);
            this.dgvVjezbe.TabIndex = 8;
            this.dgvVjezbe.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvVjezbe_CellClick);
            // 
            // grbDan
            // 
            this.grbDan.Controls.Add(this.dgvVjezbe);
            this.grbDan.Controls.Add(this.btnSpremi);
            this.grbDan.Controls.Add(this.cmbRedniBroj);
            this.grbDan.Controls.Add(this.label2);
            this.grbDan.Controls.Add(this.cmbVjezbe);
            this.grbDan.Controls.Add(this.label1);
            this.grbDan.Location = new System.Drawing.Point(237, 32);
            this.grbDan.Name = "grbDan";
            this.grbDan.Size = new System.Drawing.Size(709, 491);
            this.grbDan.TabIndex = 9;
            this.grbDan.TabStop = false;
            this.grbDan.Text = "Odaberite dan";
            // 
            // Id
            // 
            this.Id.DataPropertyName = "Id";
            this.Id.HeaderText = "Id";
            this.Id.Name = "Id";
            this.Id.ReadOnly = true;
            this.Id.Visible = false;
            // 
            // Vjezba
            // 
            this.Vjezba.DataPropertyName = "Vjezba";
            this.Vjezba.HeaderText = "Vježba";
            this.Vjezba.Name = "Vjezba";
            this.Vjezba.ReadOnly = true;
            // 
            // RedniBroj
            // 
            this.RedniBroj.DataPropertyName = "RedniBroj";
            this.RedniBroj.HeaderText = "Redni broj";
            this.RedniBroj.Name = "RedniBroj";
            this.RedniBroj.ReadOnly = true;
            // 
            // Detalji
            // 
            this.Detalji.HeaderText = "Detalji";
            this.Detalji.Name = "Detalji";
            this.Detalji.ReadOnly = true;
            this.Detalji.Text = "Detalji";
            this.Detalji.UseColumnTextForButtonValue = true;
            // 
            // Obrisi
            // 
            this.Obrisi.HeaderText = "Obriši";
            this.Obrisi.Name = "Obrisi";
            this.Obrisi.ReadOnly = true;
            this.Obrisi.Text = "Obriši";
            this.Obrisi.UseColumnTextForButtonValue = true;
            // 
            // frmPlanDetails
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(981, 595);
            this.Controls.Add(this.grbDan);
            this.Controls.Add(this.btnDodajDan);
            this.Controls.Add(this.dgvDani);
            this.Controls.Add(this.planIProgramNaziv);
            this.Name = "frmPlanDetails";
            this.Text = "frmPlanDetails";
            this.Load += new System.EventHandler(this.frmPlanDetails_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDani)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvVjezbe)).EndInit();
            this.grbDan.ResumeLayout(false);
            this.grbDan.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label planIProgramNaziv;
        private System.Windows.Forms.DataGridView dgvDani;
        private System.Windows.Forms.Button btnDodajDan;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmbVjezbe;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cmbRedniBroj;
        private System.Windows.Forms.Button btnSpremi;
        private System.Windows.Forms.DataGridView dgvVjezbe;
        private System.Windows.Forms.DataGridViewTextBoxColumn Dan;
        private System.Windows.Forms.DataGridViewTextBoxColumn DanId;
        private System.Windows.Forms.GroupBox grbDan;
        private System.Windows.Forms.DataGridViewTextBoxColumn Id;
        private System.Windows.Forms.DataGridViewTextBoxColumn Vjezba;
        private System.Windows.Forms.DataGridViewTextBoxColumn RedniBroj;
        private System.Windows.Forms.DataGridViewButtonColumn Detalji;
        private System.Windows.Forms.DataGridViewButtonColumn Obrisi;
    }
}