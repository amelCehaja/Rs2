namespace WinUI.Pitanja
{
    partial class Pitanje
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtPlan = new System.Windows.Forms.TextBox();
            this.txtKorisnik = new System.Windows.Forms.TextBox();
            this.txtDatum = new System.Windows.Forms.TextBox();
            this.txtPitanje = new System.Windows.Forms.RichTextBox();
            this.txtOdgovor = new System.Windows.Forms.RichTextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.btnOdgovori = new System.Windows.Forms.Button();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(21, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(70, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "PlanIProgram";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(21, 63);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(44, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Korisnik";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(21, 105);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(38, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Datum";
            this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(21, 149);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(39, 13);
            this.label4.TabIndex = 3;
            this.label4.Text = "Pitanje";
            // 
            // txtPlan
            // 
            this.txtPlan.Location = new System.Drawing.Point(111, 19);
            this.txtPlan.Name = "txtPlan";
            this.txtPlan.ReadOnly = true;
            this.txtPlan.Size = new System.Drawing.Size(238, 20);
            this.txtPlan.TabIndex = 4;
            // 
            // txtKorisnik
            // 
            this.txtKorisnik.Location = new System.Drawing.Point(111, 60);
            this.txtKorisnik.Name = "txtKorisnik";
            this.txtKorisnik.ReadOnly = true;
            this.txtKorisnik.Size = new System.Drawing.Size(238, 20);
            this.txtKorisnik.TabIndex = 5;
            // 
            // txtDatum
            // 
            this.txtDatum.Location = new System.Drawing.Point(111, 102);
            this.txtDatum.Name = "txtDatum";
            this.txtDatum.ReadOnly = true;
            this.txtDatum.Size = new System.Drawing.Size(238, 20);
            this.txtDatum.TabIndex = 6;
            // 
            // txtPitanje
            // 
            this.txtPitanje.Location = new System.Drawing.Point(111, 149);
            this.txtPitanje.Name = "txtPitanje";
            this.txtPitanje.ReadOnly = true;
            this.txtPitanje.Size = new System.Drawing.Size(238, 96);
            this.txtPitanje.TabIndex = 7;
            this.txtPitanje.Text = "";
            // 
            // txtOdgovor
            // 
            this.txtOdgovor.Location = new System.Drawing.Point(111, 305);
            this.txtOdgovor.Name = "txtOdgovor";
            this.txtOdgovor.Size = new System.Drawing.Size(238, 96);
            this.txtOdgovor.TabIndex = 8;
            this.txtOdgovor.Text = "";
            this.txtOdgovor.Validating += new System.ComponentModel.CancelEventHandler(this.txtOdgovor_Validating);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(21, 340);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(48, 13);
            this.label5.TabIndex = 9;
            this.label5.Text = "Odgovor";
            // 
            // btnOdgovori
            // 
            this.btnOdgovori.Location = new System.Drawing.Point(274, 420);
            this.btnOdgovori.Name = "btnOdgovori";
            this.btnOdgovori.Size = new System.Drawing.Size(75, 23);
            this.btnOdgovori.TabIndex = 10;
            this.btnOdgovori.Text = "Odgovori";
            this.btnOdgovori.UseVisualStyleBackColor = true;
            this.btnOdgovori.Click += new System.EventHandler(this.btnOdgovori_Click);
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // Pitanje
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(394, 472);
            this.Controls.Add(this.btnOdgovori);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtOdgovor);
            this.Controls.Add(this.txtPitanje);
            this.Controls.Add(this.txtDatum);
            this.Controls.Add(this.txtKorisnik);
            this.Controls.Add(this.txtPlan);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "Pitanje";
            this.Text = "Pitanje";
            this.Load += new System.EventHandler(this.Pitanje_Load);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtPlan;
        private System.Windows.Forms.TextBox txtKorisnik;
        private System.Windows.Forms.TextBox txtDatum;
        private System.Windows.Forms.RichTextBox txtPitanje;
        private System.Windows.Forms.RichTextBox txtOdgovor;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnOdgovori;
        private System.Windows.Forms.ErrorProvider errorProvider1;
    }
}