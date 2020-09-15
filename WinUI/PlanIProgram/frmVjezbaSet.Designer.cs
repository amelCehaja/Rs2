namespace WinUI.PlanIProgram
{
    partial class frmVjezbaSet
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
            this.components = new System.ComponentModel.Container();
            this.txtDan = new System.Windows.Forms.Label();
            this.txtVjezba = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtBrojPonavljanja = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtTrajanjeOdmora = new System.Windows.Forms.TextBox();
            this.btnSpremi = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.Id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BrojPonavljanja = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DuzinaOdmora = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // txtDan
            // 
            this.txtDan.AutoSize = true;
            this.txtDan.Location = new System.Drawing.Point(24, 36);
            this.txtDan.Name = "txtDan";
            this.txtDan.Size = new System.Drawing.Size(35, 13);
            this.txtDan.TabIndex = 0;
            this.txtDan.Text = "label1";
            // 
            // txtVjezba
            // 
            this.txtVjezba.AutoSize = true;
            this.txtVjezba.Location = new System.Drawing.Point(163, 36);
            this.txtVjezba.Name = "txtVjezba";
            this.txtVjezba.Size = new System.Drawing.Size(35, 13);
            this.txtVjezba.TabIndex = 1;
            this.txtVjezba.Text = "label1";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(24, 95);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(82, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Broj ponavljanja";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // txtBrojPonavljanja
            // 
            this.txtBrojPonavljanja.Location = new System.Drawing.Point(166, 92);
            this.txtBrojPonavljanja.Name = "txtBrojPonavljanja";
            this.txtBrojPonavljanja.Size = new System.Drawing.Size(85, 20);
            this.txtBrojPonavljanja.TabIndex = 3;
            this.txtBrojPonavljanja.Validating += new System.ComponentModel.CancelEventHandler(this.txtBrojPonavljanja_Validate);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(24, 145);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(128, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Duzina odmora (sekunde)";
            // 
            // txtTrajanjeOdmora
            // 
            this.txtTrajanjeOdmora.Location = new System.Drawing.Point(166, 142);
            this.txtTrajanjeOdmora.Name = "txtTrajanjeOdmora";
            this.txtTrajanjeOdmora.Size = new System.Drawing.Size(85, 20);
            this.txtTrajanjeOdmora.TabIndex = 5;
            this.txtTrajanjeOdmora.Validating += new System.ComponentModel.CancelEventHandler(this.txtDuzinaOdmora_Validate);
            // 
            // btnSpremi
            // 
            this.btnSpremi.Location = new System.Drawing.Point(176, 194);
            this.btnSpremi.Name = "btnSpremi";
            this.btnSpremi.Size = new System.Drawing.Size(75, 23);
            this.btnSpremi.TabIndex = 6;
            this.btnSpremi.Text = "Spremi";
            this.btnSpremi.UseVisualStyleBackColor = true;
            this.btnSpremi.Click += new System.EventHandler(this.btnSpremi_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Id,
            this.BrojPonavljanja,
            this.DuzinaOdmora});
            this.dataGridView1.Location = new System.Drawing.Point(328, 64);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.Size = new System.Drawing.Size(252, 256);
            this.dataGridView1.TabIndex = 7;
            // 
            // Id
            // 
            this.Id.DataPropertyName = "Id";
            this.Id.HeaderText = "Id";
            this.Id.Name = "Id";
            this.Id.ReadOnly = true;
            this.Id.Visible = false;
            // 
            // BrojPonavljanja
            // 
            this.BrojPonavljanja.DataPropertyName = "BrojPonavljanja";
            this.BrojPonavljanja.HeaderText = "Broj ponavljanja";
            this.BrojPonavljanja.Name = "BrojPonavljanja";
            this.BrojPonavljanja.ReadOnly = true;
            // 
            // DuzinaOdmora
            // 
            this.DuzinaOdmora.DataPropertyName = "TrajanjeOdmora";
            this.DuzinaOdmora.HeaderText = "Duzina odmora";
            this.DuzinaOdmora.Name = "DuzinaOdmora";
            this.DuzinaOdmora.ReadOnly = true;
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // frmVjezbaSet
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(612, 370);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.btnSpremi);
            this.Controls.Add(this.txtTrajanjeOdmora);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtBrojPonavljanja);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtVjezba);
            this.Controls.Add(this.txtDan);
            this.Name = "frmVjezbaSet";
            this.Text = "frmVjezbaSet";
            this.Load += new System.EventHandler(this.frmVjezbaSet_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label txtDan;
        private System.Windows.Forms.Label txtVjezba;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtBrojPonavljanja;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtTrajanjeOdmora;
        private System.Windows.Forms.Button btnSpremi;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Id;
        private System.Windows.Forms.DataGridViewTextBoxColumn BrojPonavljanja;
        private System.Windows.Forms.DataGridViewTextBoxColumn DuzinaOdmora;
        private System.Windows.Forms.ErrorProvider errorProvider1;
    }
}