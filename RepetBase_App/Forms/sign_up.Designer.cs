namespace RepetBase_App
{
    partial class sign_up
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(sign_up));
            this.panel1 = new System.Windows.Forms.Panel();
            this.iconPic = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.buttonReg = new System.Windows.Forms.Button();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.FIO_Student_TB = new System.Windows.Forms.TextBox();
            this.email_TB = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.comboBoxSubject = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.dateStudent_DTP = new System.Windows.Forms.DateTimePicker();
            this.label5 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.nuberPhone_TB = new System.Windows.Forms.MaskedTextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.iconPic)).BeginInit();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Ivory;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.iconPic);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(4, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(779, 100);
            this.panel1.TabIndex = 0;
            // 
            // iconPic
            // 
            this.iconPic.BackColor = System.Drawing.Color.MintCream;
            this.iconPic.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.iconPic.Image = ((System.Drawing.Image)(resources.GetObject("iconPic.Image")));
            this.iconPic.Location = new System.Drawing.Point(16, 10);
            this.iconPic.Name = "iconPic";
            this.iconPic.Size = new System.Drawing.Size(82, 79);
            this.iconPic.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.iconPic.TabIndex = 2;
            this.iconPic.TabStop = false;
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Microsoft YaHei UI", 18F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(104, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(654, 80);
            this.label1.TabIndex = 1;
            this.label1.Text = "Заявка на регистрацию в учебный центр";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // buttonReg
            // 
            this.buttonReg.Enabled = false;
            this.buttonReg.Font = new System.Drawing.Font("Microsoft YaHei", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonReg.Location = new System.Drawing.Point(4, 373);
            this.buttonReg.Name = "buttonReg";
            this.buttonReg.Size = new System.Drawing.Size(779, 57);
            this.buttonReg.TabIndex = 1;
            this.buttonReg.Text = "Подать заявку!";
            this.buttonReg.UseVisualStyleBackColor = true;
            this.buttonReg.Click += new System.EventHandler(this.btnCreate_Click);
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.checkBox1.Location = new System.Drawing.Point(81, 347);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(628, 20);
            this.checkBox1.TabIndex = 2;
            this.checkBox1.Text = "Я принимаю условия соглашения и несу отвественность за предоставленную информацию" +
    "";
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // FIO_Student_TB
            // 
            this.FIO_Student_TB.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.FIO_Student_TB.Location = new System.Drawing.Point(143, 133);
            this.FIO_Student_TB.Name = "FIO_Student_TB";
            this.FIO_Student_TB.Size = new System.Drawing.Size(616, 26);
            this.FIO_Student_TB.TabIndex = 9;
            // 
            // email_TB
            // 
            this.email_TB.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.email_TB.Location = new System.Drawing.Point(143, 176);
            this.email_TB.Name = "email_TB";
            this.email_TB.Size = new System.Drawing.Size(616, 26);
            this.email_TB.TabIndex = 8;
            this.email_TB.Leave += new System.EventHandler(this.email_TB_Leave);
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.Color.Ivory;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(77, 61);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(60, 17);
            this.label2.TabIndex = 7;
            this.label2.Text = "Почта:";
            // 
            // label3
            // 
            this.label3.BackColor = System.Drawing.Color.Ivory;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.Location = new System.Drawing.Point(46, 18);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(91, 18);
            this.label3.TabIndex = 6;
            this.label3.Text = "Ваше ФИО:";
            // 
            // comboBoxSubject
            // 
            this.comboBoxSubject.Cursor = System.Windows.Forms.Cursors.Hand;
            this.comboBoxSubject.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.comboBoxSubject.FormattingEnabled = true;
            this.comboBoxSubject.Location = new System.Drawing.Point(138, 173);
            this.comboBoxSubject.Name = "comboBoxSubject";
            this.comboBoxSubject.Size = new System.Drawing.Size(616, 28);
            this.comboBoxSubject.TabIndex = 10;
            // 
            // label4
            // 
            this.label4.BackColor = System.Drawing.Color.Ivory;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label4.Location = new System.Drawing.Point(30, 179);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(102, 16);
            this.label4.TabIndex = 11;
            this.label4.Text = "Дисциплина:";
            // 
            // dateStudent_DTP
            // 
            this.dateStudent_DTP.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.dateStudent_DTP.Location = new System.Drawing.Point(143, 218);
            this.dateStudent_DTP.Name = "dateStudent_DTP";
            this.dateStudent_DTP.Size = new System.Drawing.Size(616, 26);
            this.dateStudent_DTP.TabIndex = 12;
            this.dateStudent_DTP.Leave += new System.EventHandler(this.dateStudent_DTP_ValueChanged);
            // 
            // label5
            // 
            this.label5.BackColor = System.Drawing.Color.Ivory;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label5.Location = new System.Drawing.Point(20, 220);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(131, 29);
            this.label5.TabIndex = 13;
            this.label5.Text = "Дата рождения:";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.Ivory;
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.nuberPhone_TB);
            this.panel2.Controls.Add(this.label6);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.comboBoxSubject);
            this.panel2.Controls.Add(this.label4);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Location = new System.Drawing.Point(4, 120);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(779, 215);
            this.panel2.TabIndex = 3;
            // 
            // nuberPhone_TB
            // 
            this.nuberPhone_TB.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.nuberPhone_TB.Location = new System.Drawing.Point(138, 138);
            this.nuberPhone_TB.Mask = "8 (999) 000-0000";
            this.nuberPhone_TB.Name = "nuberPhone_TB";
            this.nuberPhone_TB.Size = new System.Drawing.Size(616, 26);
            this.nuberPhone_TB.TabIndex = 15;
            // 
            // label6
            // 
            this.label6.BackColor = System.Drawing.Color.Ivory;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label6.Location = new System.Drawing.Point(43, 141);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(94, 23);
            this.label6.TabIndex = 14;
            this.label6.Text = "Номер тел:";
            // 
            // sign_up
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(790, 435);
            this.Controls.Add(this.dateStudent_DTP);
            this.Controls.Add(this.FIO_Student_TB);
            this.Controls.Add(this.email_TB);
            this.Controls.Add(this.checkBox1);
            this.Controls.Add(this.buttonReg);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.panel2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "sign_up";
            this.Text = "Регистрация пользователя";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.signUp_FormClosed);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.iconPic)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox iconPic;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button buttonReg;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.TextBox FIO_Student_TB;
        private System.Windows.Forms.TextBox email_TB;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox comboBoxSubject;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DateTimePicker dateStudent_DTP;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.MaskedTextBox nuberPhone_TB;
        private System.Windows.Forms.Label label6;
    }
}