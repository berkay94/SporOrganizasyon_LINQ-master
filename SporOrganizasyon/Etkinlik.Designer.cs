namespace SporOrganizasyon
{
    partial class Etkinlik
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
            this.btnAc = new System.Windows.Forms.Button();
            this.txtKontenjan = new System.Windows.Forms.TextBox();
            this.maskedTextBoxTrh = new System.Windows.Forms.MaskedTextBox();
            this.comboBoxMekan = new System.Windows.Forms.ComboBox();
            this.comboBoxTip = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtEtkinlik = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.comboBoxSpor = new System.Windows.Forms.ComboBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // btnAc
            // 
            this.btnAc.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnAc.Location = new System.Drawing.Point(99, 268);
            this.btnAc.Name = "btnAc";
            this.btnAc.Size = new System.Drawing.Size(100, 23);
            this.btnAc.TabIndex = 20;
            this.btnAc.Text = "Oluştur";
            this.btnAc.UseVisualStyleBackColor = true;
            this.btnAc.Click += new System.EventHandler(this.btnAc_Click);
            // 
            // txtKontenjan
            // 
            this.txtKontenjan.Location = new System.Drawing.Point(99, 228);
            this.txtKontenjan.Name = "txtKontenjan";
            this.txtKontenjan.Size = new System.Drawing.Size(100, 20);
            this.txtKontenjan.TabIndex = 19;
            // 
            // maskedTextBoxTrh
            // 
            this.maskedTextBoxTrh.Location = new System.Drawing.Point(99, 187);
            this.maskedTextBoxTrh.Mask = "00/00/0000 90:00";
            this.maskedTextBoxTrh.Name = "maskedTextBoxTrh";
            this.maskedTextBoxTrh.Size = new System.Drawing.Size(100, 20);
            this.maskedTextBoxTrh.TabIndex = 18;
            this.maskedTextBoxTrh.ValidatingType = typeof(System.DateTime);
            // 
            // comboBoxMekan
            // 
            this.comboBoxMekan.FormattingEnabled = true;
            this.comboBoxMekan.Location = new System.Drawing.Point(99, 145);
            this.comboBoxMekan.Name = "comboBoxMekan";
            this.comboBoxMekan.Size = new System.Drawing.Size(280, 21);
            this.comboBoxMekan.TabIndex = 17;
            // 
            // comboBoxTip
            // 
            this.comboBoxTip.FormattingEnabled = true;
            this.comboBoxTip.Location = new System.Drawing.Point(99, 103);
            this.comboBoxTip.Name = "comboBoxTip";
            this.comboBoxTip.Size = new System.Drawing.Size(121, 21);
            this.comboBoxTip.TabIndex = 16;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(18, 188);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(31, 13);
            this.label5.TabIndex = 14;
            this.label5.Text = "Tarih";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(18, 230);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(27, 13);
            this.label4.TabIndex = 15;
            this.label4.Text = "Sayı";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(18, 146);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(40, 13);
            this.label3.TabIndex = 13;
            this.label3.Text = "Mekan";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(18, 104);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(22, 13);
            this.label2.TabIndex = 12;
            this.label2.Text = "Tip";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(18, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(44, 13);
            this.label1.TabIndex = 11;
            this.label1.Text = "Etkinlik ";
            // 
            // txtEtkinlik
            // 
            this.txtEtkinlik.Location = new System.Drawing.Point(99, 20);
            this.txtEtkinlik.Name = "txtEtkinlik";
            this.txtEtkinlik.Size = new System.Drawing.Size(280, 20);
            this.txtEtkinlik.TabIndex = 10;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(18, 62);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(40, 13);
            this.label6.TabIndex = 21;
            this.label6.Text = "Sporlar";
            // 
            // comboBoxSpor
            // 
            this.comboBoxSpor.FormattingEnabled = true;
            this.comboBoxSpor.Location = new System.Drawing.Point(99, 61);
            this.comboBoxSpor.Name = "comboBoxSpor";
            this.comboBoxSpor.Size = new System.Drawing.Size(121, 21);
            this.comboBoxSpor.TabIndex = 22;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::SporOrganizasyon.Properties.Resources.Sports_PNG_Image;
            this.pictureBox1.Location = new System.Drawing.Point(403, 20);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(288, 271);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 23;
            this.pictureBox1.TabStop = false;
            // 
            // Etkinlik
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(703, 300);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.comboBoxSpor);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.btnAc);
            this.Controls.Add(this.txtKontenjan);
            this.Controls.Add(this.maskedTextBoxTrh);
            this.Controls.Add(this.comboBoxMekan);
            this.Controls.Add(this.comboBoxTip);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtEtkinlik);
            this.Name = "Etkinlik";
            this.Text = "Etkinlik";
            this.Load += new System.EventHandler(this.Etkinlik_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnAc;
        private System.Windows.Forms.TextBox txtKontenjan;
        private System.Windows.Forms.MaskedTextBox maskedTextBoxTrh;
        private System.Windows.Forms.ComboBox comboBoxMekan;
        private System.Windows.Forms.ComboBox comboBoxTip;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtEtkinlik;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox comboBoxSpor;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}