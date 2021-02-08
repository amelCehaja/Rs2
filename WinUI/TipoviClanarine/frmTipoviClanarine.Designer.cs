namespace WinUI.TipoviClanarine
{
    partial class frmTipoviClanarine
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
            this.txtNaziv = new System.Windows.Forms.TextBox();
            this.txtCijena = new System.Windows.Forms.TextBox();
            this.txtTrajanje = new System.Windows.Forms.TextBox();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(35, 46);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(34, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Naziv";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(35, 81);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(36, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Cijena";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(35, 116);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(45, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Trajanje";
            // 
            // txtNaziv
            // 
            this.txtNaziv.Location = new System.Drawing.Point(114, 43);
            this.txtNaziv.Name = "txtNaziv";
            this.txtNaziv.Size = new System.Drawing.Size(165, 20);
            this.txtNaziv.TabIndex = 6;
            this.txtNaziv.Validating += new System.ComponentModel.CancelEventHandler(this.txtNaziv_Validating);
            // 
            // txtCijena
            // 
            this.txtCijena.Location = new System.Drawing.Point(114, 74);
            this.txtCijena.Name = "txtCijena";
            this.txtCijena.Size = new System.Drawing.Size(165, 20);
            this.txtCijena.TabIndex = 7;
            this.txtCijena.Validating += new System.ComponentModel.CancelEventHandler(this.txtCijena_Validating);
            // 
            // txtTrajanje
            // 
            this.txtTrajanje.Location = new System.Drawing.Point(114, 109);
            this.txtTrajanje.Name = "txtTrajanje";
            this.txtTrajanje.Size = new System.Drawing.Size(165, 20);
            this.txtTrajanje.TabIndex = 8;
            this.txtTrajanje.Validating += new System.ComponentModel.CancelEventHandler(this.txtTrajanje_Validating);
            // 
            // btnUpdate
            // 
            this.btnUpdate.Location = new System.Drawing.Point(186, 154);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(93, 23);
            this.btnUpdate.TabIndex = 9;
            this.btnUpdate.Text = "Spremi";
            this.btnUpdate.UseVisualStyleBackColor = true;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // frmTipoviClanarine
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(344, 252);
            this.Controls.Add(this.btnUpdate);
            this.Controls.Add(this.txtTrajanje);
            this.Controls.Add(this.txtCijena);
            this.Controls.Add(this.txtNaziv);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "frmTipoviClanarine";
            this.Text = "frmTipoviClanarine";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmTipoviClanarine_FormClosed);
            this.Load += new System.EventHandler(this.frmTipoviClanarine_Load);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtNaziv;
        private System.Windows.Forms.TextBox txtCijena;
        private System.Windows.Forms.TextBox txtTrajanje;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.ErrorProvider errorProvider1;
    }
}