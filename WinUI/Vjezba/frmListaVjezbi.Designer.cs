
namespace WinUI.Vjezba
{
    partial class frmListaVjezbi
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
            this.btnPretraga = new System.Windows.Forms.Button();
            this.cmbMisic = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.dgvVjezbe = new System.Windows.Forms.DataGridView();
            this.Id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Naziv = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Misici = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Uredi = new System.Windows.Forms.DataGridViewButtonColumn();
            this.button1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvVjezbe)).BeginInit();
            this.SuspendLayout();
            // 
            // btnPretraga
            // 
            this.btnPretraga.Location = new System.Drawing.Point(212, 5);
            this.btnPretraga.Name = "btnPretraga";
            this.btnPretraga.Size = new System.Drawing.Size(89, 23);
            this.btnPretraga.TabIndex = 18;
            this.btnPretraga.Text = "Pretraga";
            this.btnPretraga.UseVisualStyleBackColor = true;
            this.btnPretraga.Click += new System.EventHandler(this.btnPretraga_Click);
            // 
            // cmbMisic
            // 
            this.cmbMisic.FormattingEnabled = true;
            this.cmbMisic.Location = new System.Drawing.Point(46, 7);
            this.cmbMisic.Name = "cmbMisic";
            this.cmbMisic.Size = new System.Drawing.Size(134, 21);
            this.cmbMisic.TabIndex = 17;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(9, 10);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(31, 13);
            this.label5.TabIndex = 16;
            this.label5.Text = "Misic";
            // 
            // dgvVjezbe
            // 
            this.dgvVjezbe.AllowUserToAddRows = false;
            this.dgvVjezbe.AllowUserToDeleteRows = false;
            this.dgvVjezbe.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvVjezbe.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Id,
            this.Naziv,
            this.Misici,
            this.Uredi});
            this.dgvVjezbe.Location = new System.Drawing.Point(12, 47);
            this.dgvVjezbe.Name = "dgvVjezbe";
            this.dgvVjezbe.ReadOnly = true;
            this.dgvVjezbe.Size = new System.Drawing.Size(374, 349);
            this.dgvVjezbe.TabIndex = 15;
            this.dgvVjezbe.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvVjezbe_CellClick);
            // 
            // Id
            // 
            this.Id.DataPropertyName = "Id";
            this.Id.HeaderText = "Id";
            this.Id.Name = "Id";
            this.Id.ReadOnly = true;
            this.Id.Visible = false;
            // 
            // Naziv
            // 
            this.Naziv.DataPropertyName = "Naziv";
            this.Naziv.HeaderText = "Naziv";
            this.Naziv.Name = "Naziv";
            this.Naziv.ReadOnly = true;
            // 
            // Misici
            // 
            this.Misici.DataPropertyName = "MisiciString";
            this.Misici.HeaderText = "Misici";
            this.Misici.Name = "Misici";
            this.Misici.ReadOnly = true;
            // 
            // Uredi
            // 
            this.Uredi.HeaderText = "Uredi";
            this.Uredi.Name = "Uredi";
            this.Uredi.ReadOnly = true;
            this.Uredi.Text = "Uredi";
            this.Uredi.UseColumnTextForButtonValue = true;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(250, 415);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(136, 23);
            this.button1.TabIndex = 19;
            this.button1.Text = "Nova vjezba";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // frmListaVjezbi
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(405, 450);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.btnPretraga);
            this.Controls.Add(this.cmbMisic);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.dgvVjezbe);
            this.Name = "frmListaVjezbi";
            this.Text = "frmListaVjezbi";
            this.Load += new System.EventHandler(this.frmListaVjezbi_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvVjezbe)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnPretraga;
        private System.Windows.Forms.ComboBox cmbMisic;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DataGridView dgvVjezbe;
        private System.Windows.Forms.DataGridViewTextBoxColumn Id;
        private System.Windows.Forms.DataGridViewTextBoxColumn Naziv;
        private System.Windows.Forms.DataGridViewTextBoxColumn Misici;
        private System.Windows.Forms.DataGridViewButtonColumn Uredi;
        private System.Windows.Forms.Button button1;
    }
}