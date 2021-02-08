
namespace WinUI.PlanIProgram
{
    partial class frmListaPlanIProgram
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
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.btnPretraga = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.txtSearchNaziv = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.Id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Naziv = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Cijena = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Kategorija = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Detalji = new System.Windows.Forms.DataGridViewButtonColumn();
            this.Uredi = new System.Windows.Forms.DataGridViewButtonColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Id,
            this.Naziv,
            this.Cijena,
            this.Kategorija,
            this.Detalji,
            this.Uredi});
            this.dataGridView1.Location = new System.Drawing.Point(12, 50);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.Size = new System.Drawing.Size(559, 439);
            this.dataGridView1.TabIndex = 17;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // btnPretraga
            // 
            this.btnPretraga.Location = new System.Drawing.Point(245, 8);
            this.btnPretraga.Name = "btnPretraga";
            this.btnPretraga.Size = new System.Drawing.Size(89, 23);
            this.btnPretraga.TabIndex = 16;
            this.btnPretraga.Text = "Pretraga";
            this.btnPretraga.UseVisualStyleBackColor = true;
            this.btnPretraga.Click += new System.EventHandler(this.btnPretraga_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(9, 13);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(34, 13);
            this.label5.TabIndex = 15;
            this.label5.Text = "Naziv";
            // 
            // txtSearchNaziv
            // 
            this.txtSearchNaziv.Location = new System.Drawing.Point(58, 10);
            this.txtSearchNaziv.Name = "txtSearchNaziv";
            this.txtSearchNaziv.Size = new System.Drawing.Size(166, 20);
            this.txtSearchNaziv.TabIndex = 14;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(449, 505);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(122, 23);
            this.button1.TabIndex = 18;
            this.button1.Text = "Novi plan i program";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
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
            // Cijena
            // 
            this.Cijena.DataPropertyName = "Cijena";
            this.Cijena.HeaderText = "Cijena";
            this.Cijena.Name = "Cijena";
            this.Cijena.ReadOnly = true;
            // 
            // Kategorija
            // 
            this.Kategorija.DataPropertyName = "Kategorija";
            this.Kategorija.HeaderText = "Kategorija";
            this.Kategorija.Name = "Kategorija";
            this.Kategorija.ReadOnly = true;
            // 
            // Detalji
            // 
            this.Detalji.HeaderText = "Detalji";
            this.Detalji.Name = "Detalji";
            this.Detalji.ReadOnly = true;
            this.Detalji.Text = "Detalji";
            this.Detalji.UseColumnTextForButtonValue = true;
            // 
            // Uredi
            // 
            this.Uredi.HeaderText = "Uredi";
            this.Uredi.Name = "Uredi";
            this.Uredi.ReadOnly = true;
            this.Uredi.Text = "Uredi";
            this.Uredi.UseColumnTextForButtonValue = true;
            // 
            // frmListaPlanIProgram
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(583, 544);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.btnPretraga);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtSearchNaziv);
            this.Name = "frmListaPlanIProgram";
            this.Text = "frmListaPlanIProgram";
            this.Load += new System.EventHandler(this.frmListaPlanIProgram_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button btnPretraga;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtSearchNaziv;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Id;
        private System.Windows.Forms.DataGridViewTextBoxColumn Naziv;
        private System.Windows.Forms.DataGridViewTextBoxColumn Cijena;
        private System.Windows.Forms.DataGridViewTextBoxColumn Kategorija;
        private System.Windows.Forms.DataGridViewButtonColumn Detalji;
        private System.Windows.Forms.DataGridViewButtonColumn Uredi;
    }
}