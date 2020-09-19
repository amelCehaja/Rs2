namespace WinUI.Pitanja
{
    partial class PitanjaList
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
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.PlanIProgram = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ImePrezime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DatumString = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Detalji = new System.Windows.Forms.DataGridViewButtonColumn();
            this.Id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Opis = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PlanId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(57, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Pitanja";
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.PlanIProgram,
            this.ImePrezime,
            this.DatumString,
            this.Detalji,
            this.Id,
            this.Opis,
            this.PlanId});
            this.dataGridView1.Location = new System.Drawing.Point(16, 49);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.Size = new System.Drawing.Size(493, 389);
            this.dataGridView1.TabIndex = 1;
            this.dataGridView1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellClick);
            // 
            // PlanIProgram
            // 
            this.PlanIProgram.DataPropertyName = "Plan";
            this.PlanIProgram.HeaderText = "Plan i program";
            this.PlanIProgram.Name = "PlanIProgram";
            this.PlanIProgram.ReadOnly = true;
            // 
            // ImePrezime
            // 
            this.ImePrezime.DataPropertyName = "ImePrezime";
            this.ImePrezime.HeaderText = "Korisnik";
            this.ImePrezime.Name = "ImePrezime";
            this.ImePrezime.ReadOnly = true;
            // 
            // DatumString
            // 
            this.DatumString.DataPropertyName = "DatumString";
            this.DatumString.HeaderText = "Datum";
            this.DatumString.Name = "DatumString";
            this.DatumString.ReadOnly = true;
            // 
            // Detalji
            // 
            this.Detalji.HeaderText = "Detalji";
            this.Detalji.Name = "Detalji";
            this.Detalji.ReadOnly = true;
            this.Detalji.Text = "Detalji";
            this.Detalji.UseColumnTextForButtonValue = true;
            // 
            // Id
            // 
            this.Id.DataPropertyName = "Id";
            this.Id.HeaderText = "Id";
            this.Id.Name = "Id";
            this.Id.ReadOnly = true;
            this.Id.Visible = false;
            // 
            // Opis
            // 
            this.Opis.DataPropertyName = "Opis";
            this.Opis.HeaderText = "Opis";
            this.Opis.Name = "Opis";
            this.Opis.ReadOnly = true;
            this.Opis.Visible = false;
            // 
            // PlanId
            // 
            this.PlanId.DataPropertyName = "PlanId";
            this.PlanId.HeaderText = "PlanId";
            this.PlanId.Name = "PlanId";
            this.PlanId.ReadOnly = true;
            this.PlanId.Visible = false;
            // 
            // PitanjaList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(521, 450);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.label1);
            this.Name = "PitanjaList";
            this.Text = "PitanjaList";
            this.Load += new System.EventHandler(this.PitanjaList_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn PlanIProgram;
        private System.Windows.Forms.DataGridViewTextBoxColumn ImePrezime;
        private System.Windows.Forms.DataGridViewTextBoxColumn DatumString;
        private System.Windows.Forms.DataGridViewButtonColumn Detalji;
        private System.Windows.Forms.DataGridViewTextBoxColumn Id;
        private System.Windows.Forms.DataGridViewTextBoxColumn Opis;
        private System.Windows.Forms.DataGridViewTextBoxColumn PlanId;
    }
}